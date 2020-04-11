using Gamebase.Editor;
using UnityEditor;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class ProjectCreator : IAssetCreator
    {
        private void CreateFolder(string parentFolder, string newFolderName, params string[] newSubFolderNames)
        {
            if (!AssetDatabase.IsValidFolder($"{parentFolder}/{newFolderName}"))
                AssetDatabase.CreateFolder(parentFolder, newFolderName);
            
            foreach (var newSubFolderName in newSubFolderNames)
            {
                if (!AssetDatabase.IsValidFolder($"{parentFolder}/{newFolderName}/{newSubFolderName}"))
                    AssetDatabase.CreateFolder($"{parentFolder}/{newFolderName}", newSubFolderName);
            }
            
        }

        private void CreateAssemblyDefine(string parentFolder, string newFolderName, params string[] references)
        {
            AssemblyDefineBuilder.Create()
                .SetName(newFolderName)
                .AddReference(references)
                .Write($"{parentFolder}/{newFolderName}/{newFolderName}.asmdef");
        }
        
        void IAssetCreator.OnInitialize(CleanArchitectureSettings settings)
        {

        }
        
        void IAssetCreator.OnDrawProperties()
        {
            
        }
        
        void IAssetCreator.OnCreate(string name, CleanArchitectureSettings settings)
        {
            var root = AssetDatabase.GetAssetPath(settings.RootFolder);
            CreateFolder(root, "Application");
            CreateFolder(root, "Domain", "UseCase", "Presenter", "Repository", "Model");
            CreateFolder(root, "Presentation", "Presenter", "View", "Scene");
            CreateFolder(root, "Data","DataStore", "Repository");
            CreateAssemblyDefine(root, "Application");
            CreateAssemblyDefine(root, "Domain", "Application", "UniRx", "UniRx.Async", "Zenject", "Gamebase-CleanArchitecture");
            CreateAssemblyDefine(root, "Presentation", "Application", "Domain", "UniRx", "UniRx.Async", "Zenject", "Gamebase-CleanArchitecture", "Gamebase-SceneManagement");
            CreateAssemblyDefine(root, "Data", "Application", "Domain", "UniRx", "UniRx.Async", "Zenject", "Gamebase-CleanArchitecture");
        }
    }
}