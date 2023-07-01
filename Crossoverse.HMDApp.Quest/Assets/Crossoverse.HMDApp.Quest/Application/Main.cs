using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crossoverse.HMDApp.Quest
{
    public class Main : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadSceneAsync("CameraSystem_Quest", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("ContentStage_Quest", LoadSceneMode.Additive);
        }
    }
}
