using Depra.SavingSystem.Types;
using Depra.Toolkit.Configuration.Runtime;
using Depra.Toolkit.Serialization.Serializers;
using UnityEngine;

namespace Depra.SavingSystem.Runtime.Configuration
{
    public class SaveConfig : ObjectConfig<SaveConfig>
    {
        [field: SerializeReference, SubclassSelector]
        public ISavingType SavingBackend { get; private set; } = new PlayerPrefsSavingType();

        [field: SerializeReference, SubclassSelector]
        public ISerializer Serializer { get; private set; } = new JsonSerializer();
    }
}