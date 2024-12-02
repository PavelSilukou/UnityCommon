using System.Collections.Generic;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public static class DebugUtils
    {
        public static void DrawCross(Vector3 position, Color color, float duration)
        {
            Debug.DrawLine(position.AddX(-0.2f), position.AddX(0.2f), color, duration);
            Debug.DrawLine(position.AddY(-0.2f), position.AddY(0.2f), color, duration);
            Debug.DrawLine(position.AddZ(-0.2f), position.AddZ(0.2f), color, duration);
        }

        public static void LogList<T>(IEnumerable<T> list)
        {
            foreach (var element in list)
            {
                Debug.Log(element);
            }
        }
        
        public static void LogVector(Vector2 v, int precision = 4)
        {
            Debug.Log(v.ToString($"F{precision}"));
        }

        public static void LogVector(Vector3 v, int precision = 4)
        {
            Debug.Log(v.ToString($"F{precision}"));
        }

        public static void LogSeparator()
        {
            Debug.Log(new string('-', 20));
        }
        
        public static void Log(params object[] array)
        {
            Debug.Log(string.Join("; ", array));
        }
        
        public static void LogArray(object[] array)
        {
            Debug.Log(string.Join("; ", array));
        }
        
        public static void LogArray(object[,] array)
        {
            Debug.Log(StringUtils.Join("; ", array)); 
        }
    }
}
