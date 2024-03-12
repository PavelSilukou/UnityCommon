namespace UnityCommon.PlayerPrefsUtils.KeyTypes
{
    public abstract class PlayerPrefsStringKey : PlayerPrefsKey
    {
        protected override string TypePrefix => "str";

        protected PlayerPrefsStringKey(string keyName) : base(keyName)
        {
            
        }

        protected override string Serialize(object value)
        {
            //convert object to string
            //...
            // checks
            //...
            return (string) value;
        }

        protected override object Deserialize(string value)
        {
            //convert raw string to object
            //...
            //checks
            //...
            return value;
        }
    }
}