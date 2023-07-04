using Crossoverse.HMDApp.Quest.Context;
using Crossoverse.HMDApp.Quest.Infrastructure.FaceTracking;
using UnityEngine;
using UnityPlayerLooper;

namespace Crossoverse.HMDApp.Quest.Lifecycle
{
    public sealed class MotionCaptureSystemLifecycle : MonoBehaviour, IPostStartable, IPostLateTickable
    {
        [SerializeField] OVRFaceExpressions _faceExpression;

        private OVRFaceTrackingSystem _faceTrackingSystem;
        private MotionCaptureContext _motionCaptureContext;

        void Awake()
        {
            GlobalPlayerLooper.Register(this);
        }

        void IPostStartable.PostStartup()
        {
            if (ServiceLocator.Instance.TryGetService<AvatarContext>(out var avatarContext))
            {
                _faceTrackingSystem = new();
                _motionCaptureContext = new(_faceTrackingSystem, avatarContext);
                _faceTrackingSystem.SetFaceExpressions(_faceExpression);
            };
        }

        void IPostLateTickable.PostLateTick()
        {
            _faceTrackingSystem?.Tick();
            _motionCaptureContext?.Tick();
        }
    }
}