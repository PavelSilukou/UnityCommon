using System;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityCommon.UI.EditorUI.Layouts;
using UnityEditor;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Windows
{
    public abstract class DropdownWindow : EditorWindow
    {
        private WindowScrollView? _windowScrollView;

        public void Init()
        {
            var mainLayout = InitElements();
            
            _windowScrollView = new WindowScrollView();
            _windowScrollView.AddElement(mainLayout);
            LoadState();
            _windowScrollView.GetDrawRect(GetWindowRect());
        }

        protected abstract Layout InitElements();

        private void OnDestroy()
        {
            SaveState();
        }
        
        protected virtual void OnGUI()
        {
            _windowScrollView?.Draw(GetWindowRect());
        }
        
        private Rect GetWindowRect()
        {
            return new Rect(0, 0, position.width, position.height);
        }
        
        protected virtual void SaveWindowState(JArray array)
        {
            
        }

        private void SaveState()
        {
            var isChanged = _windowScrollView != null && _windowScrollView.IsChanged();
            if (!isChanged) return;
            
            var array = new JArray();
            SaveWindowState(array);
            _windowScrollView?.Save(array);
            EditorPrefs.SetString(GetType().Name, array.ToString());
        }

        protected virtual void LoadWindowState(JArray array)
        {
        }

        private void LoadState()
        {
            try
            {
                var array = JArray.Parse(EditorPrefs.GetString(GetType().Name));
                LoadWindowState(array);
                _windowScrollView?.Load(array);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
