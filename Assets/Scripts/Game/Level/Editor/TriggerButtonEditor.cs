using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerButton), true)]
public class TriggerButtonEditor : Editor
{
    private void OnSceneGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;

        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            TriggerButton triggerButton = target as TriggerButton;
            if (triggerButton.interactableElement)
            {
                Vector3 position = triggerButton.transform.position;
                Vector3 interactablePosition = triggerButton.interactableElement.gameObject.transform.position;
                Handles.DrawDottedLine(position, interactablePosition, 2.0f);
                Handles.Label(interactablePosition + new Vector3(0.0f, 1.0f, 0.0f), "Interactable", "button");
            }
        }
    }
}
