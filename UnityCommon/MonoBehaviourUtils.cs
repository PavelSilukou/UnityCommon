using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

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
