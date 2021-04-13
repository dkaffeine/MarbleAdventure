using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /// <summary>
    /// Handler to game controller structure
    /// </summary>
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Get the game controller structure from the scene
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = gameController.GetHorizontalAxis();
        transform.Rotate(Vector3.up, horizontalAxis * Time.deltaTime * 90.0f);
    }
}
