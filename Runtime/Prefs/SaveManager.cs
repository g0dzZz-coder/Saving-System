using System;
using System.Collections.Generic;
using Depra.Saving.Runtime.Configuration;
using Depra.Saving.Runtime.Interfaces.Systems;

namespace Depra.Saving.Runtime.Prefs
{
    /// <summary>
    /// Global context. Just for easier syntax.
    /// </summary>
    public static class SaveManager
    {
        public static IRawSaveSystem System { get; }
        
        public static void Save<T>(string key, T value) => System.Save(key, value);

        public static void Save<T>(string key, Func<T> value) => System.Save(key, value());

        public static T Load<T>(string key, T defaultValue = default) => System.Load(key, defaultValue);

        public static bool HasKey(string key) => System.HasKey(key);

        public static void DeleteKey(string key) => System.DeleteKey(key);

        public static void DeleteAll() => System.DeleteAll();

        public static IEnumerable<string> GetAllKeys() => System.GetAllKeys();

        static SaveManager()
        {
            System = SaveConfig.Instance.PreferencesSystem;
        }
    }
}