using System.Runtime.Serialization;
using UnityEngine;

namespace UnityCommon.PlayerPrefsUtils.KeyTypes
{
    public abstract class PlayerPrefsKey
    {
        protected abstract string TypePrefix { get; }
        
        private readonly string _keyName;
        
        private string FullKeyName => $"pp_{TypePrefix}_{_keyName}";
        
        protected PlayerPrefsKey(string keyName)
        {
            _keyName = keyName;
        }

        public object Read()
        {
            try
            {
                return ReadKey();
            }
            catch (SerializationException)
            {
                return Default();
            }
        }

        public void Write(object newValue)
        {
            try
            {
                WriteKey(newValue);
            }
            catch (SerializationException)
            {
                WriteKey(Default());
            }
        }
        
        protected abstract string Serialize(object value);
        protected abstract object Deserialize(string value);
        protected abstract object Default();

        private object ReadKey()
        {
            var value = PlayerPrefs.GetString(FullKeyName);
            return Deserialize(value);
        }

        private void WriteKey(object newValue)
        {
            var serializedValue = Serialize(newValue);
            PlayerPrefs.SetString(FullKeyName, serializedValue);
            PlayerPrefs.Save();
        }
    }
}