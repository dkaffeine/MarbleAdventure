using UnityEngine;

public class Coin : MonoBehaviour
{
    private static readonly float rotationDegreesPerSecond = 180.0f;

    public long coinValue;

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, rotationDegreesPerSecond * Time.deltaTime, 0);

        transform.Rotate(eulerAngles);
    }
}
