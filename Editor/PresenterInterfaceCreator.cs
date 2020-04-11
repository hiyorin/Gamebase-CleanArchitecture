using System.IO;
using UnityEditor;
using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class PresenterInterfaceCreator : IAssetCreator
    {
        void IAssetCreator.OnInitialize(CleanArchitectureSettings settings)
        {

        }

        void IAssetCreator.OnDrawProperties()
        {
            
        }
        
        void IAssetCreator.OnCreate(string name, CleanArchitectureSettings settings)
        {
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>("Packages/com.gamebase.clean-architecture/Editor/Templates/PresenterInterface.txt");
            
            var code = template.text
                .Replace("{namespace}", settings.Namespace)
                .Replace("{name}", name);

            var rootPath = $"{Application.dataPath}/../{AssetDatabase.GetAssetPath(settings.RootFolder)}/Domain/Presenter";
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            var filePath = $"{rootPath}/I{name}Presenter.cs";
            File.WriteAllText(filePath, code);
        }
    }
}