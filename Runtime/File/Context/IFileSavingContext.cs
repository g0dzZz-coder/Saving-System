using Depra.Saving.Runtime.File.Configuration.Interfaces;
using JetBrains.Annotations;

namespace Depra.Saving.Runtime.File.Context
{
    public interface IFileSavingContext
    {
        [PublicAPI]
        IFileSavingPreferences Preferences { get; }

        [PublicAPI]
        string DirectoryPath { get; }
        
        [PublicAPI]
        string GetFullPath(string fileName);
    }
}