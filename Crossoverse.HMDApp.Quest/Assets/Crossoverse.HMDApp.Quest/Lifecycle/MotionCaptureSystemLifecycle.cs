using Crossoverse.Core.Domain.MotionCapture.FaceTracking;
using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using Crossoverse.HMDApp.Quest.Context;
using UnityEngine;
using UnityPlayerLooper;

namespace Crossoverse.HMDApp.Quest.Lifecycle
{
    public sealed class MotionCaptureSystemLifecycle : MonoBehaviour, IPostStartable, IPostLateTickable
    {
        private MotionCaptureContext _motionCaptureContext;
        private AvatarContext _avatarContext;
        private IFaceTrackingSystem _faceTrackingSystem;
        private IEyeTrackingSystem _eyeTrackingSystem;

        void Awake()
        {
            GlobalPlayerLooper.Register(this);
        }

        void IPostStartable.PostStartup()
        {
            Debug.Log($"[{nameof(MotionCaptureSystemLifecycle)}] PostStartup");

            if (!ServiceLocator.Instance.TryGetService<AvatarContext>(out _avatarContext))
            {
                Debug.LogError($"[{nameof(MotionCaptureSystemLifecycle)}] AvatarContext not found");
            }
            if (!ServiceLocator.Instance.TryGetService<IFaceTrackingSystem>(out _faceTrackingSystem))
            {
                Debug.LogError($"[{nameof(MotionCaptureSystemLifecycle)}] IFaceTrackingSystem not found");
            }
            if (!ServiceLocator.Instance.TryGetService<IEyeTrackingSystem>(out _eyeTrackingSystem))
            {
                Debug.LogError($"[{nameof(MotionCaptureSystemLifecycle)}] IEyeTrackingSystem not found");
            }

            if (_avatarContext != null && _faceTrackingSystem != null && _eyeTrackingSystem != null)
            {
                _motionCaptureContext = new(_avatarContext, _faceTrackingSystem, _eyeTrackingSystem);
            };
        }

        void IPostLateTickable.PostLateTick()
        {
            _faceTrackingSystem.Tick();
            _eyeTrackingSystem.Tick();
            _motionCaptureContext.Tick();
        }
    }
}