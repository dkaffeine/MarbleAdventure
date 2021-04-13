using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Generic class to handle with button interaction
/// </summary>
public class ButtonInteraction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    /// <summary>
    /// Handler to the keycode on the keyboard
    /// </summary>
    public KeyCode keyCode;

    /// <summary>
    /// Internal state about the button on the UI pressed
    /// </summary>
    private bool isUIButtonPressed = false;
    
    /// <summary>
    /// Internal state about the button pressed
    /// </summary>
    private bool isPressed = false;

    /// <summary>
    /// Internal state about the button pressed at previous iteration
    /// </summary>
    private bool wasPressed = false;

    /// <summary>
    /// Internal state about the fact the button has been pushed
    /// </summary>
    private bool isPushed = false;

    /// <summary>
    /// Internal state about the fact the button has been released
    /// </summary>
    private bool isReleased = false;

    /// <summary>
    /// Method called when button internal state
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        isUIButtonPressed = true;
    }

    /// <summary>
    /// Method called when button internal state is up
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        isUIButtonPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Button is pressed if UI button is pressed or associated keycode is pressed
        isPressed = isUIButtonPressed || Input.GetKey(keyCode);

        // Checks if the button is pushed, means press goes from false to true state
        isPushed = (wasPressed == false && isPressed == true) ? true : false;

        // Checks if the button is released, means press goes from true to false state
        isReleased = (wasPressed == true && isPressed == false) ? true : false;

        // Updates internal state
        wasPressed = isPressed;
    }

    public bool IsPressed()
    {
        return isPressed;
    }

    public bool IsPushed()
    {
        return isPushed;
    }

    public bool IsReleased()
    {
        return isReleased;
    }
}
