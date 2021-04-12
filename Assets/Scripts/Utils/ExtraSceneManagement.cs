using UnityEngine.SceneManagement;

namespace Utils
{
    /// <summary>
    /// Static class that handles with extra scene management
    /// </summary>
    public class ExtraSceneManagement
    {
        /// <summary>
        /// Check if a scene is loaded
        /// </summary>
        /// <param name="sceneName">Scene to check</param>
        /// <returns></returns>
        public static bool IsSceneLoaded(string sceneName)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                var scene = SceneManager.GetSceneAt(i);

                if (scene.name == sceneName)
                {
                    //the scene is already loaded
                    return true;
                }
            }
            //scene not currently loaded in the hierarchy:
            return false;
        }

        /// <summary>
        /// Load a scene if that scene if not already loaded
        /// </summary>
        /// <param name="sceneName">Scene to be loaded</param>
        public static void Load(string sceneName)
        {
            if (IsSceneLoaded(sceneName) == false)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }

        /// <summary>
        /// Unloads a scene if that scene is already loaded
        /// </summary>
        /// <param name="sceneName">Scene to be unloaded</param>
        public static void Unload(string sceneName)
        {
            if (IsSceneLoaded(sceneName) == true)
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }
    } // End of class
} // End of namespace

