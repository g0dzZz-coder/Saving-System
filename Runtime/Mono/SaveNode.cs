using System.Collections.Generic;
using Depra.Saving.Runtime.File.Context;
using Depra.Saving.Runtime.Interfaces.Systems;
using Depra.Tools.Serialization.Interfaces.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Depra.Saving.Runtime.Mono
{
    public class SaveNode : MonoBehaviour
    {
        [SerializeField] private string _key = "SaveData";
        [SerializeField] private InterfaceReference<IFileSavingContext> _context;
        [SerializeField] private InterfaceReference<ISaveSystem> _system;

        private IFileSavingContext Context => _context.Value;
        private ISaveSystem System => _system.Value;
        
        private string FullKey => Context.GetFullPath(_key);

        [Button]
        public void Save()
        {
            var state = System.Load(FullKey, new Dictionary<string, object>());
            CaptureState(state);
            System.Save(FullKey, state);
        }

        [Button]
        public void Load()
        {
            var state = System.Load(FullKey, new Dictionary<string, object>());
            RestoreState(state);
        }

        private static void CaptureState(IDictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                state[saveable.Id] = saveable.CaptureState();
            }

            state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;
        }

        private static void RestoreState(IReadOnlyDictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                if (state.TryGetValue(saveable.Id, out var value))
                {
                    saveable.RestoreState(value);
                }
            }
        }
    }
}