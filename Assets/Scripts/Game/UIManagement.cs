using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{

    /// <summary>
    /// Sprite for the empty heart container
    /// </summary>
    public Sprite heartContainerEmpty;

    /// <summary>
    /// Sprite for the full heart container
    /// </summary>
    public Sprite heartContainerFull;

    /// <summary>
    /// Internal name for the hearts displayed on the UI
    /// </summary>
    readonly string heartName = "Heart Displayed";

    /// <summary>
    /// Hear size in pixels
    /// </summary>
    const float heartSize = 80.0f;

    /// <summary>
    /// Handler to the UI
    /// </summary>
    public Canvas canvas;

    /// <summary>
    /// Handler to the pause panel
    /// </summary>
    public GameObject pausePanel;

    /// <summary>
    /// Removes lives displayed
    /// </summary>
    public void RemoveLivesDisplayed()
    {
        foreach (GameObject gameObj in FindObjectsOfType(typeof(GameObject)))
        {
            if (gameObj.name == heartName)
            {
                Destroy(gameObj);
            }
        }
    }

    /// <summary>
    /// Display lives
    /// </summary>
    public void DisplayLives()
    {
        for (uint live = GameEngine.adventureData.livesMax; live >= 1; live--)
        {
            GameObject gameObject = new GameObject();
            Image image = gameObject.AddComponent<Image>();
            if (live <= GameEngine.adventureData.lives)
            {
                // The displayed live is a live the player has
                image.sprite = heartContainerFull;
            }
            else
            {
                // The displayed live corresponds to one of the lives lost by the player
                image.sprite = heartContainerEmpty;
            }

            // Set the image in the UI structure
            image.GetComponent<RectTransform>().SetParent(canvas.transform);

            // Set image position
            Vector3 imagePosition = new Vector3((0.5f * heartSize) + 50 * (live - 1), 460);
            image.rectTransform.position = imagePosition;

            // Set image size
            Vector2 imageSize = new Vector2(heartSize, heartSize);
            image.rectTransform.sizeDelta = imageSize;
            image.name = heartName;
        }
    }
}
