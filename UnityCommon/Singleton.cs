// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
    public class Singleton<T> where T : new()
    {
        private static T _instance = default!;

        protected Singleton()
        {
        }

        public static T Instance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }
                
            return _instance;
        }
    }
}
