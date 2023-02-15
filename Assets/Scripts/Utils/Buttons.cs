namespace Utils
{
	#region Usings
	using UnityEngine;
	using UnityEngine.SceneManagement;
	#endregion Usings

	/// <summary>
	/// Class that handles with generic buttons behaviours
	/// </summary>
	public class Buttons : MonoBehaviour
	{
		#region Fields
		#region Constants
		/// <summary>
		/// Main menu scene name. The project should contain a scene with that name.
		/// </summary>
		private const string _mainMenuSceneName = "MainMenu";

		/// <summary>
		/// Game scene name. The project should contain a scene with that name.
		/// </summary>
		private const string _gameSceneName = "Game";

		/// <summary>
		/// Options scene name. The project should contain a scene with that name.
		/// </summary>
		private const string _optionsSceneName = "Options";
		#endregion Constants
		#endregion Fields

		#region Methods
		#region Buttons
		/// <summary>
		/// Load options scane as an additive scene
		/// </summary>
		public void OpenOptions()
		{
			ExtraSceneManagement.Load(_optionsSceneName);
		}

		/// <summary>
		/// Save options from handler and close options by removing the additive scene loaded
		/// </summary>
		public void CloseOptions()
		{
			OptionsHandler.SaveOptions();
			ExtraSceneManagement.Unload(_optionsSceneName);
		}

		/// <summary>
		/// Load game scene
		/// </summary>
		public void LoadGame()
		{
			SceneManager.LoadScene(_gameSceneName, LoadSceneMode.Single);
		}
		#endregion Buttons
		#endregion Methods








		/// <summary>
		/// Load main menu scene
		/// </summary>
		public void LoadMainMenu()
		{
			SceneManager.LoadScene(_mainMenuSceneName, LoadSceneMode.Single);
		}

		/// <summary>
		/// Pushes the game back by closing the in-game pause menu
		/// </summary>
		public void ClosePause()
		{
			GameEngine.levelInformation.isGameOnPause = false;
		}

		/// <summary>
		/// Force the data reset
		/// </summary>
		public void ForceResetData()
		{
			GameEngine.adventureData = new Data.Adventure();
			string fileName = GameEngine.GetFileName();
			FileManagement.SaveData(GameEngine.adventureData, fileName);
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

