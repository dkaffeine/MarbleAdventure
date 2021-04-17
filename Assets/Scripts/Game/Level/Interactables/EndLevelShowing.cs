using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelShowing : MonoBehaviour
{
    private static readonly float rotationDegreesPerSecond = 180.0f;

    public EndLevel endLevel;

    public uint levelToJump;

    private TextMesh levelText;

    // Start is called before the first frame update
    void Start()
    {
        endLevel.SetLevelToJump(levelToJump);
        SetFlagText();
    }

    private void SetFlagText()
    {
        levelText = GetComponentInChildren<TextMesh>();
        levelText.text = "Level: " + levelToJump.ToString();
    }

    private void Update()
    {
        Vector3 eulerAngles = new Vector3(0, rotationDegreesPerSecond * Time.deltaTime, 0);

        levelText.gameObject.transform.Rotate(eulerAngles);
    }


}
