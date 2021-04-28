using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcealPlatform : InteractableElement
{
    /// <summary>
    /// Handle to inner platform
    /// </summary>
    public GameObject innerPlatform;

    // Start is called before the first frame update
    void Start()
    {
        SetVisibility();
    }

    public void SetVisibility()
    {
        if (innerPlatform != null)
            innerPlatform.SetActive(interactableActivated);
    }

    // Update is called once per frame
    void Update()
    {
        SetVisibility();
    }
}
