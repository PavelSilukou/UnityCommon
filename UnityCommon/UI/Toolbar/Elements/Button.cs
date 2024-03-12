using UnityEngine;
using UnityEngine.Events;

namespace UnityCommon.UI.Toolbar.Elements
{
    public class Button : Element
    {
        public UnityEvent Clicked { get; } = new UnityEvent();
        
        private readonly string _text;
        private readonly float _width;

        public Button(string text, float width)
        {
            _text = text;
            _width = width;
        }

        protected override void Repaint()
        {
            GUILayout.Button(_text, UnityEngine.GUI.skin.FindStyle("toolbarbutton"), GUILayout.Width(_width), GUILayout.ExpandHeight(true));
        }

        protected override void Changed()
        {
            Clicked.Invoke();
            base.Changed();
        }
    }
}