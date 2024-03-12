using System.Runtime.Serialization.Formatters.Binary;
using Unity.Plastic.Newtonsoft.Json;

namespace UnityCommon.BinaryFormatterUtils
{
    public class BinaryFileWriter<T>
    {
        private readonly BinaryFile<T> _file;

        public BinaryFileWriter(BinaryFile<T> file)
        {
            _file = file;
        }
        
        public void WriteBinary(T obj)
        {
            var bf = new BinaryFormatter();
            var json = JsonConvert.SerializeObject(obj);
            var binaryJson = json.ToBase64String();
            var fileStream = _file.Create();
            bf.Serialize(fileStream, binaryJson);
            fileStream.Close();
        }
    }
}
