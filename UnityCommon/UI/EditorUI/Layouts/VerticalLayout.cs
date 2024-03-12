using System.Linq;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Layouts
{
    public class VerticalLayout : Layout
    {
        private readonly float _width = -1.0f;
        private const float VerticalSpace = 3.0f;
        
        public VerticalLayout()
        {
        }
        
        public VerticalLayout(float width)
        {
            _width = Mathf.Clamp(width, GetMinWidth(), GetMaxWidth());
        }

        public override Rect GetDrawRect(Rect parentRect)
        {
            var targetWidth = FloatUtils.EqualsApproximately(_width, -1.0f, 0.0001f) ? parentRect.width : _width;
            var ownRect = new Rect(parentRect.x, parentRect.y, targetWidth, parentRect.height);
            if (Elements.Count == 0) return ownRect;
            
            var maxWidth = Elements.Select(el => el.GetDrawRect(ownRect)).Select(rect => rect.width).Max();

            var totalHeight = 0.0f;
            
            var element = Elements[0];
            var elementRect = element.GetDrawRect(new Rect(ownRect.x, ownRect.y, maxWidth, ownRect.height));
            AddElementRect(element, elementRect);
            totalHeight += elementRect.height;
            
            var nextY = elementRect.height;
            for (var i = 1; i < Elements.Count; i++)
            {
                element = Elements[i];
                elementRect = element.GetDrawRect(new Rect(ownRect.x, ownRect.y + nextY + VerticalSpace, maxWidth, ownRect.height));
                AddElementRect(element, elementRect);
                totalHeight += elementRect.height;
                nextY += elementRect.height + VerticalSpace;
            }
            
            maxWidth = Mathf.Clamp(maxWidth, GetMinWidth(), GetMaxWidth());
            ownRect.width = maxWidth;
            
            totalHeight = Mathf.Clamp(totalHeight, GetMinHeight(), GetMaxHeight());
            ownRect.height = totalHeight;

            return ownRect; 
        }

        protected override void Repaint(Rect drawRect)
        {
            DrawElements();
        }
    }
}
