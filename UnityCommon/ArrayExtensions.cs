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
    }
}
