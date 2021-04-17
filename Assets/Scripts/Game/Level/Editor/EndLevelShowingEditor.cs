using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EndLevelShowing), true)]
public class EndLevelShowingEditor : Editor
{
    private void OnSceneGUI()
    {
        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            EndLevelShowing endLevel = target as EndLevelShowing;
            endLevel.GetComponentInChildren<TextMesh>().text = "Level: " + endLevel.levelToJump.ToString();
        }
    }
}
