using UnityEngine;
using UnityEngine.Events;

namespace UnityCommon.UI.Toolbar.Elements
{
    public class IconButton : Element
    {
        public UnityEvent Clicked { get; } = new UnityEvent();
        
        private readonly Texture _texture;
        private readonly float _width;

        public IconButton(Texture texture, float width)
        {
            _texture = texture;
            _width = width;
        }

        protected override void Repaint()
        {
            GUILayout.Button(new GUIContent(_texture), UnityEngine.GUI.skin.FindStyle("toolbarbutton"), GUILayout.Width(_width), GUILayout.ExpandHeight(true));
        }

        protected override void Changed()
        {
            Clicked.Invoke();
            base.Changed();
        }
    }
}