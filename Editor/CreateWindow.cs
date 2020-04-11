using Gamebase.Editor;
using UnityEditor;
using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class CreateWindow : EditorWindow
    {
        private IAssetCreator creator;
        
        private string className;

        private CleanArchitectureSettings settings;

        private SerializedObject serializedObject;

        public void Initialize(IAssetCreator creator)
        {
            this.creator = creator;
            creator.OnInitialize(settings);
        }
        
        private void OnEnable()
        {
            EditorUtility.FocusProjectWindow();
            if (focusedWindow == null)
                return;

            var rect = focusedWindow.position;
            rect.y += 24.0f;
            rect.height = 24.0f * 6.0f;
            position = rect;

            settings = GamebaseEditorUtility.Load<CleanArchitectureSettings>();
            serializedObject = new SerializedObject(settings);
            Focus();
        }

        private void OnDisable()
        {
            serializedObject?.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
            serializedObject?.Dispose();
            settings = null;
        }

        private void OnGUI()
        {
            if (!settings)
            {
                Close();
                return;
            }
            
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_rootFolder"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_namespace"));
            className = EditorGUILayout.TextField("Name", className);
            creator.OnDrawProperties();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Cancel"))
            {
                Close();
                return;
            }
            
            EditorGUI.BeginDisabledGroup(!settings.RootFolder || string.IsNullOrEmpty(settings.Namespace) || string.IsNullOrEmpty(className));
            if (GUILayout.Button("Create"))
            {
                creator.OnCreate(className, settings);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Close();
                return;
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            serializedObject?.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
        }
    }
}