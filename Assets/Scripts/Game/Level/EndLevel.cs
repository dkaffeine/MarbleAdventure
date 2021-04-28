using UnityEngine;

public class EndLevel : MonoBehaviour
{

    /// <summary>
    /// Information about the new level to reach
    /// </summary>
    private uint levelToJump;

    public void SetLevelToJump(uint value)
    {
        levelToJump = value;
    }

    /// <summary>
    /// Trigger function when an entity collides the box
    /// </summary>
    /// <param name="other">Entity collider</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEngine.adventureData.level = levelToJump;
            GameEngine.levelInformation.isLevelEndReached = true;
        }
    }
}
