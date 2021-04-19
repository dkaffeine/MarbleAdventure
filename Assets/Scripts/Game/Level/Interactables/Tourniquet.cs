using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourniquet : InteractableElement
{

    /// <summary>
    /// Rotation speed
    /// </summary>
    public float rotationSpeed = 45.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactableActivated)
        {
            Vector3 eulerAngles = new Vector3(0.0f, rotationSpeed * Time.deltaTime, 0.0f);

            transform.Rotate(eulerAngles);
        }
    }
}
