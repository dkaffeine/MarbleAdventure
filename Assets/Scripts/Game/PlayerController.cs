using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// Handler to game controller structure
    /// </summary>
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
    /// Gives the state being able to double-jump
    /// </summary>
    private bool canDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the game controller structure from the scene
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // Get the focal point object
        focalPoint = GameObject.Find("FocalPoint");
        focalPoint.transform.rotation = Quaternion.identity;

        // Get rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEntities();

        CheckLowerBound();
    }

    /// <summary>
    /// Update entities with respect to controllers
    /// </summary>
    private void UpdateEntities()
    {
        if (gameController.GetPausePressed())
        {
            GameEngine.levelInformation.isGameOnPause = !GameEngine.levelInformation.isGameOnPause;
        }
        
        if (GameEngine.levelInformation.isGameOnPause == true)
        { 
            // Update forward / backward force, depending on the vertical input
            float forwardInput = gameController.GetVerticalAxis();
            playerRigidbody.AddForce(focalPoint.transform.forward * GameEngine.adventureData.speed * forwardInput);

            // Update left / right, depending on the horizontal input
            float horizontalAxis = gameController.GetHorizontalAxis();
            focalPoint.transform.Rotate(focalPoint.transform.up, horizontalAxis * Time.deltaTime * 90.0f);

            // Update focal point position on player position
            focalPoint.transform.position = GetGroundPosition();

            
        }
    }
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
            canDoubleJump = true;
        }
    }
}
