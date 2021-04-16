using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for platform moving
/// </summary>
public class MovingPlatform : MonoBehaviour
{
    /// <summary>
    /// Loop type enumerator
    /// </summary>
    public enum LoopType
    {
        Once,
        PingPong,
        Repeat
    }

    /// <summary>
    /// Loop type
    /// </summary>
    public LoopType loopType;

    /// <summary>
    /// Animation duration in seconds
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// Flag for platform activator
    /// </summary>
    public bool activate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
