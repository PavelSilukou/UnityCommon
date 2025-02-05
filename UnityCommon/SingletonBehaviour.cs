#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable S2223 // Non-constant static fields should not be visible
#pragma warning disable S2696 // Instance members should not write to "static" fields
#pragma warning disable S1104 // Fields should not have public accessibility
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

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