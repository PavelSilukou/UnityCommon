using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityCommon.DontDestroyOnLoadSystem
{
    public class DontDestroyOnLoadTransferTargetScene : MonoBehaviour
    {
        [SerializeField] private SceneAsset _targetScene = null!;

        private bool _isTargetSceneReached;

        public void Awake()
        {
            CheckCurrentScene();
            SceneManager.sceneLoaded += OnNewSceneLoaded;
        }

        public void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnNewSceneLoaded;
        }

        private void CheckCurrentScene()
        {
            _isTargetSceneReached = SceneManager.GetActiveScene().name == _targetScene.name;
        }

        private void OnNewSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (_isTargetSceneReached)
            {
                transform.DestroyChildren();
                Destroy(gameObject);
            }

            CheckCurrentScene();
        }
    }
}