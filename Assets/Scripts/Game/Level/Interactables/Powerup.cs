using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private static readonly float rotationDegreesPerSecond = 180.0f;

    public PowerupType powerupType;

    public VolumeSE volumeSE;

    public GameObject dashIcon, doubleJumpIcon, gravityIcon;

    // Start is called before the first frame update
    void Start()
    {
        volumeSE = gameObject.GetComponent<VolumeSE>();

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
                dashIcon.SetActive(false);
                doubleJumpIcon.SetActive(false);
                gravityIcon.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, rotationDegreesPerSecond * Time.deltaTime, 0);

        transform.Rotate(eulerAngles);
    }
}
