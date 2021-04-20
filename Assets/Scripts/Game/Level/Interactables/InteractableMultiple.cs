using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMultiple : InteractableElement
{

    public List<InteractableElement> interactables = new List<InteractableElement>();
    
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
    public override void PerformInteraction()
    {
        foreach(InteractableElement element in interactables)
        {
            element.PerformInteraction();
        }
    }

    /// <summary>
    /// Deactivation function
    /// </summary>
    public override void PerformUninteraction()
    {
        foreach (InteractableElement element in interactables)
        {
            element.PerformUninteraction();
        }
    }
}
