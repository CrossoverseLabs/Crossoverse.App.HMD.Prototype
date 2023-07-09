using System.IO;
using Crossoverse.Core.Domain.ResourceProvider;
using Crossoverse.HMDApp.Quest.Context;
using Crossoverse.HMDApp.Quest.Lifecycle;
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

        void Awake()
        {
            _binaryDataProvider = new LocalFileBinaryDataProvider();
            _avatarResourceProvider = new UrpVrmProvider(_binaryDataProvider);
            _avatarContext = new AvatarContext(_avatarResourceProvider, _animatorController);

            if (!ServiceLocator.Instance.TryRegister(_avatarContext))
            {
                Debug.LogError($"[{nameof(Main)}] Failed to register AvatarContext");
            }

            Debug.Log($"[{nameof(Main)}] Initialized");
        }

        async void Start()
        {
            await SceneManager.LoadSceneAsync("OVRSystem", LoadSceneMode.Additive);
            await SceneManager.LoadSceneAsync("ContentStage_Quest", LoadSceneMode.Additive);
            await SceneManager.LoadSceneAsync("MotionCaptureSystem", LoadSceneMode.Additive);

            var filePath = Path.Combine(Application.streamingAssetsPath, "VRM", "VRoid_Male_PerfectSync.vrm");
            await _avatarContext.LoadAvatarResourceAsync(filePath);
        }
    }
}