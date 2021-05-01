using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTriggerButton : InteractableElement
{

    public InteractableElement interactableElement;

    public VolumeSE volumeSE;

    public bool newStatus = true;

    public float countDownTimer = 10.0f;

    private float currentTimer = 0.0f;

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

        if(currentTimer != 0.0f)
        {
            // If the timer is running, run it
            RunTriggeredTimer();
        }
    }

    private void RunTriggeredTimer()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0.0f)
        {
            // If timer runs out
            currentTimer = 0.0f;

            SetNewStatus(false);
        }
    }

    private void FixedUpdate()
    {
        if (currentTimer == 0.0f)
        {
            timerText.text = "";
        }
        else
        {
            SetTimerText(0.1f * Mathf.Round(10.0f * currentTimer));
        }
    }


    public void SetTimerText(float timeToDisplay)
    {
        timerText.text = "Timer: " + timeToDisplay.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactableActivated && other.CompareTag("Player") && currentTimer == 0.0f)
        {
            // If the player triggers the interactable and the timer is not running
            currentTimer = countDownTimer;

            volumeSE.Play();

            SetNewStatus(true);
        }
    }

    private void SetNewStatus(bool flag)
    {
        if (interactableElement)
        {
            Light light = GetComponentInChildren<Light>();
            // We trigger light below interactable
            if (light)
            {
                light.enabled = flag;
            }

            // We trigger interactable
            if (newStatus == flag)
            {
                interactableElement.PerformInteraction();
            }
            else
            {
                interactableElement.PerformUninteraction();
            }
        }
    }

}
