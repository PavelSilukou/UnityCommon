using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public static class DictionaryExtensions
    {
        public static void AddToListValue<T, TU>(this Dictionary<T, List<TU>> dict, T key, TU value)
        {
            if (dict.TryGetValue(key, out var items))
            {
                items.Add(value);
            }
            else
            {
                dict.Add(key, new List<TU> { value });
            }
        }
    }
}
