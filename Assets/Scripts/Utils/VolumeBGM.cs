using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBGM : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void SetVolume()
    {
        if (audioSource == null)
        {
            // If the audio source is not defined, do nothing
            return;
        }
        audioSource.volume = OptionsHandler.GetMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {
        SetVolume();
    }

    public void Play()
    {
        if (audioSource == null)
        {
            // If the audio source is not defined, do nothing
            return;
        }
        audioSource.Play();
    }
}
