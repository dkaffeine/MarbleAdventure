namespace Data
{
    /// <summary>
    /// Adventure class that will save all adventure data
    /// </summary>
    [System.Serializable]
    public class Adventure
    {
        public float speed = 500.0f;
        public uint level = 1;
        public uint lives = 3;
        public uint livesMax = 3;
        public long money = 0;
        public PowerupType powerup = PowerupType.None;
    }
}