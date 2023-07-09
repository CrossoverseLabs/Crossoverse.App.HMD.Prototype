using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using Crossoverse.Core.Domain.MotionCapture.FaceTracking;

namespace Crossoverse.HMDApp.Quest.Context
{
    public sealed class MotionCaptureContext
    {
        private readonly AvatarContext _avatarContext;
        private readonly IFaceTrackingSystem _faceTrackingSystem;
        private readonly IEyeTrackingSystem _eyeTrackingSystem;

        private FaceTrackingData _faceTrackingData = new();
        private EyeTrackingData _eyeTrackingData = new();

        public MotionCaptureContext
        (
            AvatarContext avatarContext,
            IFaceTrackingSystem faceTrackingSystem,
            IEyeTrackingSystem eyeTrackingSystem
        )
        {
            _avatarContext = avatarContext;
            _faceTrackingSystem = faceTrackingSystem;
            _eyeTrackingSystem = eyeTrackingSystem;
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
        }
    }
}