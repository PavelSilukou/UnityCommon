using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityCommon
{
    public static class ListExtensions
    {
        public static T GetElementByTypeName<T>(this List<T> list, string typeName)
        {
            return list.Find(el => el!.GetType().Name.Equals(typeName));
        }

        public static T GetElementByType<T>(this List<T> list, Type type)
        {
            return list.Find(el => el!.GetType() == type);
        }

        public static T PopAt<T>(this List<T> list, int index)
        {
            var element = list[index];
            list.RemoveAt(index);
            return element;
        }

        public static IEnumerable<int> IndexesOf<T>(this List<T> list, T value)
        {
            return Enumerable.Range(0, list.Count).Where(i => list[i]!.Equals(value)).ToList();
        }

        public static IEnumerable<int> IndexesOf<T>(this List<T> list, List<T> values)
        {
            return Enumerable.Range(0, list.Count).Where(i => values.Contains(list[i])).ToList();
        }

        public static void RemoveLast<T>(this List<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }
        
        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {
            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
        
        public static void Move<T>(this List<T> list, T item, int newIndex)
        {
            var oldIndex = list.IndexOf(item);
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
    }
}
