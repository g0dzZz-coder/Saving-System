using System.Collections.Generic;
using Depra.SavingSystem.Runtime.Configuration;
using Depra.SavingSystem.Runtime.Interfaces;
using Depra.Toolkit.Services.Runtime.Core;

namespace Depra.SavingSystem.Runtime.Services
{
    public class SaveService : ScriptableObjectService<SaveService>, ISaveBackend
    {
        private ISaveConfiguration Configuration => SaveConfig.Instance;
        private ISaveBackend Backend => Configuration.Backend;

        public void Save<T>(string key, T value) => Backend.Save(key, value);

        public T Load<T>(string key, T defaultValue = default) => Backend.Load(key, defaultValue);

        public bool HasKey(string key) => Backend.HasKey(key);

        public void DeleteKey(string key) => Backend.DeleteKey(key);

        public void DeleteAll() => Backend.DeleteAll();

        public IEnumerable<string> GetAllKeys() => Backend.GetAllKeys();

        public object LoadRaw(string key) => Backend.LoadRaw(key).ToString();

        public void SaveRaw(string key, object value) => Backend.SaveRaw(key, value);
    }
}