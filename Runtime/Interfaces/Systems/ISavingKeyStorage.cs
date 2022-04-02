using System.Collections.Generic;
using JetBrains.Annotations;

namespace Depra.Saving.Runtime.Interfaces.Systems
{
    public interface ISavingKeyStorage
    {
        [PublicAPI]
        bool HasKey(string key);
        
        [PublicAPI]
        void DeleteKey(string key);
        
        [PublicAPI]
        void DeleteAll();
        
        [PublicAPI]
        IEnumerable<string> GetAllKeys();
    }
}