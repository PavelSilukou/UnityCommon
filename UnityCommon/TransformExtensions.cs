using System.Collections.Generic;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public static class TransformExtensions
    {
        public static void DestroyChildren(this Transform root)
        {
            foreach (Transform child in root) {
                Object.Destroy(child.gameObject);
            }
        }
        
        public static void SetXPosition(this Transform transform, float xPos)
        {
            transform.position = transform.position.SetX(xPos);
        }
        
        public static IEnumerable<Transform> GetMyChildren(this Transform transform)
        {
            var children = new Transform[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                children[i] = child;
            }

            return children;
        }
    }
}