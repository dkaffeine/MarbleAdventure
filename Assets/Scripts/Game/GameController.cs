using UnityEngine;

public class GameController : MonoBehaviour
{

    /// <summary>
    /// Get horizontal axis 
    /// </summary>
    /// <returns>Value between -1 and +1</returns>
    public float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// Get vertical axis
    /// </summary>
    /// <returns>Value between -1 and +1</returns>
    public float GetVerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Get the action on jump
    /// </summary>
    /// <returns>State about the key pressed</returns>
    public bool GetJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    /// <summary>
    /// Get pause
    /// </summary>
    /// <returns>State about the key pressed</returns>
    public bool GetPausePressed()
    {
        return Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape);
    }
}
