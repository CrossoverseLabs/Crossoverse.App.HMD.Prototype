using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Infrastructure.EyeTracking
{
    public sealed class OVREyeGazeManager : MonoBehaviour
    {
        [SerializeField] float _confidenceThreshold = 0.5f;
        [SerializeField] OVREyeGaze _eyeGazeLeft;
        [SerializeField] OVREyeGaze _eyeGazeRight;

        public OVREyeGaze LeftEye => _eyeGazeLeft;
        public OVREyeGaze RightEye => _eyeGazeRight;

        void Awake()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;

            _eyeGazeLeft.transform.position = Vector3.zero;
            _eyeGazeLeft.transform.rotation = Quaternion.identity;

            _eyeGazeRight.transform.position = Vector3.zero;
            _eyeGazeRight.transform.rotation = Quaternion.identity;

            _eyeGazeLeft.Eye = OVREyeGaze.EyeId.Left;
            _eyeGazeRight.Eye = OVREyeGaze.EyeId.Right;

            _eyeGazeLeft.TrackingMode = OVREyeGaze.EyeTrackingMode.HeadSpace;
            _eyeGazeRight.TrackingMode = OVREyeGaze.EyeTrackingMode.HeadSpace;

            _eyeGazeLeft.ReferenceFrame = null;
            _eyeGazeRight.ReferenceFrame = null;

            _eyeGazeLeft.ApplyPosition = false;
            _eyeGazeRight.ApplyPosition = false;

            _eyeGazeLeft.ApplyRotation = true;
            _eyeGazeRight.ApplyRotation = true;

            _eyeGazeLeft.ConfidenceThreshold = _confidenceThreshold;
            _eyeGazeRight.ConfidenceThreshold = _confidenceThreshold;
        }

        public void SetConfidenceThreshold(float value)
        {
            _eyeGazeLeft.ConfidenceThreshold = value;
            _eyeGazeRight.ConfidenceThreshold = value;
        }
    }
}