using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    /// <summary>
    /// Handler to the player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Player sphere radius
    /// </summary>
    private float playerSphereRadius = 0.5f;

    /// <summary>
    /// Gets spawn position
    /// </summary>
    /// <returns>Returns spawn position</returns>
    Vector3 SpawnPos()
    {
        return transform.position + new Vector3(0, 0, 2.0f * playerSphereRadius);
    }

    // Start is called before the first frame update, or when the object wakes up
    void Start()
    {
        Instantiate(player, SpawnPos(), transform.rotation);
    }
}
