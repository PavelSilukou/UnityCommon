// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using UnityEngine;

namespace UnityCommon
{
	public static class Vector2Utils
	{
		public static Vector2 RotateRad(float radians)
		{
			return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
		}
		
		public static Vector2 RotateRad(Vector2 vector, float radians)
		{
			var cos = Mathf.Cos(radians);
			var sin = Mathf.Sin(radians);
			var x = vector.x * cos - vector.y * sin;
			var y = vector.x * sin + vector.y * cos;
			return new Vector2(x, y);
		}
		
		public static Vector2 RotateDeg(float degrees)
		{
			var radians = degrees * Mathf.Deg2Rad;
			return RotateRad(radians);
		}
		
		public static Vector2 RotateDeg(Vector2 vector, float degrees)
		{
			var radians = degrees * Mathf.Deg2Rad;
			return RotateRad(vector, radians);
		}
		
		public static float AngleRad360(Vector2 vector1, Vector2 vector2, int direction)
		{
			var y = vector1.y * vector2.x - vector1.x * vector2.y;
			var x = vector1.x * vector2.x + vector1.y * vector2.y;
			return Mathf.Atan2(-y, -x) + Mathf.Sign(direction) * Mathf.PI;
		}
		
		public static float AngleDeg360(Vector2 vector1, Vector2 vector2, int direction)
		{
			var radians = AngleRad360(vector1, vector2, direction);
			return radians * Mathf.Rad2Deg;
		}
		
		public static bool IsParallel(Vector2 vector1, Vector2 vector2, float threshold = 0.001f)
		{
			var dot = Vector2.Dot(vector1.normalized, vector2.normalized);
			return 1 - Mathf.Abs(dot) <= threshold;
		}

		public static Vector2 PointProjectionOnLine(Vector2 point, Vector2 linePoint1, Vector2 linePoint2)
		{
			var vector1 = linePoint2 - linePoint1;
			var vector2 = point - linePoint1;
			return linePoint1 + vector1 * Vector2.Dot(vector1, vector2) / Vector2.Dot(vector1, vector1);
		}

		public static bool PointProjectionOnLineSegment(
			out Vector2? projection,
			Vector2 point,
			Vector2 lineSegmentPoint1,
			Vector2 lineSegmentPoint2)
		{
			var projectionOnLine = PointProjectionOnLine(point, lineSegmentPoint1, lineSegmentPoint2);
			var dx = lineSegmentPoint2.x - lineSegmentPoint1.x;
			var dy = lineSegmentPoint2.y - lineSegmentPoint1.y;
			var innerProduct = (projectionOnLine.x - lineSegmentPoint1.x) * dx + (projectionOnLine.y - lineSegmentPoint1.y) * dy;
			var isProject = 0 <= innerProduct && innerProduct <= dx * dx + dy * dy;

			projection = isProject ? projectionOnLine : null;
			return isProject;
		}
	}
}