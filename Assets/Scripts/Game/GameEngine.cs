using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
	#region Fields
	#region Constants
	public static int MAX_LEVELS = 30;
	#endregion Constants

	#region Serialized
	[SerializeField] private bool m_forceLevel = false;
	[SerializeField, Range(0, 30)] private uint m_forceLevelId = 0;
	#endregion Serialized
	#endregion Fields
    /// <summary>
    /// Main menu scene name
    /// </summary>
    private const string mainMenuSceneName = "MainMenu";

    /// <summary>
    /// Static reference handler to adventure data
    /// </summary>
    public static Data.Adventure adventureData;

    /// <summary>
    /// Static flag determining if the adventure was loaded
    /// </summary>
    private static bool wasAdventureDataLoaded = false;

    /// <summary>
    /// Handler to the level structure
    /// </summary>
    public static Data.LevelInformation levelInformation;

    /// <summary>
    /// Handler to UI
    /// </summary>
    public UIManagement uIManagement;

    /// <summary>
    /// Internal pause state
    /// </summary>
    private bool pauseInternalState = false;

    /// <summary>
    /// Rotation speed of interactable items, in degrees per second
    /// </summary>
    public static float interactableRotationSpeed = 180.0f;

    public Utils.Fading fading;

    // Start is called before the first frame update
    void Start()
    {
        LoadAdventure();

        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the life lost information
        if (levelInformation.isLifeLost == true)
        {
            levelInformation.isLifeLost = false;

            LifeLost();
        }

        // Check if the level is ended
        if (levelInformation.isLevelEndReached == true)
        {
            levelInformation.isLevelEndReached = false;

            StartCoroutine(LoadNewLevel());
        }

        CheckPause();

        CheckMoney();
    }

    private void CheckMoney()
    {
        if (adventureData.money >= 100 && adventureData.lives < adventureData.livesMax)
        {
            // Buy a life lost
            adventureData.money -= 100;
            adventureData.lives++;

            // Reset lives displayed
            uIManagement.DisplayLives();
        }

        if (adventureData.money >= 500 && adventureData.livesMax < 5)
        {
            // Buy a new life, up to 5
            adventureData.money -= 500;
            adventureData.livesMax++;
            adventureData.lives++;

            // Reset lives displayed
            uIManagement.DisplayLives();
        }
    }

    /// <summary>
    /// Check the pause information
    /// </summary>
    private void CheckPause()
    {

        // If pause internal state did not change, return;
        if (pauseInternalState == levelInformation.isGameOnPause)
        {
            return;
        }

        // Sets the time scaling, depending on
        Time.timeScale = levelInformation.isGameOnPause ? 0.0f : 1.0f;

        // Toggles pause panel
        uIManagement.pausePanel.SetActive(levelInformation.isGameOnPause);

        // Set up pause panel

        pauseInternalState = levelInformation.isGameOnPause;
    }


    #region Save / load management system

    /// <summary>
    /// Get the file name to save / load options
    /// </summary>
    /// <returns>Gives the save data file name</returns>
    public static string GetFileName()
    {
        return Application.persistentDataPath + "/adventure.save";
    }

    /// <summary>
    /// Load adventure from disk
    /// </summary>
    public static void LoadAdventure()
    {
        if (wasAdventureDataLoaded == true)
        {
            levelInformation.isGameOnPause = false;
            Time.timeScale = 1.0f;
            return;
        }

        string fileName = GetFileName();

        adventureData = new Data.Adventure();
        bool result = Utils.FileManagement.CheckLoadData(ref adventureData, fileName);
        if (result == false)
        {
            // We create a new adventure
            Utils.FileManagement.SaveData(adventureData, fileName);
        }

        levelInformation = new Data.LevelInformation();

        wasAdventureDataLoaded = true;
    }

    /// <summary>
    /// Save adventure to disk
    /// </summary>
    public static void SaveAdventure()
    {
        string fileName = GetFileName();

        Utils.FileManagement.SaveData(adventureData, fileName);
    }

    /// <summary>
    /// Auto-save game at regular interval
    /// </summary>
    /// <returns>Returns an iterator </returns>
    public static IEnumerator AutoSaveAdventure()
    {
        float timeSaveInterval = 60.0f;

        levelInformation.autoSave = true;

        while(levelInformation.autoSave == true)
        {
            yield return new WaitForSeconds(timeSaveInterval);

            SaveAdventure();
        }
    }

    public static void ReturnToGameTitle()
    {
        // Stops the autosave coroutine
        levelInformation.autoSave = false;

        // Save adventure
        SaveAdventure();

        // Return to game title
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }

    #endregion

    #region Level Management

    /// <summary>
    /// Load a level
    /// </summary>
    public void LoadLevel()
    {
#if UNITY_EDITOR
		if (m_forceLevel == true)
		{
			adventureData.level = m_forceLevelId;
		}
#endif // UNITY_EDITOR

        bool hasToLoadLevel = false;

        if (adventureData.level <= MAX_LEVELS)
        {
            levelInformation.levelName = "Level " + adventureData.level.ToString();
            hasToLoadLevel = true;
        }

        if (hasToLoadLevel == true)
        {
            levelInformation.isLevelEndReached = false;
            levelInformation.isLifeLost = false;
            Utils.ExtraSceneManagement.Load(levelInformation.levelName);
        }


        // We display lives and powerups
        uIManagement.DisplayLives();
        uIManagement.UpdatePowerup();

        // Save game on level load
        SaveAdventure();

        // Make the fade out for the fading
        fading.FadeOut();

    }

    /// <summary>
    /// Load a new level - this function can be set into a coroutine
    /// </summary>
    public IEnumerator LoadNewLevel()
    {
        // Check for the player (marked as clone since it has been instanciated by the Instanciate command)
        GameObject player = GameObject.Find("Player(Clone)");

        // If that player was set, destroy it
        if (player != null)
        {
            Destroy(player);
        }

        // Make the fade in for the fading
        fading.FadeIn();

        yield return new WaitForSeconds(fading.GetFadePeriod());

        // Reload level
        Utils.ExtraSceneManagement.Reload("Game");

    }
    
    /// <summary>
    /// Function called when a life is lost
    /// </summary>
    public void LifeLost()
    {
        adventureData.lives--;

        if (adventureData.lives != 0)
        {
            StartCoroutine(LoadNewLevel());
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    public IEnumerator GameOver()
    {

        UnloadUI();

        // Check for the player (marked as clone since it has been instanciated by the Instanciate command)
        GameObject player = GameObject.Find("Player(Clone)");

        // If that player was set, destroy it
        if (player != null)
        {
            Destroy(player);
        }

        // Make the fade in for the fading
        fading.FadeIn();

        yield return new WaitForSeconds(fading.GetFadePeriod());

        // Unload level
        Utils.ExtraSceneManagement.Unload(levelInformation.levelName);

        ResetGame();

        uIManagement.gameOverPanel.SetActive(true);
    }

    private void UnloadUI()
    {
        uIManagement.uIPanel.SetActive(false);
        uIManagement.androidPanel.SetActive(false);
    }

    public void ResetGame()
    {
        adventureData = new Data.Adventure();

        SaveAdventure();
    }



    #endregion

}
