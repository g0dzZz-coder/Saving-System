using JetBrains.Annotations;

namespace Depra.Saving.Runtime.Interfaces.Systems
{
    public interface IRawSaveSystem : ISaveSystem, ISavingKeyStorage
    {
        [PublicAPI]
        object LoadRaw(string key);
        
        [PublicAPI]
        void SaveRaw(string key, object value);
    }
}