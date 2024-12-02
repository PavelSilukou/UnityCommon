using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        public static Vector3 AddX(this Vector3 vector, float value)
        {
            return new Vector3(vector.x + value, vector.y, vector.z);
        }

        public static Vector3 AddY(this Vector3 vector, float value)
        {
            return new Vector3(vector.x, vector.y + value, vector.z);
        }

        public static Vector3 AddZ(this Vector3 vector, float value)
        {
            return new Vector3(vector.x, vector.y, vector.z + value);
        }
        
        public static Vector3 Round(this Vector3 vector, int digits)
        {
            return new Vector3(vector.x.Round(digits), vector.y.Round(digits), vector.z.Round(digits));
        }

        public static Vector2 ToXZVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector3 ToWorldPosition(this Vector3 vector, Transform transform)
        {
            var localToWorld = transform.localToWorldMatrix;
            return localToWorld.MultiplyPoint3x4(vector);
        }
        
        public static bool Equals(this Vector3 vector1, Vector3 vector2, float threshold)
        {
            return Vector3.Distance(vector1, vector2) < threshold;
        }

        public static int EqualsByX(this Vector3 vector1, Vector3 vector2, float threshold)
        {
            // 0 - equal
            // 1 - vector1 on the left of vector2
            // -1 - vector1 on the right of vector2

            var diff = vector2.x - vector1.x;
            if (Mathf.Abs(diff) < threshold)
            {
                return 0;
            }

            if (diff > 0)
            {
                return 1;
            }

            if (diff < 0)
            {
                return -1;
            }

            return 0;
        }

        public static int EqualsByZ(this Vector3 vector1, Vector3 vector2, float threshold)
        {
            // 0 - equal
            // -1 - vector1 on the up of vector2
            // 1 - vector1 on the down of vector2

            var diff = vector2.z - vector1.z;
            if (Mathf.Abs(diff) < threshold)
            {
                return 0;
            }

            if (diff > 0)
            {
                return 1;
            }

            if (diff < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}
