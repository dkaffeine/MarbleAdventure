using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EndLevelShowing), true)]
public class EndLevelShowingEditor : Editor
{
    private void OnSceneGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;

        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            EndLevelShowing endLevel = target as EndLevelShowing;
            Vector3 position = endLevel.transform.position + new Vector3(0.0f, 2.5f, 0.0f);
            Handles.Label(position, "New level: " + endLevel.levelToJump, style);

        }
    }
}
