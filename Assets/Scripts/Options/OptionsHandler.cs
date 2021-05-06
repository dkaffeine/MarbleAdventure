using UnityEngine;

/// <summary>
/// Options handler class
/// </summary>
public class OptionsHandler : MonoBehaviour
{

    /// <summary>
    /// Static reference handler to options structure
    /// </summary>
    public static Data.Options options;

    /// <summary>
    /// Static flag determining if options were loaded at least once
    /// </summary>
    private static bool wasOptionsLoaded = false;

    /// <summary>
    /// Architecture enumerator
    /// </summary>
    public enum Architecture
    {
        standalone,
        mobile,
        webGL
    }

    /// <summary>
    /// Architecture
    /// </summary>
    public static Architecture architecture = Architecture.standalone;

    /// <summary>
    /// Method called on start, before the first frame
    /// </summary>
    void Awake()
    {
        LoadOptions();
    }

    private void Start()
    {
        SetResolution();
    }

    /// <summary>
    /// Get the file name to save / load options
    /// </summary>
    /// <returns>Gives the options file name</returns>
    public static string GetFileName()
    {
        return Application.persistentDataPath + "/options.save";
    }

    /// <summary>
    /// Load options from disk - this method would be run only ONCE
    /// </summary>
    public static void LoadOptions()
    {

        if (wasOptionsLoaded == true)
        {
            // If options were already loaded, return and do nothing
            return;
        }

        string fileName = GetFileName();

        options = new Data.Options();
        bool result = Utils.FileManagement.CheckLoadData(ref options, fileName);
        if (result == false)
        {
            // No option file are existing on the disk, we gonna save it
            Utils.FileManagement.SaveData(options, fileName);
        }
        wasOptionsLoaded = true;
    }

    /// <summary>
    /// Save options to disk
    /// </summary>
    public static void SaveOptions()
    {
        string fileName = GetFileName();

        Utils.FileManagement.SaveData(options, fileName);
    }

    /// <summary>
    /// Sets the game resolution
    /// </summary>
    public static void SetResolution()
    {
#if UNITY_EDITOR
        // We do not call the screen resolution feature 
        return;
#else
        if (architecture != Architecture.standalone)
        {
            // On WebGL or on Android, we do not use the set resolution feature
            return;
        }

        options.screenResolution.SetResolution(options.fullScreen);
#endif
    }

    /// <summary>
    /// Get the current music information
    /// </summary>
    /// <returns>Returns the music value, as a float number between 0 and 1</returns>
    public static float GetMusicVolume()
    {
        if (options != null)
            return options.musicVolume;
        else
            return 1.0f;
    }

    /// <summary>
    /// Get the current music mute status
    /// </summary>
    /// <returns>Returns the music status, as a boolean</returns>
    public static bool GetMusicMute()
    {
        if (options != null)
            return options.muteMusic;
        else
            return false;
    }

    /// <summary>
    /// Get the current sound effect information
    /// </summary>
    /// <returns>Returns the sound effect value, as a float number between 0 and 1</returns>
    public static float GetSoundVolume()
    {
        if (options != null)
            return options.soundVolume;
        else
            return 1.0f;
    }

    /// <summary>
    /// Get the current sound effect mute status
    /// </summary>
    /// <returns>Returns the sound effect status, as a boolean</returns>
    public static bool GetSoundMute()
    {
        if (options != null)
            return options.muteSound;
        else
            return false;
    }
    
}
