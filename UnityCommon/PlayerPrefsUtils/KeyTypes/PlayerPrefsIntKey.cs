using System.Runtime.Serialization;

namespace UnityCommon.PlayerPrefsUtils.KeyTypes
{
    public abstract class PlayerPrefsIntKey : PlayerPrefsKey
    {
        protected override string TypePrefix => "int";

        protected PlayerPrefsIntKey(string keyName) : base(keyName)
        {
            
        }

        protected override string Serialize(object value)
        {
            if (value is int intValue)
            {
                return intValue.ToString();
            }

            throw new SerializationException();
        }

        protected override object Deserialize(string value)
        {
            if (int.TryParse(value, out var intValue))
            {
                return intValue;
            }
            
            throw new SerializationException();
        }

        protected override object Default()
        {
            return -1;
        }
    }
}