using UnityEngine;

/// <summary>
/// Generic volume class
/// </summary>
public abstract class GenericVolume : MonoBehaviour
{

    [Tooltip("Associated audio source")]
    public AudioSource audioSource;

    [Tooltip("Base volume")]
    [Range(0, 1)]
    public float baseVolume = 1.0f;

    // Reset method is called once we attach the script for the first time, or when the reset button is called
    private void Reset()
    {
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        OptionsHandler.LoadOptions();

        if (audioSource == null)
            audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Set audio
    protected abstract void SetVolume();

    // Update is called once per frame
    void Update()
    {
        SetVolume();
    }

    /// <summary>
    /// Play the associated audio source, if this audio source exists
    /// </summary>
    public virtual void Play()
    {
        if (audioSource == null)
        {
            // If the audio source is not defined, do nothing
            return;
        }
        audioSource.Play();
    }

    /// <summary>
    /// Stops the associated audio source, if this audio source exits
    /// </summary>
    public virtual void Stop()
    {
        if (audioSource == null)
        {
            // If the audio source is not defined, do nothing
            return;
        }
        audioSource.Stop();
    }
}
