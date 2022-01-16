using System.Collections.Generic;

namespace Depra.SavingSystem.Runtime.Interfaces
{
    public interface ISaveSystem
    {
        void Save<T>(string key, T data);
        
        T Load<T>(string key, T defaultValue = default);
        
        bool HasKey(string key);
        void DeleteKey(string key);
        void DeleteAll();
        
        IEnumerable<string> GetAllKeys();
    }
}