using System.Collections.Generic;
using Depra.SavingSystem.Runtime.Configuration;
using Depra.SavingSystem.Types;

namespace Depra.SavingSystem.Runtime
{
    public static class SaveSystem
    {
        private static ISavingType Backend => SaveConfig.Instance.SavingBackend;

        public static void Save<T>(string key, T value)
        {
            Backend.Save(key, value);
        }

        public static T Load<T>(string key, T defaultValue = default)
        {
            return Backend.Load(key, defaultValue);
        }

        public static bool HasKey(string key)
        {
            return Backend.HasKey(key);
        }

        public static void DeleteKey(string key)
        {
            Backend.DeleteKey(key);
        }

        public static void DeleteAll()
        {
            Backend.DeleteAll();
        }

        public static IEnumerable<string> GetAllKeys()
        {
            return Backend.GetAllKeys();
        }

        public static object LoadRaw(string key)
        {
            return Backend.LoadRaw(key).ToString();
        }

        public static void SaveRaw(string key, object value)
        {
            Backend.SaveRaw(key, value);
        }
    }
}