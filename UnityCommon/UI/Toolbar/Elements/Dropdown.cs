using System;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace UnityCommon.UI.Toolbar.Elements
{
    public class Dropdown : Element
    {
        public UnityEvent<int> ItemIsSelected { get; } = new UnityEvent<int>();
        
        private List<string> _texts;
        private int _selectedIndex;
        private readonly float _width;

        public Dropdown(List<string> texts, float width)
        {
            _texts = texts;
            _width = width;
        }
        
        public void SelectItem(int itemIndex)
        {
            _selectedIndex = MathUtils.Clamp(itemIndex, 0, _texts.Count - 1);
            if (_selectedIndex != itemIndex) ItemIsSelected.Invoke(_selectedIndex);
        }
        
        public void SetItems(List<string> texts)
        {
            _texts = texts;
            var oldSelectedToggleIndex = _selectedIndex;
            _selectedIndex = MathUtils.Clamp(_selectedIndex, 0, _texts.Count - 1);
            if (_selectedIndex != oldSelectedToggleIndex) ItemIsSelected.Invoke(_selectedIndex);
        }

        protected override void Repaint()
        {
            _selectedIndex = EditorGUILayout.Popup(_selectedIndex, _texts.ToArray(), UnityEngine.GUI.skin.FindStyle("toolbarPopup"), GUILayout.Width(_width), GUILayout.ExpandHeight(true));
        }

        protected override void Changed()
        {
            base.Changed();
            ItemIsSelected.Invoke(_selectedIndex);
        }
        
        public override void Save(JArray array)
        {
            var obj = new JObject {{"Index", _selectedIndex}};
            array.Add(obj);
            base.Save(array);
        }

        public override void Load(JArray array)
        {
            if (array.Count > 0)
            {
                var obj = (JObject)array[0];
                try
                {
                    _selectedIndex = (int)(obj["Index"] ?? throw new InvalidOperationException());
                    array.RemoveAt(0);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            
            base.Load(array);
        }
    }
}