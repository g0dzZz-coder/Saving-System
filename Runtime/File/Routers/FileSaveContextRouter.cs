using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.File.Context;
using UnityEngine;

namespace Depra.Saving.Runtime.File.Routers
{
    public abstract class FileSaveContextRouter : MonoBehaviour, IFileSavingContext
    {
        public abstract IFileSavingContext Context { get; }

        public IFileSavingPreferences Preferences => Context.Preferences;

        public string DirectoryPath => Context.DirectoryPath;

        public string GetFullPath(string fileName) => Context.GetFullPath(fileName);
    }
}