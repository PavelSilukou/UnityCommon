// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System;

namespace UnityCommon
{
    public static class FloatUtils
    {
        public static bool EqualsApproximately(float a, float b, float tolerance = 0.00001f)
        {
            return Math.Abs(a - b) < tolerance;
        }
    }
}