using System;
using System.Threading.Tasks;
using Crossoverse.Core.Behaviour.MotionCapture.EyeTracking;
using Crossoverse.Core.Behaviour.MotionCapture.FaceTracking;
using Crossoverse.Core.Domain.MotionCapture.EyeTracking;
using Crossoverse.Core.Domain.MotionCapture.FaceTracking;
using Crossoverse.Core.Domain.ResourceProvider;
using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Context
{
    public sealed class AvatarContext
    {
        public event Action OnLoaded;

        private readonly IAvatarResourceProvider _avatarResourceProvider;
        private readonly RuntimeAnimatorController _runtimeAnimatorController;

        private FaceTrackingTarget _faceTrackingTarget;
        private EyeTrackingTarget _eyeTrackingTarget;

        public AvatarContext
        (
            IAvatarResourceProvider avatarResourceProvider,
            RuntimeAnimatorController animatorController
        )
        {
            _avatarResourceProvider = avatarResourceProvider;
            _runtimeAnimatorController = animatorController;
        }

        public async Task LoadAvatarResourceAsync(string path)
        {
            var avatarAnimator = await _avatarResourceProvider.LoadAsync(path);

            avatarAnimator.runtimeAnimatorController = _runtimeAnimatorController;

            avatarAnimator.transform.position = new Vector3(0, -1, 1.5f);
            avatarAnimator.transform.eulerAngles = new Vector3(0, 180, 0);

            _faceTrackingTarget = avatarAnimator.gameObject.AddComponent<FaceTrackingTarget>();
            _faceTrackingTarget.Initialize();

            _eyeTrackingTarget = avatarAnimator.gameObject.AddComponent<EyeTrackingTarget>();
            _eyeTrackingTarget.Initialize();

            OnLoaded?.Invoke();
        }

        public void UpdateFacialPose(FaceTrackingData data)
        {
            _faceTrackingTarget?.SetBlendShapes(data);
        }

        public void UpdateEyePose(in EyeTrackingData data)
        {
            _eyeTrackingTarget?.SetRotation(data);
        }
    }
}