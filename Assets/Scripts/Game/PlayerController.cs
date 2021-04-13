using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// Handler to game controller structure
    /// </summary>
    public GameController gameController;

    /// <summary>
    /// Handler to the focal point
    /// </summary>
    public GameObject focalPoint;


    // Start is called before the first frame update
    void Start()
    {

        // Get the game controller structure from the scene
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // Get the focal point object
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
