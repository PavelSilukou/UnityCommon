// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using UnityEngine;

namespace UnityCommon
{
    public static class Vector2Extensions
    {
        public static Vector3 ToYVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, 0.0f, vector.y);
        }
    }
}
