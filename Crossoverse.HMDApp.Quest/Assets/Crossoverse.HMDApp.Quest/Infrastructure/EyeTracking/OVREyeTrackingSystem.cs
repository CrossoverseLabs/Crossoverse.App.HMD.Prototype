using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Infrastructure.EyeTracking
{
    public sealed class OVREyeTrackingSystem : IEyeTrackingSystem
    {
        private readonly OVREyeGazeManager _eyeGazeManager;
        private readonly Transform _headTransform;
        private readonly EyeTrackingData _eyeTrackingDataBuffer = new();

        public OVREyeTrackingSystem(OVREyeGazeManager eyeGazeManager)
        {
            _eyeGazeManager = eyeGazeManager;
            _headTransform = Camera.main.transform;
        }

        public void Tick()
        {
            if (_eyeGazeManager.LeftEye.EyeTrackingEnabled && _eyeGazeManager.RightEye.EyeTrackingEnabled)
            {
                _eyeTrackingDataBuffer.HeadRotation = _headTransform.rotation;
                _eyeTrackingDataBuffer.LeftEyeLocalRotation = _eyeGazeManager.LeftEye.transform.localRotation;
                _eyeTrackingDataBuffer.RightEyeLocalRotation = _eyeGazeManager.RightEye.transform.localRotation;
            }
        }

        public bool TryPeek(ref EyeTrackingData destination)
        {
            _eyeTrackingDataBuffer.CopyTo(ref destination);
            return true;
        }
    }
}