using System;
using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public class GameObjectNameManager : Singleton<GameObjectNameManager>
    {
        private readonly Dictionary<string, int> _namesDict = new Dictionary<string, int>();

        public string GetName(string oldName)
        {
            if (oldName.Contains("(Clone)") == false) return oldName;
            
            var logicName = oldName[..oldName.LastIndexOf("(Clone)", StringComparison.Ordinal)];
            _namesDict.TryAdd(logicName, 0);

            var newInd = _namesDict[logicName] + 1;
            var newName = $"{logicName}_{newInd}";
            _namesDict[logicName] = newInd;
            return newName;
        }
    }
}