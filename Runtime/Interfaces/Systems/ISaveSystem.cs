using JetBrains.Annotations;

namespace Depra.Saving.Runtime.Interfaces.Systems
{
    public interface ISaveSystem
    {
        [PublicAPI]
        void Save<T>(string key, T data);
        
        [PublicAPI]
        T Load<T>(string key, T defaultValue = default);
    }
}