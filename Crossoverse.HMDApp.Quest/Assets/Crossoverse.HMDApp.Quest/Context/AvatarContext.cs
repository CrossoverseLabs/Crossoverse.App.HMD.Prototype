using System;
using System.Threading.Tasks;
using Crossoverse.Core.Domain.ResourceProvider;
using Crossoverse.HMDApp.Quest.Behaviour.FaceTracking;
using Crossoverse.HMDApp.Quest.Domain.FaceTracking;
using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Context
{
    public sealed class AvatarContext
    {
        public event Action OnLoaded;

        private readonly IAvatarResourceProvider _avatarResourceProvider;
        private readonly RuntimeAnimatorController _runtimeAnimatorController;

        private FaceTrackingTarget _faceTrackingTarget;

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

            _faceTrackingTarget = avatarAnimator.gameObject.AddComponent<FaceTrackingTarget>();
            _faceTrackingTarget.Initialize();

            avatarAnimator.transform.position = new Vector3(0, -1, 1.5f);
            avatarAnimator.transform.eulerAngles = new Vector3(0, 180, 0);

            OnLoaded?.Invoke();
        }

        public void UpdateFacialPose(FaceTrackingData data)
        {
            _faceTrackingTarget?.SetBlendShapes(data);
        }
    }
}