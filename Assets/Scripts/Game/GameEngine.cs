using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
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
    private static Data.LevelInformation levelInformation;

    /// <summary>
    /// Handler to UI
    /// </summary>
    public UIManagement uIManagement;

    /// <summary>
    /// Internal pause state
    /// </summary>
    private bool pauseInternalState = false;


    // Start is called before the first frame update
    void Start()
    {
        LoadAdventure();

        LoadLevel();
    }

    private void FixedUpdate()
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

        bool hasToLoadLevel = false;

        switch (adventureData.level)
        {
            case 1:
                levelInformation.levelName = "Level 1";
                hasToLoadLevel = true;
                break;
            default:
                break;
        }

        if (hasToLoadLevel == true)
        {
            levelInformation.isLevelEndReached = false;
            levelInformation.isLifeLost = false;
            Utils.ExtraSceneManagement.Load(levelInformation.levelName);
        }

        // We display lives

        uIManagement.DisplayLives();
    }

    /// <summary>
    /// Unload a level
    /// </summary>
    public void UnloadLevel()
    {
        // TODO: destroy the player if that player is present

        Utils.ExtraSceneManagement.Unload(levelInformation.levelName);

        // We remove lives displayed

        uIManagement.RemoveLivesDisplayed();

    }

    /// <summary>
    /// Load a new level - this function can be set into a coroutine
    /// </summary>
    public IEnumerator LoadNewLevel()
    {
        UnloadLevel();

        yield return new WaitForSeconds(5.0f);

        LoadLevel();
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
            GameOver();
        }
    }

    public void GameOver()
    {
        UnloadLevel();

        ResetGame();

        // TODO : game over display with choice
    }

    public void ResetGame()
    {
        adventureData.lives = adventureData.livesMax;
        adventureData.level = 1;
    }



    #endregion


    // Update is called once per frame
    void Update()
    {
        
    }
}
