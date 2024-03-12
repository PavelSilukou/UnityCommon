using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityCommon.DontDestroyOnLoadSystem
{
    public class DontDestroyOnLoadTransferDuration : MonoBehaviour
    {
        [Tooltip("How many scenes will the object live")]
        [SerializeField] private int _lifeDuration = 1;

        private int _leftLifeDuration;
        private int _lastSceneInd = -1;
        
        public void Awake()
        {
            _leftLifeDuration = _lifeDuration + 1;
            SceneManager.sceneLoaded += OnNewSceneLoaded;
        }
        
        public void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnNewSceneLoaded;
        }
        
        private void OnNewSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (_lastSceneInd == arg0.buildIndex) return;
            
            if (_leftLifeDuration == 0)
            {
                transform.DestroyChildren();
                Destroy(gameObject);
                return;
            }
            
            _lastSceneInd = arg0.buildIndex;
            _leftLifeDuration -= 1;
        }
    }
}