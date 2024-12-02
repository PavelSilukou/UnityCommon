using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
	public static class MathfUtils
	{
		public static float RepeatPositive(float value, float minValue, float maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue > maxValue)
			{
				targetValue -= length;
			}

			return targetValue;
		}

		public static float RepeatNegative(float value, float minValue, float maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue < minValue)
			{
				targetValue += length;
			}
			
			return targetValue;
		}

		public static float Repeat(float value, float minValue, float maxValue)
		{
			return value >= minValue
				? RepeatPositive(value, minValue, maxValue)
				: RepeatNegative(value, minValue, maxValue);
		}

		public static float PingPong(float t, float min, float max)
		{
			return min + Mathf.PingPong(t, max - min);
		}
	}
}
