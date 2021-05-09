using UnityEngine;

public class RandomSoundEffect : VolumeSE
{
    /// <summary>
    /// List of possible sound effects
    /// </summary>
    [Tooltip("List of sound effects")]
    public VolumeSE[] volumes;

    public override void Play()
    {
        if (volumes != null && volumes.Length != 0)
        {
            int index = Random.Range(0, volumes.Length);
            volumes[index].Play();
        }
        else
        {
            base.Play();
        }
    }

    public override void Stop()
    {
        if (volumes != null && volumes.Length != 0)
        {
            foreach(VolumeSE volumeSE in volumes)
            {
                volumeSE.Stop();
            }
        }
        else
        {
            base.Stop();
        }
    }
}
