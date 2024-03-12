using UnityEngine;

namespace UnityCommon
{
	public static class MathUtils
	{
		public static int GetBinomialCoefficient(int n, int i)
		{
			return Factorial(n) / (Factorial(i) * Factorial(n - i));
		}

		public static int Factorial(int i)
		{
			if (i <= 1) return 1;
			return i * Factorial(i - 1);
		}

		public static float GetBernsteinBasisPolynomials(int n, int i, float t)
		{
			return GetBinomialCoefficient(n, i) * Mathf.Pow(t, i) * Mathf.Pow(1 - t, n - i);
		}

		////
		//  Math for Q Bezier Curve
		////
		//public static float GetQInteger(int r, float q)
		//{
		//	if (q == 1.0f) return r;

		//	return (1.0f - Mathf.Pow(q, r)) / (1.0f - q);
		//}

		//public static float GetQFactorial(int r, float q)
		//{
		//	if (r == 0) return 1.0f;
		//	if (r == 1) return GetQInteger(1, q);

		//	return GetQInteger(r, q) * GetQFactorial(r - 1, q);
		//}

		//public static float GetQBinomialCoefficient(int n, int r, float q)
		//{
		//	return GetQFactorial(n, q) / (GetQFactorial(r, q) * GetQFactorial(n - r, q));
		//}

		//public static float GetQBernsteinBasisPolynomials(int n, int i, float q, float t)
		//{
		//	float part1 = GetQBinomialCoefficient(n, i, q) * Mathf.Pow(t, i);

		//	float result = 1.0f;
		//	for (int s = 0; s <= n - i - 1; s++)
		//       {
		//		result *= (1 - Mathf.Pow(q, s) * t);
		//       }

		//	return part1 * result;
		//}

		public static int RepeatPositive(int value, int minValue, int maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue > maxValue)
			{
				targetValue -= length;
			}

			return targetValue;
		}

		public static int RepeatNegative(int value, int minValue, int maxValue)
		{
			var length = maxValue - minValue + 1;
			var targetValue = value;
			while (targetValue < minValue)
			{
				targetValue += length;
			}
			
			return targetValue;
		}

		public static int Repeat(int value, int minValue, int maxValue)
		{
			return value >= minValue
				? RepeatPositive(value, minValue, maxValue)
				: RepeatNegative(value, minValue, maxValue);
		}

		public static int Clamp(int value, int minValue, int maxValue)
		{
			if (value.CompareTo(minValue) < 0) return minValue;
			return value.CompareTo(maxValue) > 0 ? maxValue : value;
		}
	}
}
