using Depra.Saving.Runtime.File.Configuration.Structs;
using JetBrains.Annotations;

namespace Depra.Saving.Runtime.File.Configuration.Interfaces
{
    public interface IFileSavingPreferences
    {
        [PublicAPI]
        string FolderName { get; }

        [PublicAPI]
        string FileFormat { get; }
        
        [PublicAPI]
        SaveGamePath SaveGameFolder { get; }
    }
}