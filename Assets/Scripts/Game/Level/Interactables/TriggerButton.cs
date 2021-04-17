using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : InteractableElement
{

    private static readonly float rotationDegreesPerSecond = 180.0f;

    public InteractableElement interactableElement;

    public VolumeSE volumeSE;

    // Start is called before the first frame update
    void Start()
    {
        volumeSE = gameObject.GetComponent<VolumeSE>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, rotationDegreesPerSecond * Time.deltaTime, 0);

        transform.Rotate(eulerAngles);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activate && other.CompareTag("Player"))
        {
            // If that trigger is actiaved and it collides the player, we activate the button
            activate = false;
            volumeSE.Play();

            Light light = GetComponentInChildren<Light>();
            if (light)
            {
                light.enabled = true;
            }

            if (interactableElement)
            {
                interactableElement.PerformInteraction();
            }
        }
    }
}
