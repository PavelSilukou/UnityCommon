using System;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace UnityCommon.UI.EditorUI.Elements
{
    public class Toggle : Element
    {
        public UnityEvent<bool> Clicked { get; } = new UnityEvent<bool>();
        
        private readonly string _text;
        private readonly float _width = -1.0f;
        
        private bool _isToggled;
        
        public Toggle(string text, bool isToggled = false)
        {
            _text = text;
            _isToggled = isToggled;
        }
        
        public Toggle(string text, float width, bool isToggled = false)
        {
            _text = text;
            _width = width;
            _isToggled = isToggled;
        }

        public void Check(bool isChecked)
        {
            var oldValue = _isToggled;
            _isToggled = isChecked;
            if (oldValue != _isToggled) Changed();
        }

        public override Rect GetDrawRect(Rect parentRect)
        {
            var targetWidth = FloatUtils.EqualsApproximately(_width, -1.0f, 0.0001f) ? parentRect.width : _width;
            targetWidth = Mathf.Clamp(targetWidth, GetMinWidth(), GetMaxWidth());
            return new Rect(parentRect.x, parentRect.y, targetWidth, GetMaxHeight());
        }

        protected override float GetMinWidth()
        {
            return 24;
        }

        protected override float GetMaxWidth()
        {
            return 200;
        }

        protected override float GetMinHeight()
        {
            return 24;
        }

        protected override float GetMaxHeight()
        {
            return 24;
        }

        protected override void Repaint(Rect drawRect)
        {
            _isToggled = UnityEngine.GUI.Toggle(drawRect, _isToggled, _text);
        }

        protected override void Changed()
        {
            base.Changed();
            Clicked.Invoke(_isToggled);
        }

        public override void Save(JArray array)
        {
            var obj = new JObject {{"IsToggled", _isToggled}};
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
                    _isToggled = (bool)(obj["IsToggled"] ?? throw new InvalidOperationException());
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