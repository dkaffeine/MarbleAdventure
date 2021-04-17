using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private static readonly float rotationDegreesPerSecond = 180.0f;

    public PowerupType powerupType;

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
}
