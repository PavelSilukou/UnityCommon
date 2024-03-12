using UnityEngine;

namespace UnityCommon
{
    public static class Vector3Utils
    {
        public static Vector3 YNormal(Vector3 v1, Vector3 v2, bool clockwise = true)
        {
            var temp = v1 - v2;
            if (clockwise)
            {
                temp = new Vector3(-temp.z, 0.0f, temp.x);
                return temp.normalized;
            }

            temp = new Vector3(temp.z, 0.0f, -temp.x);
            return temp.normalized;
        }

        public static bool DistanceBetweenVectorsEqual(Vector3 vector1, Vector3 vector2, float distance, float threshold)
        {
            return Vector3.Distance(vector1, vector2) >= distance - threshold
                   && Vector3.Distance(vector1, vector2) <= distance + threshold;
        }
    }
}
