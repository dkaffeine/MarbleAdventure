using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupType powerupType;

    public VolumeSE volumeSE;

    public GameObject dashIcon, doubleJumpIcon, gravityIcon;

    // Start is called before the first frame update
    void Start()
    {
        ActivateIcon();
    }

    public void ActivateIcon()
    {
        switch (powerupType)
        {
            case PowerupType.Dash:
                dashIcon.SetActive(true);
                doubleJumpIcon.SetActive(false);
                gravityIcon.SetActive(false);
                break;
            case PowerupType.DoubleJump:
                dashIcon.SetActive(false);
                doubleJumpIcon.SetActive(true);
                gravityIcon.SetActive(false);
                break;
            case PowerupType.Gravity:
                dashIcon.SetActive(false);
                doubleJumpIcon.SetActive(false);
                gravityIcon.SetActive(true);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, GameEngine.interactableRotationSpeed * Time.deltaTime, 0);

        transform.Rotate(eulerAngles);
    }
}
