using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTriggerButton : InteractableElement
{

    public InteractableElement interactableElement;

    public VolumeSE volumeSE;

    public bool newStatus = true;

    public float timer = 10.0f;

    public TextMesh timerText;

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

    public void SetTimerText(float timeToDisplay)
    {
        timerText.text = "Timer: " + timeToDisplay.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactableActivated && other.CompareTag("Player"))
        {
            // If that trigger is actiaved and it collides the player, we activate the button
            interactableActivated = false;
            volumeSE.Play();


            if (interactableElement && newStatus == true)
            {
                StartCoroutine(StartInteractionCoroutine());
            }

            if (interactableElement && newStatus == false)
            {
                StartCoroutine(StartUninteractionCoroutine());
            }

        }
    }

    private IEnumerator StartInteractionCoroutine()
    {
        Light light = GetComponentInChildren<Light>();
        if (light)
        {
            light.enabled = true;
        }
        interactableElement.PerformInteraction();
        yield return new WaitForSeconds(timer);
        interactableElement.PerformUninteraction();
        if (light)
        {
            light.enabled = false;
        }
    }

    private IEnumerator StartUninteractionCoroutine()
    {
        Light light = GetComponentInChildren<Light>();
        if (light)
        {
            light.enabled = true;
        }
        interactableElement.PerformUninteraction();
        yield return new WaitForSeconds(timer);
        interactableElement.PerformInteraction();
        if (light)
        {
            light.enabled = false;
        }
    }

}
