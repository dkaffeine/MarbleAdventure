using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public ButtonInteraction upButton;
    public ButtonInteraction downButton;
    public ButtonInteraction leftButton;
    public ButtonInteraction rightButton;
    public ButtonInteraction jumpButton;
    public ButtonInteraction pauseButton;

    private float HorizontalAxisValue { get; set; }
    private float VerticalAxisValue { get; set; }

    // Note that the acceleration speed corresponds to the sensitivity value of axis
    // in the build settings (Ctrl+Shift+B)
    public static float accelerationSpeed = 3.0f;
    // Note that the decceleration speed corresponds to the gravity value of axis
    public static float deccelerationSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        HorizontalAxisValue = 0.0f;
        VerticalAxisValue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHorizontalAxis();
        UpdateVerticalAxis();
    }

    private void UpdateHorizontalAxis()
    {
        bool isLeftPressed = leftButton.IsPressed();
        bool isRightPressed = rightButton.IsPressed();

        // Only left is pressed: acceleration towards min speed
        if (isLeftPressed && !isRightPressed)
        {
            HorizontalAxisValue -= accelerationSpeed * Time.deltaTime;
            HorizontalAxisValue = Mathf.Max(HorizontalAxisValue, -1.0f);
            return;
        }

        // Only right is pressed: acceleration towards max speed
        if (!isLeftPressed && isRightPressed)
        {
            HorizontalAxisValue += accelerationSpeed * Time.deltaTime;
            HorizontalAxisValue = Mathf.Min(HorizontalAxisValue, 1.0f);
            return;
        }

        // Otherwise, decceleration towards neutral position
        if (HorizontalAxisValue > 0.0f)
        {
            HorizontalAxisValue -= deccelerationSpeed * Time.deltaTime;
            HorizontalAxisValue = Mathf.Max(HorizontalAxisValue, 0.0f);
        }
        if (HorizontalAxisValue < 0.0f)
        {
            HorizontalAxisValue += deccelerationSpeed * Time.deltaTime;
            HorizontalAxisValue = Mathf.Min(HorizontalAxisValue, 0.0f);
        }
    }

    private void UpdateVerticalAxis()
    {
        bool isUpPressed = upButton.IsPressed();
        bool isDownPressed = downButton.IsPressed();

        // Only down is pressed: acceleration towards min speed
        if (isDownPressed && !isUpPressed)
        {
            VerticalAxisValue -= accelerationSpeed * Time.deltaTime;
            VerticalAxisValue = Mathf.Max(VerticalAxisValue, -1.0f);
            return;
        }

        // Only up is pressed: acceleration towards max speed
        if (!isDownPressed && isUpPressed)
        {
            VerticalAxisValue += accelerationSpeed * Time.deltaTime;
            VerticalAxisValue = Mathf.Min(VerticalAxisValue, 1.0f);
            return;
        }

        // Otherwise, decceleration towards neutral position
        if (VerticalAxisValue > 0.0f)
        {
            VerticalAxisValue -= deccelerationSpeed * Time.deltaTime;
            VerticalAxisValue = Mathf.Max(VerticalAxisValue, 0.0f);
        }
        if (VerticalAxisValue < 0.0f)
        {
            VerticalAxisValue += deccelerationSpeed * Time.deltaTime;
            VerticalAxisValue = Mathf.Min(VerticalAxisValue, 0.0f);
        }
    }

    /// <summary>
    /// Get horizontal axis 
    /// </summary>
    /// <returns>Value between -1 and +1</returns>
    public float GetHorizontalAxis()
    {
        return HorizontalAxisValue;
    }

    /// <summary>
    /// Get vertical axis
    /// </summary>
    /// <returns>Value between -1 and +1</returns>
    public float GetVerticalAxis()
    {
        return VerticalAxisValue;
    }

    /// <summary>
    /// Get the action on jump
    /// </summary>
    /// <returns>State about the key pressed</returns>
    public bool GetJump()
    {
        return jumpButton.IsPushed();
    }

    /// <summary>
    /// Get pause
    /// </summary>
    /// <returns>State about the key pressed</returns>
    public bool GetPausePressed()
    {
        return pauseButton.IsPushed();
    }
}
