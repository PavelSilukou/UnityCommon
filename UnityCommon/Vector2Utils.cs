using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
	public static class Vector2Utils
	{
		public static Vector2 Rotate(float angle)
		{
			angle *= Mathf.Deg2Rad;
			return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		}
		
		public static bool Intersection(
			out Vector2 point,
			Vector2 point1,
			Vector2 point2,
			Vector2 point3,
			Vector2 point4)
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
				point = Vector2.zero;
				return false;
			}

			point = new Vector2(nx / d, ny / d);
			return true;
		}
	}
}