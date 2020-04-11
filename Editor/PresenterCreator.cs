using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class PresenterCreator : IAssetCreator
    {
        private string[] interfaces;

        private int index;

        private string name;
        
        void IAssetCreator.OnInitialize(CleanArchitectureSettings settings)
        {
            var rootPath = AssetDatabase.GetAssetPath(settings.RootFolder);
            var files = Directory.GetFiles($"{Application.dataPath}/../{rootPath}/Domain/Presenter");

            interfaces = files
                .Select(Path.GetFileNameWithoutExtension)
                .Where(x => x.StartsWith("I") && !x.EndsWith(".cs"))
                .ToArray();
        }
        
        bool IAssetCreator.OnDrawProperties()
        {
            index = EditorGUILayout.Popup("Interface", index, interfaces);
            name = EditorGUILayout.TextField("Name", name);
            return !string.IsNullOrEmpty(name);
        }
        
        void IAssetCreator.OnCreate(CleanArchitectureSettings settings)
        {
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>("Packages/com.gamebase.clean-architecture/Editor/Templates/Presenter.txt");
            
            var code = template.text
                .Replace("{namespace}", settings.Namespace)
                .Replace("{name}", name)
                .Replace("{interface}", interfaces[index]);
            
            var rootPath = $"{Application.dataPath}/../{AssetDatabase.GetAssetPath(settings.RootFolder)}/Presentation/Presenter";
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);
            
            var filePath = $"{rootPath}/{name}Presenter.cs";
            File.WriteAllText(filePath, code);
        }
    }
}