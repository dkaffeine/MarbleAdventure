public class VolumeSE : GenericVolume
{
    protected override void SetVolume()
    {
        if (audioSource == null)
        {
            // If the audio source is not defined, do nothing
            return;
        }
        audioSource.volume = baseVolume * OptionsHandler.GetSoundVolume();
        audioSource.mute = OptionsHandler.GetSoundMute();
    }
}
