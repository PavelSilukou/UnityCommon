// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
#pragma warning disable S107 // Methods should not have too many parameters
#pragma warning disable S1125 // Boolean literals should not be redundant

using UnityEngine;

namespace UnityCommon
{
	public static class IntersectionUtils
	{
		public static bool Line2ToLine2Intersection(
			out Vector2 point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4
			)
		{
			var nx = (point1.x * point2.y - point1.y * point2.x) 
				* (point3.x - point4.x) - (point1.x - point2.x) 
				* (point3.x * point4.y - point3.y * point4.x);
			var ny = (point1.x * point2.y - point1.y * point2.x) 
				* (point3.y - point4.y) - (point1.y - point2.y) 
				* (point3.x * point4.y - point3.y * point4.x);
			var d= (point1.x - point2.x) 
			       * (point3.y - point4.y) 
			       - (point1.y - point2.y) 
			       * (point3.x - point4.x);
			
			if (FloatUtils.EqualsApproximately(d, 0.0f))
			{
				point = Vector2.positiveInfinity;
				return false;
			}

			point = new Vector2(nx / d, ny / d);
			return true;
		}
		
		public static bool Segment2ToSegment2Intersection(
			out Vector2 point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4
			)
		{
			point = Vector2.positiveInfinity;
			
			var isParallel = Vector2Utils.IsParallel(point2 - point1, point4 - point3);
			if (isParallel)
			{
				return false;
			}
			
			float x1 = point1.x, y1 = point1.y;
			float x2 = point2.x, y2 = point2.y;
			float x3 = point3.x, y3 = point3.y;
			float x4 = point4.x, y4 = point4.y;
			
			var s1X = x2 - x1;
			var s1Y = y2 - y1;
			var s2X = x4 - x3;
			var s2Y = y4 - y3;

			var denominator = -s2X * s1Y + s1X * s2Y;
			var s = (-s1Y * (x1 - x3) + s1X * (y1 - y3)) / denominator;
			var t = ( s2X * (y1 - y3) - s2Y * (x1 - x3)) / denominator;

			if (s is < 0 or > 1 || t is < 0 or > 1) return false;
			point = new Vector2(x1 + t * s1X, y1 + t * s1Y);
			return true;
		}
		
		public static bool Line3ToLine3Intersection(
			out Vector3 intersection,
			Vector3 point1,
			Vector3 point2,
			Vector3 point3,
			Vector3 point4
			)
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
            
			intersection = Vector3.positiveInfinity;
			return false;
		}
		
		public static bool IsCircleToCircleIntersect(
			Vector2 center1,
			float radius1,
			Vector2 center2,
			float radius2
		)
		{
			return Vector2.Distance(center1, center2) <= radius1 + radius2;
		}
		
		public static bool CircleToCircleIntersection(
			out Vector2 intersection1, 
			out Vector2 intersection2, 
			Vector2 center1,
			float radius1, 
			Vector2 center2, 
			float radius2
			)
		{
			if (IsCircleToCircleIntersect(center1, radius1, center2, radius2) == false)
			{
				intersection1 = Vector2.positiveInfinity;
				intersection2 = Vector2.positiveInfinity;
				return false;
			}
			
			var x1 = center1.x;
			var x2 = center2.x;
			var y1 = center1.y;
			var y2 = center2.y;
			
			var r = Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2));
			var r2 = r * r;
			var r4 = r2 * r2;
			var k = radius1 * radius1 - radius2 * radius2;
			var k2 = k * k;
			var j = radius1 * radius1 + radius2 * radius2;

			var sqrt = Mathf.Sqrt(2 * j / r2 - k2 / r4 - 1);
			var xPart1 = (x1 + x2) / 2 + k / (2 * r2) * (x2 - x1);
			var xPart2 = sqrt / 2 * (y2 - y1);
			var yPart1 = (y1 + y2) / 2 + k / (2 * r2) * (y2 - y1);
			var yPart2 = sqrt / 2 * (x1 - x2);
			
			var x00 = xPart1 + xPart2;
			var x01 = xPart1 - xPart2;
			var y00 = yPart1 + yPart2;
			var y01 = yPart1 - yPart2;

			intersection1 = new Vector2(x00, y00);
			intersection2 = new Vector2(x01, y01);
			return true;
		}
		
		public static bool ArcToArcIntersection(
			out Vector2 intersection1, 
			out Vector2 intersection2, 
			Vector2 center1,
			float radius1, 
			Vector2 center2, 
			float radius2,
			Vector2 arc1Point,
			float arc1AngleDeg // signed angle: minus - counterclockwise; plus - clockwise
			)
		{
			intersection1 = Vector2.positiveInfinity;
			intersection2 = Vector2.positiveInfinity;
			var isIntersect = false;
			
			var circlesIntersection = CircleToCircleIntersection(
				out var circlesIntersection1, 
				out var circlesIntersection2,
				center1, 
				radius1, 
				center2, 
				radius2);
			
			if (circlesIntersection == false)
			{
				return isIntersect;
			}

			var angleSign = (int)Mathf.Sign(arc1AngleDeg);
			var anglePoint1 = Vector2Utils.AngleDeg360(arc1Point - center1, circlesIntersection1 - center1, angleSign);
			var anglePoint2 = Vector2Utils.AngleDeg360(arc1Point - center1, circlesIntersection2 - center1, angleSign);
			
			if (Mathf.Abs(anglePoint1) < Mathf.Abs(arc1AngleDeg))
			{
				intersection1 = circlesIntersection1;
				isIntersect = true;
			}
			if (Mathf.Abs(anglePoint2) < Mathf.Abs(arc1AngleDeg))
			{
				intersection2 = circlesIntersection2;
				isIntersect = true;
			}
			
			return isIntersect;
		}
	}
}