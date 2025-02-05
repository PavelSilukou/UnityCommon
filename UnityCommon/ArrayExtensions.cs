// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Collections.Generic;

namespace UnityCommon
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> GetRow<T>(this T[,] array, int rowIndex)
        {
            var columnsCount = array.GetLength(1);
            for (var colIndex = 0; colIndex < columnsCount; colIndex++)
                yield return array[rowIndex, colIndex];
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            var list = new List<T>(source);
            list.RemoveAt(index);
            return list.ToArray();
        }
    }
}
