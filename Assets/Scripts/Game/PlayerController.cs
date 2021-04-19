using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// Handler to game engine and game controller structure
    /// </summary>
    private GameEngine gameEngine;
    private GameController gameController;

    /// <summary>
    /// Handler to the focal point
    /// </summary>
    private GameObject focalPoint;

    /// <summary>
    /// Handler to the player rigidbody
    /// </summary>
    private Rigidbody playerRigidbody;

    /// <summary>
    /// Sphere radius
    /// </summary>
    private float playerSphereRadius = 0.5f;

    /// <summary>
    /// Gives the state being on ground
    /// </summary>
    private bool isOnGround = false;

    /// <summary>
    /// Gives the state being able to make an mid-air action
    /// </summary>
    private bool canMidAirAction = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the game engine structure from the scene
        gameEngine = GameObject.Find("GameEngine").GetComponent<GameEngine>();

        // Get the game controller structure from the scene
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // Get the focal point object, and resets that point to the original view (identity)
        focalPoint = GameObject.Find("FocalPoint");
        focalPoint.transform.rotation = Quaternion.identity;

        // Get rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPauseButton();

        UpdateJump();

        UpdateEntities();

        CheckLowerBound();
    }

    /// <summary>
    /// Checks pause button
    /// </summary>
    private void CheckPauseButton()
    {
        if (gameController.GetPausePressed())
        {
            GameEngine.levelInformation.isGameOnPause = !GameEngine.levelInformation.isGameOnPause;
        }
    }

    /// <summary>
    /// Update entities with respect to controllers
    /// </summary>
    private void UpdateEntities()
    {
        if (GameEngine.levelInformation.isGameOnPause == true)
        {
            // If game is on pause, no controller interaction is taken into account
            return;
        }
        
        // Horizontal displacement allowed only if the player is touching the ground
        if (isOnGround)
        {
            // Update forward / backward force, depending on the vertical input
            float forwardInput = gameController.GetVerticalAxis();
            playerRigidbody.AddForce(focalPoint.transform.forward * GameEngine.adventureData.speed * Time.deltaTime * forwardInput);
        }

        // Update left / right, depending on the horizontal input
        float horizontalAxis = gameController.GetHorizontalAxis();
        focalPoint.transform.Rotate(focalPoint.transform.up, horizontalAxis * Time.deltaTime * 90.0f);

        // Update focal point position on player position
        focalPoint.transform.position = GetGroundPosition();
    }

    /// <summary>
    /// Method that handles with the jump feature, has to be checked on each frame
    /// </summary>
    private void UpdateJump()
    {
        if (GameEngine.levelInformation.isGameOnPause == true)
        {
            return;
        }
        bool spacePressed = gameController.GetJump();
        if (spacePressed)
        {
            if (isOnGround)
            {
                isOnGround = false;
                playerRigidbody.AddForce(focalPoint.transform.up * 10.0f, ForceMode.Impulse);
            }
            else if (canMidAirAction)
            {
                canMidAirAction = false;
                switch(GameEngine.adventureData.powerup)
                {
                    case PowerupType.Dash:
                        playerRigidbody.AddForce(focalPoint.transform.forward * 30.0f, ForceMode.Impulse);
                        break;
                    case PowerupType.DoubleJump:
                        playerRigidbody.AddForce(focalPoint.transform.up * 10.0f, ForceMode.Impulse);
                        break;
                    case PowerupType.Gravity:
                        playerRigidbody.AddForce(focalPoint.transform.up * -10.0f, ForceMode.Impulse);
                        break;
                    default:
                        // By default, there's no mid-air action
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Gets the ground position
    /// </summary>
    /// <returns>Ground point</returns>
    Vector3 GetGroundPosition()
    {
        Vector3 returnValue = transform.position - new Vector3(0, playerSphereRadius, 0);
        return returnValue;
    }

    private void CheckLowerBound()
    {
        ///If the player entity is too low, a life is lost
        if (transform.position.y < -10.0f)
        {
            GameEngine.levelInformation.isLifeLost = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the player collides the ground, the jump status is reset
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            canMidAirAction = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            StartCoroutine(CoinTrigger(other));
        }

        if (other.CompareTag("Powerup"))
        {
            StartCoroutine(PowerupTrigger(other));
        }

        if (other.CompareTag("BuyableObject"))
        {
            StartCoroutine(BuyableObjectTrigger(other));
        }

    }

    private IEnumerator CoinTrigger(Collider coin)
    {
        if (coin.GetComponent<Coin>().coinTriggered == true)
        {
            yield return null;
        }

        coin.GetComponent<Coin>().volumeSE.Play();
        yield return new WaitForSeconds(0.157f);
        GameEngine.adventureData.money += coin.GetComponent<Coin>().coinValue;
        Destroy(coin.gameObject);
    }

    public IEnumerator PowerupTrigger(Collider powerup)
    {
        PowerupType powerupType = powerup.GetComponent<Powerup>().powerupType;
        if (powerupType != GameEngine.adventureData.powerup)
        { 
            // Since the powerup is different, we gonna do stuff
            GameEngine.adventureData.powerup = powerupType;
            powerup.GetComponent<Powerup>().volumeSE.Play();
            gameEngine.uIManagement.UpdatePowerup();
        }
        yield return null;
    }

    private IEnumerator BuyableObjectTrigger(Collider buyableObject)
    {
        uint itemPrice = buyableObject.GetComponent<ShowcaseItem>().itemPrice;
        ShowcaseItem.ItemType itemType = buyableObject.GetComponent<ShowcaseItem>().itemType;

        if (GameEngine.adventureData.money < itemPrice)
        {
            // If we don't have enough money
            yield return null;
        }

        GameEngine.adventureData.money -= itemPrice;

        buyableObject.GetComponent<ShowcaseItem>().volumeSE.Play();
        yield return new WaitForSeconds(0.157f);
        Destroy(buyableObject.gameObject);

        yield return null;
    }

}
