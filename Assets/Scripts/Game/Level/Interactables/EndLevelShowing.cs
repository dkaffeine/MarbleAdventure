using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelShowing : MonoBehaviour
{
    public EndLevel endLevel;

    public uint levelToJump;

    private TextMesh levelText;

    // Start is called before the first frame update
    void Start()
    {
        if (endLevel != null)
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
        Vector3 eulerAngles = new Vector3(0, GameEngine.interactableRotationSpeed * Time.deltaTime, 0);

        levelText.gameObject.transform.Rotate(eulerAngles);
    }


}
