// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Collections;
using UnityEngine;

namespace UnityCommon
{
    public static class TimeoutUtils
    {
        public static IEnumerator Timeout(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }
}