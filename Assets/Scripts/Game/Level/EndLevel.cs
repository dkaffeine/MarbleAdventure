using UnityEngine;

public class EndLevel : MonoBehaviour
{

    /// <summary>
    /// Information about the new level to reach
    /// </summary>
    public uint levelToJump;

    /// <summary>
    /// Trigger function when an entity enters the collider box
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
