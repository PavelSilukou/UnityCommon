using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnityCommon
{
    public static class RegexStringExtensions
    {
        // RegexOptions.IgnoreCase
        public static List<string> GetGroupsValues(this string targetString, string pattern, RegexOptions options)
        {
            var resultStrings = new List<string>();

            var regex = new Regex(pattern, options);
            var match = regex.Match(targetString);
            while (match.Success)
            {
                for (var i = 1; i <= match.Groups.Count; i++)
                {
                    var matchGroup = match.Groups[i];
                    resultStrings.Add(matchGroup.Value);
                }
                match = match.NextMatch();
            }

            return resultStrings;
        }

        // RegexOptions.Multiline
        public static string Replace(this string targetString, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(targetString, pattern, replacement, options);
        }

        public static bool Contains(this string targetString, string pattern)
        {
            var regex = new Regex(pattern);
            var match = regex.Match(targetString);
            return match.Success;
        }
    }
}
