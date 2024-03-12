using UnityEditor;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Windows
{
    public abstract class OnlyEditorWindow<T> : EditorPlayWindow<T> where T : EditorWindow
    {
        protected override void OnInspectorUpdate()
        {
            if (Application.isPlaying || EditorApplication.isPlaying) return;
            base.OnInspectorUpdate();
        }
        
        protected override void OnGUI()
        {
            if (Application.isPlaying || EditorApplication.isPlaying) return;
            base.OnGUI();
        }
    }
}
