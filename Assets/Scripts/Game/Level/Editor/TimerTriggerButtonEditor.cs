using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimerTriggerButton), true)]
public class TimerTriggerButtonEditor : Editor
{
    private void OnSceneGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;

        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            TimerTriggerButton triggerButton = target as TimerTriggerButton;
            triggerButton.SetTimerText(triggerButton.timer);

            if (triggerButton.interactableElement)
            {
                Vector3 position = triggerButton.transform.position;
                Vector3 interactablePosition = triggerButton.interactableElement.gameObject.transform.position;
                Handles.DrawDottedLine(position, interactablePosition, 2.0f);
                if (triggerButton.newStatus == true)
                {
                    Handles.Label(interactablePosition + new Vector3(0.0f, 1.0f, 0.0f), "Interactable to activate", "button");
                }
                else
                {
                    Handles.Label(interactablePosition + new Vector3(0.0f, 1.0f, 0.0f), "Interactable to deactivate", "button");
                }
            }
        }
    }
}
