using System.IO;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.File.Configuration.Structs;
using Depra.Saving.Runtime.File.Extensions;
using UnityEngine;

namespace Depra.Saving.Runtime.File.Context
{
    public class FileSavingContext : MonoBehaviour, IFileSavingContext
    {
        [SerializeField] private FileSavingPreferences _preferences;

        public IFileSavingPreferences Preferences => _preferences;

        public string DirectoryPath => _preferences.GetDirectoryPath();

        public string GetFullPath(string fileName)
        {
            var fullPath = Path.Combine(DirectoryPath, fileName, _preferences.FileFormat);

            return fullPath;
        }
    }
}