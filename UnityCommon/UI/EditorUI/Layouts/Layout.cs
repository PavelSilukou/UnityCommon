using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Layouts
{
    public abstract class Layout : Element
    {
        protected readonly List<Element> Elements = new List<Element>();
        
        private readonly Dictionary<Element, Rect> _elementsRects = new Dictionary<Element, Rect>();
        
        public virtual void AddElement(Element element)
        {
            Elements.Add(element);
        }

        public override void Save(JArray array)
        {
            foreach (var element in Elements)
            {
                element.Save(array);
            }
            base.Save(array);
        }

        public override void Load(JArray array)
        {
            foreach (var element in Elements)
            {
                element.Load(array);
            }
            base.Load(array);
        }

        protected void AddElementRect(Element element, Rect rect)
        {
            _elementsRects[element] = rect;
        }
        
        protected sealed override float GetMinWidth()
        {
            return 1;
        }

        protected sealed override float GetMaxWidth()
        {
            return 4000;
        }

        protected sealed override float GetMinHeight()
        {
            return 1;
        }

        protected sealed override float GetMaxHeight()
        {
            return 4000;
        }
        
        protected sealed override void Changed()
        {
            
        }

        public override bool IsChanged()
        {
            return Elements.Exists(element => element.IsChanged());
        }

        protected void DrawElements()
        {
            foreach(var elementRect in _elementsRects)
            {
                elementRect.Key.Draw(elementRect.Value);
            }
        }
    }
}