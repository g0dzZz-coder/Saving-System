using System.Linq;
using Depra.SavingSystem.Runtime;
using UnityEditor;
using UnityEngine;

namespace Depra.SavingSystem.Editor
{
    public class SavingsViewWindow : EditorWindow
    {
        private struct Data
        {
            public Data(string key)
            {
                Key = key;
                _rawData = SaveSystem.LoadRaw(key).ToString();
            }

            private string _rawData;

            public string Key { get; }

            public string RawData
            {
                get => _rawData;
                set
                {
                    SaveSystem.SaveRaw(Key, value);
                    _rawData = value;
                }
            }
        }

        [MenuItem("Tools/Saves/Clear", priority = 1)]
        public static void ClearSaves()
        {
            SaveSystem.DeleteAll();
        }

        [MenuItem("Tools/Saves/Inspector", priority = 2)]
        private static void ShowWindow()
        {
            var window = GetWindow<SavingsViewWindow>();

            window.RefreshAllData();

            window.titleContent = new GUIContent("Saves Inspector");
            window.Show();
        }

        private Data[] _allData;

        private Vector2 _scrollPos;

        private void OnGUI()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, false, true);

            if (_allData == null)
                RefreshAllData();

            for (var index = 0; index < _allData.Length; index++)
            {
                var data = _allData[index];
                DrawData(data, index);
            }

            EditorGUILayout.EndScrollView();
        }

        private void DrawData(Data data, int index)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.TextField("key:", data.Key);

            var newData = EditorGUILayout.TextField("raw value:", data.RawData);

            if (newData != data.RawData)
            {
                data.RawData = newData;
                RefreshData(index);
            }

            EditorGUILayout.EndHorizontal();
        }

        private void RefreshAllData()
        {
            var keys = SaveSystem.GetAllKeys().ToArray();
            _allData = new Data[keys.Length];

            for (int i = 0; i < keys.Length; i++)
            {
                _allData[i] = new Data(keys[i]);
            }
        }

        private void RefreshData(int index)
        {
            var previewData = _allData[index];
            _allData[index] = new Data(previewData.Key);
        }
    }
}