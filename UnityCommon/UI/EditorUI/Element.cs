using System;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityCommon.UI.EditorUI
{
    public abstract class Element
    {
        private bool _isActive = true;
        private bool _isChanged;

        public void Draw(Rect drawRect)
        {
            EditorGUI.BeginDisabledGroup(_isActive == false);
            EditorGUI.BeginChangeCheck();
            Repaint(drawRect);
            if (EditorGUI.EndChangeCheck())
            {
                Changed();
            }
            EditorGUI.EndDisabledGroup();
        }

        public void SetActive(bool isActive)
        {
            var oldValue = _isActive;
            _isActive = isActive;
            if (oldValue != _isActive)
            {
                _isChanged = true;
            }
        }

        public virtual bool IsChanged()
        {
            return _isChanged;
        }

        public virtual void Save(JArray array)
        {
            var obj = new JObject {{"IsActive", _isActive}};
            array.Add(obj);
            _isChanged = false;
        }
        
        public virtual void Load(JArray array)
        {
            if (array.Count > 0)
            {
                var obj = (JObject)array[0];
                try
                {
                    _isActive = (bool)(obj["IsActive"] ?? throw new InvalidOperationException());
                    array.RemoveAt(0);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            _isChanged = false;
        }

        protected virtual void Changed()
        {
            _isChanged = true;
        }

        public abstract Rect GetDrawRect(Rect parentRect);
        protected abstract float GetMinWidth();
        protected abstract float GetMaxWidth();
        protected abstract float GetMinHeight();
        protected abstract float GetMaxHeight();
        protected abstract void Repaint(Rect drawRect);
    }
}
