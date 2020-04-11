using System.IO;
using UnityEditor;
using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class UseCaseCreator : IAssetCreator
    {
        void IAssetCreator.OnInitialize(CleanArchitectureSettings settings)
        {

        }
        
        void IAssetCreator.OnDrawProperties()
        {
            
        }
        
        void IAssetCreator.OnCreate(string name, CleanArchitectureSettings settings)
        {
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>("Packages/com.gamebase.clean-architecture/Editor/Templates/UseCase.txt");
            
            var code = template.text
                .Replace("{namespace}", settings.Namespace)
                .Replace("{name}", name);

            var rootPath = $"{Application.dataPath}/../{AssetDatabase.GetAssetPath(settings.RootFolder)}/Domain/UseCase";
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            var filePath = $"{rootPath}/I{name}UseCase.cs";
            File.WriteAllText(filePath, code);
        }
    }
}