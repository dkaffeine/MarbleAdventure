using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : InteractableElement
{

    [Tooltip("The interactable element that will be triggered by this button")]
    public InteractableElement interactableElement;

    public VolumeSE volumeSE;

    [Tooltip("The status of the associated interactable element")]
    public bool newStatus = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, GameEngine.interactableRotationSpeed * Time.deltaTime, 0);

        transform.Rotate(eulerAngles);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactableActivated && other.CompareTag("Player"))
        {
            // If that trigger is actiaved and it collides the player, we activate the button
            interactableActivated = false;
            volumeSE.Play();

            Light light = GetComponentInChildren<Light>();
            if (light)
            {
                light.enabled = true;
            }

            if (interactableElement && newStatus == true)
            {
                interactableElement.PerformInteraction();
            }

            if (interactableElement && newStatus == false)
            {
                interactableElement.PerformUninteraction();
            }

        }
    }
}
