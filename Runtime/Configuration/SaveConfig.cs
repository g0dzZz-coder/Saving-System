using Depra.SavingSystem.Runtime.Backends;
using Depra.SavingSystem.Runtime.Interfaces;
using Depra.Toolkit.Configuration.Runtime;
using Depra.Toolkit.Configuration.Runtime.Attributes;
using Depra.Toolkit.Serialization.Serializers;
using UnityEngine;

namespace Depra.SavingSystem.Runtime.Configuration
{
    [Config("Saving")]
    public class SaveConfig : ObjectConfig<SaveConfig>, ISaveConfiguration
    {
        [field: SerializeReference, SubclassSelector]
        public ISaveBackend Backend { get; private set; }

        [field: SerializeReference, SubclassSelector]
        public ISerializer Serializer { get; private set; }

        public SaveConfig()
        {
            Backend = new PlayerPrefsSaveBackend();
            Serializer = new JsonSerializer();
        }

        // [field: SerializeReference, SubclassSelector]
        // public Encoding Encoding { get; private set; } = Encoding.Default;
    }
}