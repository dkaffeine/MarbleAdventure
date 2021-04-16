using UnityEngine;

public class Coin : MonoBehaviour
{
    private static readonly float rotationDegreesPerSecond = 180.0f;

    public VolumeSE volumeSE;

    public long coinValue;

    public bool coinTriggered = false;

    // Start is called before the first frame
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
