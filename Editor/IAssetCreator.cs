namespace Gamebase.CleanArchitecture.Editor
{
    public interface IAssetCreator
    {
        void OnInitialize(CleanArchitectureSettings settings);
        
        void OnDrawProperties();
        
        void OnCreate(string name, CleanArchitectureSettings settings);
    }
}