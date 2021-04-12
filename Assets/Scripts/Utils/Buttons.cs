using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    /// <summary>
    /// Class that handles with generic buttons behaviours
    /// </summary>
    public class Buttons : MonoBehaviour
    {

        /// <summary>
        /// Main menu scene name
        /// </summary>
        private const string mainMenuSceneName = "MainMenu";

        /// <summary>
        /// Game scene name
        /// </summary>
        private const string gameSceneName = "Game";

        /// <summary>
        /// Options scene name
        /// </summary>
        private const string optionsSceneName = "Options";

        /// <summary>
        /// Load options
        /// </summary>
        public void OpenOptions()
        {
            ExtraSceneManagement.Load(optionsSceneName);
        }

        /// <summary>
        /// Close options
        /// </summary>
        public void CloseOptions()
        {
            OptionsHandler.SaveOptions();
            ExtraSceneManagement.Unload(optionsSceneName);
        }
        
        /// <summary>
        /// Load game scene
        /// </summary>
        public void LoadGame()
        {
            SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        }

        /// <summary>
        /// Load main menu scene
        /// </summary>
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        public void Quit()
        {
#if UNITY_EDITOR
            // If we are in the editor: stopping playing the application ends it
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Otherwise: we quit the application
            Application.Quit();
#endif
        }
    } // End of class
} // End of namespace

