using System.IO;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.File.Configuration.Structs;
using UnityEngine;

namespace Depra.Saving.Runtime.File.Extensions
{
    public static class FileSavingPreferencesExtensions
    {
        public static string GetDirectoryPath(this IFileSavingPreferences preferences)
        {
            var gameFolder = preferences.SaveGameFolder == SaveGamePath.DataPath
                ? Application.dataPath
                : Application.persistentDataPath;

            return Path.Combine(gameFolder, preferences.FolderName);
        }

        public static string GetFullPath(this IFileSavingPreferences preferences, string fileName)
        {
            var fullPath = Path.Combine(GetDirectoryPath(preferences), fileName, preferences.FileFormat);

            return fullPath;
        }
    }
}