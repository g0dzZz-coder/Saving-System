using System.Collections.Generic;

namespace Depra.SavingSystem.Types
{
    public interface ISavingType
    {
        void Save<T>(string key, T value);
        T Load<T>(string key, T defaultValue = default);

        bool HasKey(string key);
        void DeleteKey(string key);
        void DeleteAll();
        
        object LoadRaw(string key);
        void SaveRaw(string key, object value);

        IEnumerable<string> GetAllKeys();
    }
}