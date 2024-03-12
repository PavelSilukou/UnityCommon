using UnityEngine;

namespace UnityCommon.DontDestroyOnLoadSystem
{
    public class DontDestroyOnLoadRoot : MonoBehaviour
    {
        private bool _isAwakeOnce;

        public void Awake()
        {
            if (_isAwakeOnce)
            {
                CombineRoots(this);
                Destroy(this);
            }
            else
            {
                _isAwakeOnce = true;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void CombineRoots(Component from)
        {
            foreach (Transform child in from.transform)
            {
                child.parent = transform;
            }
        }
    }
}
