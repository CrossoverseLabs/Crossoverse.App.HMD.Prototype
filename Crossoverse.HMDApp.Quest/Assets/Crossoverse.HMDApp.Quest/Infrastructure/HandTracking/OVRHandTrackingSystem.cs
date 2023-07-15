using Crossoverse.Core.Domain.MotionCapture.HandTracking;

namespace Crossoverse.HMDApp.Quest.Infrastructure.HandTracking
{
    public sealed class OVRHandTrackingSystem : IHandTrackingSystem
    {
        private readonly OVRBody _ovrBody;
        private readonly int[] _boneIds;
        private readonly HandTrackingData _buffer;

        public OVRHandTrackingSystem(OVRBody ovrBody)
        {
            _ovrBody = ovrBody;

            _buffer = new HandTrackingData((int)FingerBone.FingerBoneCount);

            _boneIds = new int[(int)FingerBone.FingerBoneCount];
            for (var i = 0; i < _boneIds.Length; i++)
            {
                _boneIds[i] = (int)HandTrackingUtility.GetOVRBone((FingerBone)(i + (int)FingerBone.FingerBoneStart));
            }

            if (_ovrBody is null) UnityEngine.Debug.LogError($"[{nameof(OVRHandTrackingSystem)}] OVRBody is null.");
        }

        public void Tick()
        {
            if (_ovrBody.BodyState != null)
            {
                var bodyState = _ovrBody.BodyState.Value;

                for (var i = 0; i < _boneIds.Length; i++)
                {
                    var boneId = _boneIds[i];

                    _buffer.Joints[i].Id = (int)HandTrackingUtility.GetFingerBone((OVRPlugin.BoneId)boneId);
                    _buffer.Joints[i].ConfidenceLevel = bodyState.Confidence;

                    // TODO: Position and Rotation
                }
            }
        }

        public bool TryPeek(ref HandTrackingData destination)
        {
            _buffer.CopyTo(ref destination);
            return true;
        }
    }
}
