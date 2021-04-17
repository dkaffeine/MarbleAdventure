using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelShowing : MonoBehaviour
{
    public EndLevel endLevel;

    public uint levelToJump;

    // Start is called before the first frame update
    void Start()
    {
        endLevel.SetLevelToJump(levelToJump);
    }
}
