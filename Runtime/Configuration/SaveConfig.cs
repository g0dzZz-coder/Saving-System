using Depra.Configuration.Runtime.Attributes;
using Depra.Configuration.Runtime.SO;
using Depra.Saving.Runtime.File.Configuration;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.Interfaces.Systems;
using Depra.Saving.Runtime.Prefs;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.Saving.Runtime.Configuration
{
    [Config("Saving")]
    public class SaveConfig : ObjectConfig<SaveConfig>, ISaveConfiguration
    {
        [field: SerializeReference, SubclassSelector, BoxGroup]
        public IRawSaveSystem PreferencesSystem { get; private set; }

        [field: SerializeReference, SubclassSelector, BoxGroup]
        public IFileSavingConfiguration FileSaving { get; private set; }

        public SaveConfig()
        {
            PreferencesSystem = new PlayerPrefsSaveSystem();
            FileSaving = FileSavingConfiguration.Default;
        }
    }
}