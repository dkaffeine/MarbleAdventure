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
    /// Method called on start, before the first frame
    /// </summary>
    void Start()
    {
        LoadOptions();
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
    /// Get the current music information, with the mute parameter taken into account
    /// </summary>
    /// <returns>Returns the music value, as a float number between 0 and 1</returns>
    public static float GetMusicVolume()
    {
        return options.muteMusic ? 0.0f : options.musicVolume;
    }

    /// <summary>
    /// Get the current music information, with the mute parameter taken into account
    /// </summary>
    /// <returns>Returns the music value, as a float number between 0 and 1</returns>
    public static float GetSoundVolume()
    {
        return options.muteSound ? 0.0f : options.soundVolume;
    }
}
