using System;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace UnityCommon.UI.EditorUI.Elements
{
    public class ToggleGroup : Element
    {
        public UnityEvent<int> ToggleIsSelected { get; } = new UnityEvent<int>();

        private List<string> _texts;
        private int _selectedToggleIndex;
        private readonly float _width = -1.0f;

        public ToggleGroup()
        {
            _texts = new List<string>();
        }
        
        public ToggleGroup(List<string> texts)
        {
            _texts = texts;
        }
        
        public ToggleGroup(List<string> texts, float width) : this(texts)
        {
            _width = width;
        }

        public void SelectItem(int itemIndex)
        {
            _selectedToggleIndex = MathUtils.Clamp(itemIndex, 0, _texts.Count - 1);
            if (_selectedToggleIndex != itemIndex) ToggleIsSelected.Invoke(_selectedToggleIndex);
        }
        
        public void SetItems(List<string> texts)
        {
            _texts = texts;
            var oldSelectedToggleIndex = _selectedToggleIndex;
            _selectedToggleIndex = MathUtils.Clamp(_selectedToggleIndex, 0, _texts.Count - 1);
            if (_selectedToggleIndex != oldSelectedToggleIndex) ToggleIsSelected.Invoke(_selectedToggleIndex);
        }

        public override Rect GetDrawRect(Rect parentRect)
        {
            var targetWidth = FloatUtils.EqualsApproximately(_width, -1.0f, 0.0001f) ? parentRect.width : _width;
            targetWidth = Mathf.Clamp(targetWidth, GetMinWidth(), GetMaxWidth());
            return new Rect(parentRect.x, parentRect.y, targetWidth, GetMaxHeight());
        }

        protected override float GetMinWidth()
        {
            return 50;
        }

        protected override float GetMaxWidth()
        {
            return 150;
        }

        protected override float GetMinHeight()
        {
            return 24;
        }

        protected override float GetMaxHeight()
        {
            return 20 * _texts.Count;
        }

        protected override void Repaint(Rect drawRect)
        {
            _selectedToggleIndex = UnityEngine.GUI.SelectionGrid(drawRect, _selectedToggleIndex, _texts.ToArray(), 1, new GUIStyle(UnityEngine.GUI.skin.toggle));
        }

        protected override void Changed()
        {
            base.Changed();
            ToggleIsSelected.Invoke(_selectedToggleIndex);
        }
        
        public override void Save(JArray array)
        {
            var obj = new JObject {{"ToggleIndex", _selectedToggleIndex}};
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
                    _selectedToggleIndex = (int)(obj["ToggleIndex"] ?? throw new InvalidOperationException());
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