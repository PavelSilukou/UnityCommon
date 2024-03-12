using System.Runtime.Serialization;

namespace UnityCommon.PlayerPrefsUtils.KeyTypes
{
    public abstract class PlayerPrefsBoolKey : PlayerPrefsKey
    {
        protected override string TypePrefix => "bool";

        protected PlayerPrefsBoolKey(string keyName) : base(keyName)
        {
            
        }

        protected override string Serialize(object value)
        {
            if (value is bool boolValue)
            {
                return boolValue.ToString();
            }

            throw new SerializationException();
        }

        protected override object Deserialize(string value)
        {
            if (bool.TryParse(value, out var boolValue))
            {
                return boolValue;
            }
            
            throw new SerializationException();
        }

        protected override object Default()
        {
            return false;
        }
    }
}