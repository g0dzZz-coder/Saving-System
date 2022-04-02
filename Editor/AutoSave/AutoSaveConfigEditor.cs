using UnityEditor;

namespace Depra.Saving.Editor.AutoSave
{
    [CustomEditor(typeof(AutoSaveConfig))]
    public class AutoSaveConfigEditor : UnityEditor.Editor
    {
        [MenuItem("Window/Auto save/Find config")]
        public static void ShowConfig()
        {
            var path = AutoSave.GetConfigPath();
            var config = AssetDatabase.LoadAssetAtPath<AutoSaveConfig>(path);
            var targetInstanceId = config.GetInstanceID();
            EditorGUIUtility.PingObject(targetInstanceId);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("You can move this asset where ever you'd like.", MessageType.Info);
        }
    }
}