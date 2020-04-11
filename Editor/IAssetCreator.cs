namespace Gamebase.CleanArchitecture.Editor
{
    public interface IAssetCreator
    {
        void OnInitialize(CleanArchitectureSettings settings);
        
        bool OnDrawProperties();
        
        void OnCreate(CleanArchitectureSettings settings);
    }
}