using UnityEditor;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Elements
{
    public class Label : Element
    {
        private string _text;
        private int _lineCount = 1;
        
        public Label(string text)
        {
            _text = text;
        }

        public void SetText(string newText)
        {
            _text = newText;
        }

        public override Rect GetDrawRect(Rect parentRect)
        {
            var targetWidth = Mathf.Clamp(parentRect.width, GetMinWidth(), GetMaxWidth());
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
            return 20;
        }

        protected override float GetMaxHeight()
        {
            return 20 * _lineCount;
        }

        protected override void Repaint(Rect drawRect)
        {
            EditorStyles.label.wordWrap = true;
            EditorStyles.label.CalcMinMaxWidth(new GUIContent(_text), out _, out var maxWidth);
            _lineCount = Mathf.CeilToInt(maxWidth / GetMaxWidth());
            UnityEngine.GUI.Label(drawRect, _text, EditorStyles.label);
            EditorStyles.label.wordWrap = false;
        }

        protected override void Changed()
        {
            
        }
    }
}