using System;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityCommon.UI.EditorUI.Layouts;
using UnityEditor;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Windows
{
    public abstract class EditorPlayWindow<T> : EditorWindow, IHasCustomMenu where T : EditorWindow
    {
        private WindowScrollView? _windowScrollView;

        protected static void InitWindow(string title)
        {
            GetWindow(typeof(T), false, title).Show();
        }
        
        protected abstract Layout InitElements();

        protected virtual void BeforeInspectorUpdate()
        {
            
        }

        private void OnEnable()
        {
            var mainLayout = InitElements();
            
            _windowScrollView = new WindowScrollView();
            _windowScrollView.AddElement(mainLayout);
            LoadState();
            _windowScrollView.GetDrawRect(GetWindowRect());
        }
        
        protected virtual void OnInspectorUpdate()
        {
            BeforeInspectorUpdate();
            SaveState();
            _windowScrollView?.GetDrawRect(GetWindowRect());
            Repaint();
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
        
        public void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(new GUIContent("Reset"), false, OnReset);
        }

        private void OnReset()
        {
            EditorPrefs.DeleteKey(GetType().Name);
            OnEnable();
        }
    }
}
