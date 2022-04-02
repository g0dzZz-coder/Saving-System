using Depra.Saving.Runtime.File.Configuration;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.Interfaces.Systems;
using JetBrains.Annotations;

namespace Depra.Saving.Runtime.Configuration
{
    public interface ISaveConfiguration
    {
        IRawSaveSystem PreferencesSystem { get; }
        
        [PublicAPI]
        IFileSavingConfiguration FileSaving { get; }
    }
}