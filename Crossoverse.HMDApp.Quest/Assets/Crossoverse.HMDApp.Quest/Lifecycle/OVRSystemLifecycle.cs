using Crossoverse.Core.Domain.MotionCapture.FaceTracking;
using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using Crossoverse.Core.Domain.MotionCapture.HandTracking;
using Crossoverse.HMDApp.Quest.Infrastructure.FaceTracking;
using Crossoverse.HMDApp.Quest.Infrastructure.EyeTracking;
using Crossoverse.HMDApp.Quest.Infrastructure.HandTracking;
using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Lifecycle
{
    public sealed class OVRSystemLifecycle : MonoBehaviour
    {
        [SerializeField] OVRFaceExpressions _faceExpression;
        [SerializeField] OVREyeGazeManager _eyeGazeManager;
        [SerializeField] OVRBody _body;

        private OVRFaceTrackingSystem _faceTrackingSystem;
        private OVREyeTrackingSystem _eyeTrackingSystem;
        private OVRHandTrackingSystem _handTrackingSystem;

        void Awake()
        {
            _faceTrackingSystem = new();
            _faceTrackingSystem.SetFaceExpressions(_faceExpression);
            _eyeTrackingSystem = new(_eyeGazeManager);
            _handTrackingSystem = new(_body);

            if (!ServiceLocator.Instance.TryRegister<IFaceTrackingSystem>(_faceTrackingSystem))
            {
                Debug.LogError($"[{nameof(OVRSystemLifecycle)}] Failed to register IFaceTrackingSystem");
            }
            if (!ServiceLocator.Instance.TryRegister<IEyeTrackingSystem>(_eyeTrackingSystem))
            {
                Debug.LogError($"[{nameof(OVRSystemLifecycle)}] Failed to register IEyeTrackingSystem");
            }
            if (!ServiceLocator.Instance.TryRegister<IHandTrackingSystem>(_handTrackingSystem))
            {
                Debug.LogError($"[{nameof(OVRSystemLifecycle)}] Failed to register IHandTrackingSystem");
            }


            Debug.Log($"[{nameof(OVRSystemLifecycle)}] Initialized");
        }
    }
}