using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityCommon
{
    public static class TextAssetExtensions
    {
        public static List<string> ReadLines(this TextAsset textAsset)
        {
            var text = textAsset.text;
            return text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
