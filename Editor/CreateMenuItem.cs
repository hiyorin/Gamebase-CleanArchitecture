using UnityEditor;
using UnityEngine;

namespace Gamebase.CleanArchitecture.Editor
{
    public static class CreateMenuItem
    {
        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/Project", false, 0)]
        public static void CreateProject()
        {
            ShowPopup<ProjectCreator>();
        }

        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/Scene", false, 1)]
        public static void CreateScene()
        {
            ShowPopup<SceneCreator>();
        }
        
        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/UseCase", false, 10)]
        public static void CreateUseCase()
        {
            ShowPopup<UseCaseCreator>();
        }
        
        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/IPresenter", false, 10)]
        public static void CreatePresenterInterface()
        {
            ShowPopup<PresenterInterfaceCreator>();
        }
        
        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/IRepository", false, 10)]
        public static void CreateRepositoryInterface()
        {
            ShowPopup<RepositoryInterfaceCreator>();
        }

        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/Presenter", false, 10)]
        public static void CreatePresenter()
        {
            ShowPopup<PresenterCreator>();
        }
        
        [MenuItem("Assets/Create/Gamebase-CleanArchitecture/Repository", false, 10)]
        public static void CreateRepository()
        {
            ShowPopup<RepositoryCreator>();
        }
        
        private static void ShowPopup<T>() where T : IAssetCreator, new()
        {
            var window = ScriptableObject.CreateInstance<CreateWindow>();
            window.Initialize(new T());
            window.ShowPopup();
        }
    }
}