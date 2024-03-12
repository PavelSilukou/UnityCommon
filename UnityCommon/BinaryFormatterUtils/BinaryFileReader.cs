using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Plastic.Newtonsoft.Json;

namespace UnityCommon.BinaryFormatterUtils
{
    public class BinaryFileReader<T>
    {
        private readonly BinaryFile<T> _file;

        public BinaryFileReader(BinaryFile<T> file)
        {
            _file = file;
        }
        
        public T ReadBinary()
        {
            if (!_file.Exists()) throw new ArgumentException("File does not exist");

            var bf = new BinaryFormatter
            {
                Binder = new StringBinder()
            };
            var fileStream = _file.Open();
            var binaryJson = bf.Deserialize(fileStream).GetValue<string>();
            fileStream.Close();
            var json = binaryJson.ToStringFromBase64();
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj!.GetValue<T>();
        }

        private sealed class StringBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                if (typeName != "string")
                {
                    throw new SerializationException("Only string is allowed");
                }
                return Assembly.Load(assemblyName).GetType(typeName);
            }
        }
    }
}
