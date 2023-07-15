using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using Crossoverse.Core.Domain.MotionCapture.FaceTracking;
using Crossoverse.Core.Domain.MotionCapture.HandTracking;

namespace Crossoverse.HMDApp.Quest.Context
{
    public sealed class MotionCaptureContext
    {
        private readonly AvatarContext _avatarContext;
        private readonly IFaceTrackingSystem _faceTrackingSystem;
        private readonly IEyeTrackingSystem _eyeTrackingSystem;
        private readonly IHandTrackingSystem _handTrackingSystem;

        private FaceTrackingData _faceTrackingData = new();
        private EyeTrackingData _eyeTrackingData = new();
        private HandTrackingData _handTrackingData = new((int)FingerBone.FingerBoneCount);

        public MotionCaptureContext
        (
            AvatarContext avatarContext,
            IFaceTrackingSystem faceTrackingSystem,
            IEyeTrackingSystem eyeTrackingSystem,
            IHandTrackingSystem handTrackingSystem
        )
        {
            _avatarContext = avatarContext;
            _faceTrackingSystem = faceTrackingSystem;
            _eyeTrackingSystem = eyeTrackingSystem;
            _handTrackingSystem = handTrackingSystem;
        }

        public void Tick()
        {
            if (_faceTrackingSystem.TryDequeue(ref _faceTrackingData))
            {
                _avatarContext.UpdateFacialPose(_faceTrackingData);
            }

            if (_eyeTrackingSystem.TryPeek(ref _eyeTrackingData))
            {
                _avatarContext.UpdateEyePose(_eyeTrackingData);
            }

            if (_handTrackingSystem.TryPeek(ref _handTrackingData))
            {
                _avatarContext.UpdateHandPose(_handTrackingData);
            }
        }
    }
}