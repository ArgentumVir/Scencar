using MLAPI.SceneManagement;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public static class Scene
    {
        public static void SafeLoad(string sceneName)
        {
            RaiseIfSceneDoesNotExist(sceneName);

            SceneManager.LoadScene(sceneName);
        }

        public static void SafeNetworkSwitch(string sceneName)
        {
            RaiseIfSceneDoesNotExist(sceneName);

            NetworkSceneManager.SwitchScene(sceneName);
        }


        public static void RaiseIfSceneDoesNotExist(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                throw new System.ArgumentException("Scene name cannot be null or empty.");
            }

            bool didFindScene = false;

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                int lastSlash = scenePath.LastIndexOf("/");

                string registeredSceneName = scenePath.Substring(
                    lastSlash + 1,
                    scenePath.LastIndexOf(".") - lastSlash - 1
                );

                if (string.Compare(sceneName, registeredSceneName, true) == 0)
                {
                    didFindScene = true;
                    break;
                }
            }

            if (!didFindScene)
            {
                throw new SceneNotFoundException($"Scene with name '{sceneName}' not found.");
            }
        }
    }
}