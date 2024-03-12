using TMPro;
using UnityEngine;

namespace UnityCommon.UI.GUI.ProgressBars.Rectangle.Scripts
{
    public class RectangleProgressBarComponents : MonoBehaviour
    {
        [SerializeField] private RectTransform _foregroundRect = null!;
        [SerializeField] private RectTransform _backgroundRect = null!;
        [SerializeField] private TextMeshProUGUI _text = null!;

        public float GetBackgroundRectWidth()
        {
            return _backgroundRect.rect.width;
        }
        
        public void SetForegroundRectWidth(float width)
        {
            _foregroundRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}