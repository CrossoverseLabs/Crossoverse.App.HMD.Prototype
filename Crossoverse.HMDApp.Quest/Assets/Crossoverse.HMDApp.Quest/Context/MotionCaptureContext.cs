using Crossoverse.HMDApp.Quest.Domain.FaceTracking;

namespace Crossoverse.HMDApp.Quest.Context
{
    public sealed class MotionCaptureContext
    {
        private readonly AvatarContext _avatarContext;
        private readonly IFaceTrackingSystem _faceTrackingSystem;

        private FaceTrackingData _faceTrackingData = new();

        public MotionCaptureContext
        (
            IFaceTrackingSystem faceTrackingSystem,
            AvatarContext avatarContext
        )
        {
            _faceTrackingSystem = faceTrackingSystem;
            _avatarContext = avatarContext;
        }

        public void Tick()
        {
            if (_faceTrackingSystem.TryDequeue(ref _faceTrackingData))
            {
                _avatarContext.UpdateFacialPose(_faceTrackingData);
            }
        }
    }
}