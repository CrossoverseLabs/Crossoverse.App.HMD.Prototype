using System;
using Crossoverse.Core.Domain.MotionCapture.FaceTracking;

namespace Crossoverse.HMDApp.Quest.Infrastructure.FaceTracking
{
    public sealed class OVRFaceTrackingSystem : IFaceTrackingSystem
    {
        private readonly float _scaleFactor;
        private OVRFaceExpressions _faceExpressions;

#region Ring Buffer
        public int BufferSize => _bufferSize;

        private readonly FaceTrackingData[] _faceTrackingDataBuffer;
        private readonly int _bufferSize;
        private readonly long _bufferMask;

        private long _bufferHead = 0;
        private long _bufferTail = 0;
#endregion

        public OVRFaceTrackingSystem(float scaleFactor = 100f, int bufferSize = 4)
        {            
            _scaleFactor = scaleFactor;

            _bufferSize = CeilingPowerOfTwo(bufferSize);
            _bufferMask = _bufferSize - 1;

            _faceTrackingDataBuffer = new FaceTrackingData[_bufferSize];
            for (var i = 0; i < _faceTrackingDataBuffer.Length; i++)
            {
                _faceTrackingDataBuffer[i] = new FaceTrackingData();
            }
        }

        public void SetFaceExpressions(OVRFaceExpressions faceExpressions)
        {
            _faceExpressions = faceExpressions;
        }

        public void Tick()
        {
            if (_faceExpressions is null) return;

            if (_faceExpressions.FaceTrackingEnabled && _faceExpressions.ValidExpressions)
            {
                var bufferFreeCount = _bufferSize - (int)(_bufferTail - _bufferHead);
                if (bufferFreeCount <= 0) return;

                var bufferIndex = _bufferTail & _bufferMask;
                _bufferTail++;

                var expressionCount = (int)OVRFaceExpressions.FaceExpression.Max;
                for (var expressionIndex = 0; expressionIndex < expressionCount; expressionIndex++)
                {
                    var expression = (OVRFaceExpressions.FaceExpression)expressionIndex;
                    var blendShapeIndex = (int)FaceTrackingUtility.GetBlendShapeName(expression);
                    if (blendShapeIndex >= 0)
                    {
                        var value = _faceExpressions[expression];
                        _faceTrackingDataBuffer[bufferIndex].BlendShapeValues[blendShapeIndex] = (short)(_scaleFactor * value);
                    }
                }
            }
        }

        public bool TryDequeue(ref FaceTrackingData faceTrackingData)
        {
            if (_bufferHead >= _bufferTail) return false;

            var index = _bufferHead & _bufferMask;
            _faceTrackingDataBuffer[index].CopyTo(faceTrackingData);

            _bufferHead++;
            return true;
        }

        /// <summary>
        /// Returns the smallest power of two that is greater than or equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int CeilingPowerOfTwo(int value)
        {
            var power = (int)Math.Ceiling(Math.Log(value, 2));
            return (int)Math.Pow(2, power);
        }
    }
}