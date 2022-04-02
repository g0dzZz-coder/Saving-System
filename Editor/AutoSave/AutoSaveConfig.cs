using NaughtyAttributes;
using UnityEngine;

namespace Depra.Saving.Editor.AutoSave
{
    public class AutoSaveConfig : ScriptableObject
    {
        [Tooltip("Enable auto save functionality")] 
        [SerializeField]
        private bool _enabled;

        [Tooltip("The frequency in minutes auto save will activate")]
        [EnableIf("Enabled"), AllowNesting]
        [Min(1)]
        [SerializeField]
        private int _frequency = 1;

        [Tooltip("Log a message every time the scene is auto saved")]
        [EnableIf("Enabled"), AllowNesting]
        [SerializeField]
        private bool _logging;

        public bool Enabled => _enabled;

        public int Frequency => _frequency;

        public bool Logging => _logging;
    }
}