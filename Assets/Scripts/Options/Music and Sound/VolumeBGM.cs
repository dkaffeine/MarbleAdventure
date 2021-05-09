using UnityEngine;

public class VolumeBGM : GenericVolume
{
    [Tooltip("Should the BGM be played when this script starts?")]
    public bool playOnStart = false;

    private float fadeCoefficient = 1.0f;
    public bool fadeOut = false;
    public bool fadeIn = false;

    protected override void SetVolume()
    {
        if (audioSource == null)
        {
            // If the audio source is not defined, do nothing
            return;
        }
        audioSource.volume = baseVolume * fadeCoefficient * OptionsHandler.GetMusicVolume();
        audioSource.mute = OptionsHandler.GetMusicMute();
    }

    private void FixedUpdate()
    {
        Fade();
    }

    /// <summary>
    /// Fading function, deals with both fading in and fading out
    /// </summary>
    private void Fade()
    {
        float fadeCoefficientIn = 1.0f;
        float fadeCoefficientOut = 1.0f;

        if (fadeOut)
        {
            fadeCoefficient -= fadeCoefficientOut * Time.fixedDeltaTime;
            if (fadeCoefficient < 0f)
            {
                fadeCoefficient = 0f;
                fadeOut = false;
            }
        }

        if (fadeIn)
        {
            fadeCoefficient += fadeCoefficientIn * Time.fixedDeltaTime;
            if (fadeCoefficient > 1f)
            {
                fadeCoefficient = 1f;
                fadeIn = false;
            }
        }
    }

    /// <summary>
    /// Fades out
    /// </summary>
    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false;
    }

    /// <summary>
    /// Fades in
    /// </summary>
    public void FadeIn()
    {
        fadeIn = true;
        fadeOut = false;
    }
}
