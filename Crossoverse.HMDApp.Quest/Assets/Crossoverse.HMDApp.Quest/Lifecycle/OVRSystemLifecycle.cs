using Crossoverse.Core.Domain.MotionCapture.FaceTracking;
using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using Crossoverse.HMDApp.Quest.Infrastructure.FaceTracking;
using Crossoverse.HMDApp.Quest.Infrastructure.EyeTracking;
using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Lifecycle
{
    public sealed class OVRSystemLifecycle : MonoBehaviour
    {
        [SerializeField] OVRFaceExpressions _faceExpression;
        [SerializeField] OVREyeGazeManager _eyeGazeManager;

        private OVRFaceTrackingSystem _faceTrackingSystem;
        private OVREyeTrackingSystem _eyeTrackingSystem;

        void Awake()
        {
            _faceTrackingSystem = new();
            _faceTrackingSystem.SetFaceExpressions(_faceExpression);
            _eyeTrackingSystem = new(_eyeGazeManager);

            if (!ServiceLocator.Instance.TryRegister<IFaceTrackingSystem>(_faceTrackingSystem))
            {
                Debug.LogError($"[{nameof(OVRSystemLifecycle)}] Failed to register IFaceTrackingSystem");
            }
            if (!ServiceLocator.Instance.TryRegister<IEyeTrackingSystem>(_eyeTrackingSystem))
            {
                Debug.LogError($"[{nameof(OVRSystemLifecycle)}] Failed to register IEyeTrackingSystem");
            }

            Debug.Log($"[{nameof(OVRSystemLifecycle)}] Initialized");
        }
    }
}