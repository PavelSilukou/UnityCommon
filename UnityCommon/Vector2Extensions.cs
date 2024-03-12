using UnityEngine;

namespace UnityCommon
{
    public static class Vector2Extensions
    {
        public static Vector2 Rotate(this Vector2 vector, float angle)
        {
            angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }
}
