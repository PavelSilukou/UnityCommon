using System.Linq;
using UnityEngine;

namespace UnityCommon.UI.EditorUI.Layouts
{
    public class WindowScrollView : Layout
    {
        private Vector2 _scrollPosition = Vector2.zero;
        private const float WindowPadding = 3.0f;
        private Rect _viewRect;

        public override Rect GetDrawRect(Rect parentRect)
        {
            if (Elements.Count == 0) return parentRect;

            parentRect = new Rect(parentRect.x + WindowPadding, parentRect.y + WindowPadding,
                parentRect.width - WindowPadding * 2, parentRect.height - WindowPadding * 2);

            var maxWidth = Elements.Select(el => el.GetDrawRect(parentRect)).Select(rect => rect.width).Max();
            var totalHeight = 0.0f;

            foreach (var element in Elements)
            {
                var elementRect = element.GetDrawRect(new Rect(parentRect.x, parentRect.y, maxWidth, parentRect.height));
                AddElementRect(element, elementRect);
                totalHeight = Mathf.Max(totalHeight, elementRect.height);
            }
            
            maxWidth += WindowPadding * 2;
            maxWidth = Mathf.Clamp(maxWidth, GetMinWidth(), GetMaxWidth());
            totalHeight += WindowPadding * 2;
            totalHeight = Mathf.Clamp(totalHeight, GetMinHeight(), GetMaxHeight());

            _viewRect = new Rect(parentRect.x - WindowPadding, parentRect.y - WindowPadding, maxWidth, totalHeight);

            return parentRect;
        }

        protected override void Repaint(Rect drawRect)
        {
            _scrollPosition = UnityEngine.GUI.BeginScrollView(drawRect, _scrollPosition, _viewRect, true, true);
            DrawElements();
            UnityEngine.GUI.EndScrollView();
        }
    }
}
