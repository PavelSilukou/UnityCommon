// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityCommon
{
    public static class MonoBehaviourExtensions
    {
        public static IEnumerable<T> GetComponentsInMyChildren<T>(this MonoBehaviour monoBehaviour)
        {
            var children = monoBehaviour.transform.GetMyChildren();
            return children.Select(child => child.GetComponent<T>()).ClearNull();
        }

        public static bool HasComponent<T>(this MonoBehaviour monoBehaviour)
        {
            return monoBehaviour.GetComponent<T>() != null;
        }
    }
}