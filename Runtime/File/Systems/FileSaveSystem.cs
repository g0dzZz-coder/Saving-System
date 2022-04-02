using System.Collections.Generic;
using System.IO;
using System.Text;
using Depra.Saving.Runtime.File.Configuration;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.File.Context;
using Depra.Saving.Runtime.Interfaces.Systems;
using Depra.Tools.Serialization.Serializers;

namespace Depra.Saving.Runtime.File.Systems
{
    public class FileSaveSystem : IRawSaveSystem
    {
        public IFileSavingContext Context { get; }
        private IFileSavingConfiguration Configuration { get; }

        private ISerializer Serializer => Configuration.Serializer;
        private Encoding Encoding => Configuration.Encoding;

        public FileSaveSystem(IFileSavingContext context, IFileSavingConfiguration configuration = null)
        {
            Context = context;

            configuration ??= FileSavingConfiguration.Default;
            Configuration = configuration;
        }

        public void Save<T>(string path, T value)
        {
            SaveRaw(path, value);
        }

        public T Load<T>(string path, T defaultValue = default)
        {
            if (HasKey(path) == false)
            {
                return defaultValue;
            }

            using (var stream = System.IO.File.Open(path, FileMode.Open))
            {
                var result = Serializer.Deserialize<T>(stream, Encoding);
                return result;
            }
        }

        public bool HasKey(string path)
        {
            return System.IO.File.Exists(path);
        }

        public void DeleteKey(string path)
        {
            System.IO.File.Delete(path);
        }

        public void DeleteAll()
        {
            foreach (var file in GetAllKeys())
            {
                System.IO.File.Delete(file);
            }
        }

        public object LoadRaw(string path)
        {
            using (var stream = System.IO.File.Open(path, FileMode.Open))
            {
                var result = Serializer.Deserialize<object>(stream, Encoding);
                return result;
            }
        }

        public void SaveRaw(string path, object value)
        {
            var directoryPath = Context.DirectoryPath;
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var stream = System.IO.File.Open(path, FileMode.Create))
            {
                Serializer.Serialize(value, stream, Encoding);
            }
        }

        public IEnumerable<string> GetAllKeys()
        {
            return Directory.GetFiles(Context.DirectoryPath);
        }
    }
}