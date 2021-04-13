namespace Data
{ 

    /// <summary>
    /// Structure handler for level information
    /// </summary>
    [System.Serializable]
    public class LevelInformation
    {
        public bool isLevelEndReached = false;
        public bool isLifeLost = false;
        public bool isGameOnPause = false;
        public bool autoSave = false;
        public string levelName = "Level 1";
    }
}