// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System.Collections.Generic;
using System.Linq;

namespace UnityCommon
{
    public static class LinqUtils
    {
        public static IEnumerable<(TOne Element1, TTwo Element2)> GetAllPairs<TOne, TTwo>(IEnumerable<TOne> source, IList<TTwo> target)
        {
            return source.SelectMany(s => target.Select(t => (s, t)));
        }
    }
}