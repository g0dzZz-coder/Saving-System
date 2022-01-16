using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Depra.SavingSystem.Runtime.Configuration;
using Depra.SavingSystem.Runtime.Data;
using Depra.SavingSystem.Runtime.Interfaces;
using Depra.Toolkit.Serialization.Serializers;
using UnityEngine;
using Encoding = System.Text.Encoding;

namespace Depra.SavingSystem.Runtime.Backends
{
    public class FileSavingConfiguration
    {
        public string FolderName = "Saves";
        public string FileFormat = "sav";
        public SaveGamePath SaveGameFolder = SaveGamePath.DataPath;
    }
    
    [Serializable]
    [AddTypeMenu("File")]
    public class FileSaveBackend : ISaveBackend
    {
        [SerializeField] private string _folderName = "Saves";
        [SerializeField] private string _fileFormat = "sav";
        [SerializeField] private SaveGamePath _saveGameFolder = SaveGamePath.DataPath;

        private ISerializer Serializer => SaveConfig.Instance.Serializer;

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

            using (var stream = File.Open(path, FileMode.Open))
            {
                var result = Serializer.Deserialize<T>(stream, Encoding.Default);
                return result;
            }
        }

        public bool HasKey(string path)
        {
            return File.Exists(path);
        }

        public void DeleteKey(string path)
        {
            File.Delete(path);
        }

        public void DeleteAll()
        {
            foreach (var file in GetAllKeys())
            {
                File.Delete(file);
            }
        }

        public object LoadRaw(string path)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                var result = Serializer.Deserialize<object>(stream, Encoding.Default);
                return result;
            }
        }

        public void SaveRaw(string path, object value)
        {
            var directoryPath = GetDirectoryPath();
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var stream = File.Open(path, FileMode.Create))
            {
                Serializer.Serialize(value, stream, Encoding.Default);
            }
        }

        public IEnumerable<string> GetAllKeys()
        {
            return Directory.GetFiles(GetDirectoryPath());
        }

        public string GetDirectoryPath()
        {
            var gameFolder = _saveGameFolder == SaveGamePath.DataPath
                ? Application.dataPath
                : Application.persistentDataPath;

            return Path.Combine(gameFolder, _folderName);
        }

        public string GetFullPath(string fileName)
        {
            return Path.Combine(GetDirectoryPath(), fileName, _fileFormat);
        }
    }
}