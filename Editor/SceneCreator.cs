using System.IO;
using UnityEditor;
using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class SceneCreator : IAssetCreator
    {
        private string name;
        
        void IAssetCreator.OnInitialize(CleanArchitectureSettings settings)
        {

        }
        
        private void Generate(string nameSpace, string name, string templateFileName, string rootPath)
        {
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>(
                $"Packages/com.gamebase.clean-architecture/Editor/Templates/{templateFileName}.txt");
            
            var code = template.text
                .Replace("{namespace}", nameSpace)
                .Replace("{name}", name);
            
            var filePath = $"{rootPath}/{name}{templateFileName}.cs";
            File.WriteAllText(filePath, code);
        }
        
        bool IAssetCreator.OnDrawProperties()
        {
            name = EditorGUILayout.TextField("Name", name);
            return !string.IsNullOrEmpty(name);
        }
        
        void IAssetCreator.OnCreate(CleanArchitectureSettings settings)
        {
            var rootPath = $"{Application.dataPath}/../{AssetDatabase.GetAssetPath(settings.RootFolder)}/Presentation/Scene";
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);
            
            Generate(settings.Namespace, name, "Scene", rootPath);
            Generate(settings.Namespace, name, "SceneInstaller", rootPath);
        }
    }
}