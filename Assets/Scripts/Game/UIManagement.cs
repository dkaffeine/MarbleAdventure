using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{


    /// <summary>
    /// Handler to the UI
    /// </summary>
    public Canvas canvas;

    /// <summary>
    /// Handler to the pause panel
    /// </summary>
    public GameObject pausePanel;

    /// <summary>
    /// Handler to the game over panel
    /// </summary>
    public GameObject gameOverPanel;

    /// <summary>
    /// Handler to the UI panel
    /// </summary>
    public GameObject uIPanel;

    /// <summary>
    /// Handler to the android panel
    /// </summary>
    public GameObject androidPanel;

    /// <summary>
    /// Handler to the level text
    /// </summary>
    public Text levelText;

    /// <summary>
    /// Handler to the money text
    /// </summary>
    public Text moneyText;

    #region Hearts displayed

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
    /// Handler to the first heart placeholder
    /// </summary>
    public Image heartPlaceholder;

    #endregion

    #region Powerup displayed

    /// <summary>
    /// Sprite to the powerup dash
    /// </summary>
    public Sprite powerupDash;

    /// <summary>
    /// Sprite to the powerup double jump
    /// </summary>
    public Sprite powerupDoubleJump;

    /// <summary>
    /// Sprite to the powerup gravity
    /// </summary>
    public Sprite powerupGravity;

    /// <summary>
    /// Internal name for the hearts displayed on the UI
    /// </summary>
    readonly string powerupName = "Powerup Displayed";

    /// <summary>
    /// Handler to the powerup placeholder
    /// </summary>
    public Image powerupPlaceholder;

    #endregion

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
            image.GetComponent<RectTransform>().SetParent(uIPanel.gameObject.transform);

            // Set image position
            float heartSize = heartPlaceholder.rectTransform.sizeDelta.x;
            Vector3 imagePosition = heartPlaceholder.rectTransform.position + new Vector3(0.625f * heartSize * (live - 1), 0);
            image.rectTransform.position = imagePosition;

            // Set image size
            Vector2 imageSize = new Vector2(heartSize, heartSize);
            image.rectTransform.sizeDelta = imageSize;

			// Set image name
            image.name = heartName;
        }
    }

    /// <summary>
    /// Update the money on fixed update
    /// </summary>
    private void FixedUpdate()
    {
        moneyText.text = "Money: " + GameEngine.adventureData.money.ToString();
        levelText.text = "Level: " + GameEngine.adventureData.level.ToString();
    }

    /// <summary>
    /// Removes the displayed powerup
    /// </summary>
    private void RemovePowerupDisplayed()
    {
        foreach (GameObject gameObj in FindObjectsOfType(typeof(GameObject)))
        {
            if (gameObj.name == powerupName)
            {
                Destroy(gameObj);
            }
        }
    }

    private void SetupPowerupSprite(Sprite sprite)
    {
        // Set sprite
        GameObject gameObject = new GameObject();
        Image image = gameObject.AddComponent<Image>();
        image.sprite = sprite;

        // Set hierarchy
        GameObject jumpButton = GameObject.Find("JumpButton");
        image.GetComponent<RectTransform>().SetParent(jumpButton.transform);

        // Set position
        Vector3 imagePosition = powerupPlaceholder.rectTransform.position;
        image.rectTransform.position = imagePosition;

        // Set size
        Vector2 imageSize = powerupPlaceholder.rectTransform.sizeDelta;
        image.rectTransform.sizeDelta = imageSize;

        // Set name
        image.name = powerupName;
    }


    /// <summary>
    /// Updates the powerup panel
    /// </summary>
    public void UpdatePowerup()
    {

        // First, remove powerup displayed
        RemovePowerupDisplayed();

        // Set up the power up, depending on the powerup type
        switch (GameEngine.adventureData.powerup)
        {
            case PowerupType.Dash:
                SetupPowerupSprite(powerupDash);
                break;
            case PowerupType.DoubleJump:
                SetupPowerupSprite(powerupDoubleJump);
                break;
            case PowerupType.Gravity:
                SetupPowerupSprite(powerupGravity);
                break;
            default:
                break;
        }
    }
}
