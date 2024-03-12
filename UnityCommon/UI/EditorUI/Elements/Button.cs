using UnityEngine;
using UnityEngine.Events;

namespace UnityCommon.UI.EditorUI.Elements
{
    public class Button : Element
    {
        public UnityEvent Clicked { get; } = new UnityEvent();
        
        private readonly string _text;
        private readonly float _width = -1.0f;
        
        public Button(string text)
        {
            _text = text;
        }
        
        public Button(string text, float width)
        {
            _text = text;
            _width = width;
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
            return 150;
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
            UnityEngine.GUI.Button(drawRect, _text);
        }

        protected override void Changed()
        {
            Clicked.Invoke();
            base.Changed();
        }
    }
}
