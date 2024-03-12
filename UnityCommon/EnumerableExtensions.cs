using System.Collections.Generic;
using System.Linq;

namespace UnityCommon
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            var random = new System.Random();
            var index = random.Next(list.Count);
            return list[index];
        }
        
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }
    }
}
