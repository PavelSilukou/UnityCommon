using UnityEngine;

namespace UnityCommon
{
    public static class MonoBehaviourUtils
    {
        public static bool EqualsByType(MonoBehaviour a, MonoBehaviour b)
        {
            return a.GetType() == b.GetType();
        }
    }
}
