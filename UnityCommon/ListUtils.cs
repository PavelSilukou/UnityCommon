using System.Collections.Generic;
using System.Linq;

namespace UnityCommon
{
    public static class ListUtils
    {
        public static List<T> InitList<T>(int count, T value)
        {
            var list = new List<T>();
            for (var i = 0; i < count; i++)
            {
                list.Add(value);
            }

            return list;
        }

        public static bool Equals<T>(List<T> list1, List<T> list2)
        {
            var firstNotSecond = list1.Except(list2);
            var secondNotFirst = list2.Except(list1);
            return list1.Count == list2.Count && !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        public static bool EqualsWithOrder<T>(List<T> list1, List<T> list2)
        {
            return list1.Count == list2.Count && list1.Intersect(list2).SequenceEqual(list2);
        }
    }
}