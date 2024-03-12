using System.Linq;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Layouts
{
    public class HorizontalLayout : Layout
    {
        private readonly float _height = -1.0f;
        private const float HorizontalSpace = 3.0f;
        
        public HorizontalLayout()
        {
        }
        
        public HorizontalLayout(float height)
        {
            _height = Mathf.Clamp(height, GetMinHeight(), GetMaxHeight());
        }

        public override Rect GetDrawRect(Rect parentRect)
        {
            var targetHeight = FloatUtils.EqualsApproximately(_height, -1.0f, 0.0001f) ? parentRect.height : _height;
            var ownRect = new Rect(parentRect.x, parentRect.y, parentRect.width, targetHeight);
            if (Elements.Count == 0) return ownRect;
            
            var maxHeight = Elements.Select(el => el.GetDrawRect(ownRect)).Select(rect => rect.height).Max();

            var totalWidth = 0.0f;
            
            var element = Elements[0];
            var elementRect = element.GetDrawRect(new Rect(0, 0, ownRect.width, maxHeight));
            AddElementRect(element, elementRect);
            totalWidth += elementRect.width;
            
            var nextX = elementRect.width;
            for (var i = 1; i < Elements.Count; i++)
            {
                element = Elements[i];
                elementRect = element.GetDrawRect(new Rect(nextX + HorizontalSpace, 0, ownRect.width, maxHeight));
                AddElementRect(element, elementRect);
                totalWidth += elementRect.width;
                nextX += elementRect.width + HorizontalSpace;
            }
            
            totalWidth = Mathf.Clamp(totalWidth, GetMinWidth(), GetMaxWidth());
            ownRect.width = totalWidth;

            maxHeight = Mathf.Clamp(maxHeight, GetMinHeight(), GetMaxHeight());
            ownRect.height = maxHeight;

            return ownRect; 
        }

        protected override void Repaint(Rect drawRect)
        {
            DrawElements();
        }
    }
}
