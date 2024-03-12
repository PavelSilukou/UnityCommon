using System;
using System.IO;

namespace UnityCommon.BinaryFormatterUtils
{
    public abstract class BinaryFile<T>
    {
        private readonly BinaryFormatterPath _path;

        protected BinaryFile(string targetFile)
        {
            _path = new BinaryFormatterPath(targetFile);
        }

        protected abstract T Default();

        protected T ReadObject()
        {
            try
            {
                return new BinaryFileReader<T>(this).ReadBinary();
            }
            catch (Exception)
            {
                return Default();
            }
        }

        protected void WriteObject(T obj)
        {
            var writer = new BinaryFileWriter<T>(this);
            try
            {
                writer.WriteBinary(obj);
            }
            catch (Exception)
            {
                writer.WriteBinary(Default());
            }
        }
        
        public bool Exists()
        {
            return File.Exists(_path.GetPath());
        }
        
        public FileStream Open()
        {
            return File.Open(_path.GetPath(), FileMode.Open);
        }
        
        public FileStream Create()
        {
            return File.Create(_path.GetPath());
        }
    }
}
