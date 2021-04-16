using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    /// <summary>
    /// Flag for platform activator
    /// </summary>
    public bool activate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Activation function
    /// </summary>
    public void PerformInteraction()
    {
        activate = true;
    }
}
