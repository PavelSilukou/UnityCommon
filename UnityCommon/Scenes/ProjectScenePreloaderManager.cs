using UnityEditor;
using UnityEngine;

namespace UnityCommon.Scenes
{
    public class ProjectScenePreloaderManager : ProjectSceneManager
    {
        [SerializeField] private SceneAsset _nextScene = null!;
        
        private void Start()
        {
            StartCoroutine(LoadNextScene(_nextScene, PreloaderAction));
        }

        protected virtual void PreloaderAction()
        {
            
        }
    }
}
