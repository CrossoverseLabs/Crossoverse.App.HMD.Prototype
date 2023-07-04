using System;

namespace Crossoverse.HMDApp.Quest.Domain.FaceTracking
{
    public sealed class FaceTrackingData
    {
        public static readonly int BlendShapeCount = (int)BlendShapeName.blendShapeCount;

        /// <summary>
        /// The value of a BlendShape is expressed as an integer value in the range of 0 to 100.
        /// </summary>
        public short[] BlendShapeValues => _blendShapeValues;
        internal readonly short[] _blendShapeValues = new short[BlendShapeCount];

        public void CopyTo(FaceTrackingData trackingData)
        {
            Array.Copy(_blendShapeValues, trackingData._blendShapeValues, BlendShapeCount);
        }
    }
}