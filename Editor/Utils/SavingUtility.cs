using Depra.Saving.Runtime.File;
using Depra.Saving.Runtime.Prefs;
using UnityEditor;

namespace Depra.Saving.Editor.Utils
{
    public static class SavingUtility
    {
        [MenuItem("Tools/Saves/Clear Prefs", priority = 1)]
        public static void ClearPrefs()
        {
            SaveManager.DeleteAll();
        }

        [MenuItem("Tools/Saves/Clear Quick Save", priority = 2)]
        public static void ClearQuickSave()
        {
            QuickSave.DeleteAll();
        }

        [MenuItem("Tools/Saves/Inspector", priority = 3)]
        public static void OpenInspector()
        {
            SavingsViewWindow.ShowWindow();
        }
    }
}