using UnityEngine;

namespace UnityCommon
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        public virtual void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this as T;
            }
        }

        public virtual void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}