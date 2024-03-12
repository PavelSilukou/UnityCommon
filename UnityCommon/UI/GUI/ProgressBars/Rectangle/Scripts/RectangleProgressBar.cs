using UnityEngine;

namespace UnityCommon.UI.GUI.ProgressBars.Rectangle.Scripts
{
    [RequireComponent(typeof(RectangleProgressBarComponents))]
    public class RectangleProgressBar : MonoBehaviour
    {
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue = 5.0f;
        [SerializeField] private string _text = null!;

        private RectangleProgressBarComponents? _components;
        private float _step;
        private float _currentValue;

        private void Start()
        {
            _components = GetComponent<RectangleProgressBarComponents>();
            _step = _components.GetBackgroundRectWidth() / (_maxValue - _minValue);
            _components.SetForegroundRectWidth(0.0f);
            _currentValue = _minValue;
            
            if (string.IsNullOrEmpty(_text) == false)
            {
                _components.SetText(_text);
            }
        }

        public void SetMinValue(float minValue)
        {
            _minValue = minValue;
        }

        public void SetMaxValue(float maxValue)
        {
            _maxValue = maxValue;
        }

        public bool SetValue(float newValue)
        {
            var clampedValue = Mathf.Clamp(newValue, _minValue, _maxValue);
            if (_components != null) _components.SetForegroundRectWidth(clampedValue * _step);
            _currentValue = clampedValue;
            return clampedValue >= _maxValue;
        }

        public void SetText(string newText)
        {
            if (_components != null) _components.SetText(newText);
        }
    }
}
