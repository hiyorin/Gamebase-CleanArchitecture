using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public sealed class CleanArchitectureSettings : ScriptableObject
    {
        [SerializeField, FolderObject] private Object _rootFolder = default;
        
        [SerializeField] private string _namespace = default;

        public Object RootFolder => _rootFolder;

        public string Namespace => _namespace;
    }
}