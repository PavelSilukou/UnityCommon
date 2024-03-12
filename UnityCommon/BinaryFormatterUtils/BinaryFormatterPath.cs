using UnityEngine;

namespace UnityCommon.BinaryFormatterUtils
{
    public class BinaryFormatterPath
    {
        private readonly string _targetFile;

        public BinaryFormatterPath(string targetFile)
        {
            _targetFile = targetFile;
        }

        public string GetPath()
        {
            return $"{Application.persistentDataPath}/{_targetFile}";
        }
    }
}