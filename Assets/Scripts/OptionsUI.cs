using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that generates 
/// </summary>
public class OptionsUI : MonoBehaviour
{

    /// <summary>
    /// Music volume controller
    /// </summary>
    public Slider volumeSlider;
    public Toggle volumeToggle;

    /// <summary>
    /// Sound volume controller
    /// </summary>
    public Slider soundSlider;
    public Toggle soundToggle;

    // Start is called before the first frame update
    void Start()
    {
        OptionsHandler.LoadOptions();
        SetUpVolume();
    }

    /// <summary>
    /// Set up volume and sound information
    /// </summary>
    private void SetUpVolume()
    {
        // Set up music volume information
        volumeSlider.value = 10.0f * OptionsHandler.options.musicVolume;
        volumeToggle.isOn = OptionsHandler.options.muteMusic;
        // Set up sound volume information
        soundSlider.value = 10.0f * OptionsHandler.options.soundVolume;
        soundToggle.isOn = OptionsHandler.options.muteSound;
    }

    /// <summary>
    /// Update the music volume information w.r.t. the slider
    /// </summary>
    public void UpdateVolumeSlider()
    {
        OptionsHandler.options.musicVolume = volumeSlider.value / 10.0f;
    }

    /// <summary>
    /// Update the music mute information w.r.t. the toggle
    /// </summary>
    public void UpdateVolumeToggle()
    {
        OptionsHandler.options.muteMusic = volumeToggle.isOn;
    }

    /// <summary>
    /// Update the sound volume information w.r.t. the slider
    /// </summary>
    public void UpdateSoundSlider()
    {
        OptionsHandler.options.soundVolume = soundSlider.value / 10.0f;
    }

    /// <summary>
    /// Update the sound mute information w.r.t. the toggle
    /// </summary>
    public void UpdateSoundToggle()
    {
        OptionsHandler.options.muteSound = soundToggle.isOn;
    }
}
