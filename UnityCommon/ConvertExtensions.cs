using System;

namespace UnityCommon
{
    public static class ConvertExtensions
    {
        public static T GetValue<T>(this object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}