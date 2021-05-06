namespace Data
{
    /// <summary>
    /// Adventure class that will save all adventure data
    /// </summary>
    [System.Serializable]
    public class Adventure
    {
        /// <summary>
        /// Starting level
        /// </summary>
        public uint level = 0;

        /// <summary>
        /// Starting number of lives
        /// </summary>
        public uint lives = 3;

        /// <summary>
        /// Starting number of maximum lives
        /// </summary>
        public uint livesMax = 3;

        /// <summary>
        /// Starting money
        /// </summary>
        public long money = 0;

        /// <summary>
        /// Starting powerup
        /// </summary>
        public PowerupType powerup = PowerupType.None;
    }
}