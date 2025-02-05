// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using UnityEngine;

namespace UnityCommon
{
    public static class GameObjectUtils
    {
        public static T Instantiate<T>(T original, Transform? parent = null, bool worldPositionStays = false, bool isActive = true) where T : Object
        {
            var obj = Object.Instantiate(original, parent, worldPositionStays);
            obj.name = GameObjectNameManager.Instance().GetName(obj.name);
            
            var monoBehaviour = obj as MonoBehaviour;
            if (monoBehaviour != null) monoBehaviour.gameObject.SetActive(isActive);
            
            return obj;
        }
    }
}
