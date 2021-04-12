using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{

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

    // Start is called before the first frame update
    void Start()
    {
        LoadAdventure();

        LoadLevel();
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
    }

    /// <summary>
    /// Unload a level
    /// </summary>
    public void UnloadLevel()
    {
        // TODO: destroy the player if that player is present

        Utils.ExtraSceneManagement.Unload(levelInformation.levelName);
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
    

    #endregion


    // Update is called once per frame
    void Update()
    {
        
    }
}
