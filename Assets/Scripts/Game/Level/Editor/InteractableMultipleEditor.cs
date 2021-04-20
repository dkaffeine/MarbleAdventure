using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractableMultiple), true)]
public class InteractableMultipleEditor : Editor
{
    private void OnSceneGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;

        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            InteractableMultiple interactableMultiple = target as InteractableMultiple;
            if (interactableMultiple.interactables.Count != 0)
            {
                Vector3 position = interactableMultiple.transform.position;

                foreach(InteractableElement element in interactableMultiple.interactables)
                {
                    if (element != null)
                    {
                        Vector3 interactablePosition = element.gameObject.transform.position;
                        Handles.DrawDottedLine(position, interactablePosition, 2.0f);
                        Handles.Label(interactablePosition + new Vector3(0.0f, 1.0f, 0.0f), "Interactable", "button");
                    }
                }
            }
        }
    }
}