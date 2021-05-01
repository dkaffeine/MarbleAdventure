using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [Tooltip("Should this interactable be activated?")]
    public bool interactableActivated = false;

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
    public virtual void PerformInteraction()
    {
        interactableActivated = true;
    }

    /// <summary>
    /// Deactivation function
    /// </summary>
    public virtual void PerformUninteraction()
    {
        interactableActivated = false;
    }
}
