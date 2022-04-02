using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;

namespace Depra.Saving.Editor.AutoSave
{
    public static class AutoSave
    {
        private const string ConfigTypeName = nameof(AutoSaveConfig);
        
        private static AutoSaveConfig _config;
        private static CancellationTokenSource _tokenSource;
        private static Task _task;
        
        private static string ConfigPath => $"Assets/{ConfigTypeName}.asset";

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            FetchConfig();
            CancelTask();

            _tokenSource = new CancellationTokenSource();
            _task = SaveInterval(_tokenSource.Token);
        }

        private static void FetchConfig()
        {
            while (true)
            {
                if (_config != null)
                {
                    return;
                }

                var path = GetConfigPath();
                if (path == null)
                {
                    AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<AutoSaveConfig>(), ConfigPath);
                    Debug.Log("A config file has been created at the root of your project.<b> " +
                              "You can move this anywhere you'd like.</b>");

                    continue;
                }

                _config = AssetDatabase.LoadAssetAtPath<AutoSaveConfig>(path);

                break;
            }
        }

        internal static string GetConfigPath()
        {
            var paths = AssetDatabase.FindAssets(nameof(AutoSaveConfig))
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(c => c.EndsWith(".asset")).ToList();

            if (paths.Count > 1)
            {
                Debug.LogWarning("Multiple auto save config assets found. Delete one.");
            }

            return paths.FirstOrDefault();
        }

        private static async Task SaveInterval(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                await Task.Delay(_config.Frequency * 1000 * 60, token);

                if (_config == null)
                {
                    FetchConfig();
                }

                if (_config.Enabled == false || Application.isPlaying || BuildPipeline.isBuildingPlayer ||
                    EditorApplication.isCompiling || InternalEditorUtility.isApplicationActive == false)
                {
                    continue;
                }

                EditorSceneManager.SaveOpenScenes();

                if (_config.Logging)
                {
                    Debug.Log($"Auto-saved at {DateTime.Now:h:mm:ss tt}");
                }
            }
        }

        private static void CancelTask()
        {
            if (_task == null)
            {
                return;
            }

            _tokenSource.Cancel();
            _task.Wait();
        }
    }
}