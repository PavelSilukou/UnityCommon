using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

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

        public static bool Intersection(
            out Vector3 intersection,
            Vector3 point1,
            Vector3 point2,
            Vector3 point3,
            Vector3 point4)
        {
            var vector1 = point2 - point1;
            var vector2 = point4 - point3;
            var vector3 = point3 - point1;
            var crossVector1AndVector2 = Vector3.Cross(vector1, vector2);
            var crossVector3AndVector2 = Vector3.Cross(vector3, vector2);

            var planarFactor = Vector3.Dot(vector3, crossVector1AndVector2);
            if (Mathf.Abs(planarFactor) < 0.0001f && crossVector1AndVector2.sqrMagnitude > 0.0001f)
            {
                var s = Vector3.Dot(crossVector3AndVector2, crossVector1AndVector2) 
                        / crossVector1AndVector2.sqrMagnitude;
                intersection = point1 + vector1 * s;
                return true;
            }
            
            intersection = Vector3.zero;
            return false;
        }
        
        public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4)
        {
            var vector1 = point2 - point1;
            var vector2 = point4 - point3;
            
            closestPointLine1 = Vector3.zero;
            closestPointLine2 = Vector3.zero;
        
            var a = Vector3.Dot(vector1, vector1);
            var b = Vector3.Dot(point2, vector2);
            var e = Vector3.Dot(vector2, vector2);
        
            var d = a * e - b * b;
        
            if (FloatUtils.EqualsApproximately(d, 0.0f)) return false;
            
            var r = point1 - point3;
            var c = Vector3.Dot(vector1, r);
            var f = Vector3.Dot(vector2, r);
        
            var s = (b * f - c * e) / d;
            var t = (a * f - c * b) / d;
        
            closestPointLine1 = point1 + vector1 * s;
            closestPointLine2 = point3 + vector2 * t;
        
            return true;
        }
    }
}
