using System;
using System.Collections.Generic;
using Depra.SavingSystem.Runtime.Interfaces;
using Depra.SavingSystem.Runtime.Services;

namespace Depra.SavingSystem.Runtime
{
    /// <summary>
    /// Global context. Just for easier syntax. Uses inside <see cref="SaveService"/>
    /// </summary>
    public static class SaveManager
    {
        private static ISaveSystem InternalSystem { get; }

        static SaveManager()
        {
            InternalSystem = SaveService.Instance;
        }

        public static void Save<T>(string key, T value) => InternalSystem.Save(key, value);

        public static void Save<T>(string key, Func<T> value) => InternalSystem.Save(key, value());

        public static T Load<T>(string key, T defaultValue = default) => InternalSystem.Load(key, defaultValue);

        public static bool HasKey(string key) => InternalSystem.HasKey(key);

        public static void DeleteKey(string key) => InternalSystem.DeleteKey(key);

        public static void DeleteAll() => InternalSystem.DeleteAll();

        public static IEnumerable<string> GetAllKeys() => InternalSystem.GetAllKeys();
    }
}