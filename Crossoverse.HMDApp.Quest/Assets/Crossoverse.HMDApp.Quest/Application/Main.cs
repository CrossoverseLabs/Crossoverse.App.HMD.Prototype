using System.IO;
using Crossoverse.Core.Domain.ResourceProvider;
using Crossoverse.HMDApp.Quest.Context;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crossoverse.HMDApp.Quest
{
    public class Main : MonoBehaviour
    {
        [SerializeField] RuntimeAnimatorController _animatorController;

        private IAvatarResourceProvider _avatarResourceProvider;
        private IBinaryDataProvider _binaryDataProvider;

        private AvatarContext _avatarContext;

        async void Start()
        {
            await SceneManager.LoadSceneAsync("CameraSystem_Quest", LoadSceneMode.Additive);
            await SceneManager.LoadSceneAsync("ContentStage_Quest", LoadSceneMode.Additive);

            Initialize();

            var filePath = Path.Combine(Application.streamingAssetsPath, "VRM", "VRoid_Male_PerfectSync.vrm");
            await _avatarContext.LoadAvatarResourceAsync(filePath);
        }

        private void Initialize()
        {
            _binaryDataProvider = new LocalFileBinaryDataProvider();
            _avatarResourceProvider = new UrpVrmProvider(_binaryDataProvider);
            _avatarContext = new AvatarContext(_avatarResourceProvider, _animatorController);
        }
    }
}