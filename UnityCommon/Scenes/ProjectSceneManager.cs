using System;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace UnityCommon.Scenes
{
    public class ProjectSceneManager : SingletonBehaviour<ProjectSceneManager>
    {
        public bool IsFullyLoaded { get; protected set; }

        protected static IEnumerator LoadNextScene(SceneAsset nextScene, Action? beforeStep = null, Action? afterStep = null)
        {
            beforeStep?.Invoke();

            var loadSceneAsync = SceneManager.LoadSceneAsync(nextScene.name);
            
            afterStep?.Invoke();
            
            while (!loadSceneAsync.isDone)
            {
                yield return null;
            }
        }
    }
}
