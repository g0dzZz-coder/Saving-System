using System;
using Depra.Saving.Runtime.Data;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using UnityEngine;

namespace Depra.Saving.Runtime.File.Configuration.Structs
{
    [Serializable]
    public struct FileSavingPreferences : IFileSavingPreferences
    {
        [SerializeField] private string _folderName;
        [SerializeField] private string _fileFormat;
        [SerializeField] private SaveGamePath _saveGameFolder;
        
        public string FolderName => _folderName;
        public string FileFormat => _fileFormat;
        public SaveGamePath SaveGameFolder => _saveGameFolder;

        public FileSavingPreferences(string folderName, string fileFormat,
            SaveGamePath gameFolder = SaveGamePath.PersistentDataPath)
        {
            _folderName = folderName;
            _fileFormat = fileFormat;
            _saveGameFolder = gameFolder;
        }
    }
}