using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingPlatform), true)]
public class MovingPlatformEditor : Editor
{
    private void OnSceneGUI()
    {
        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            MovingPlatform movingPlatform = target as MovingPlatform;

            // Get starting and ending position;
            Vector3 startPosition = movingPlatform.startPosition;
            Vector3 endPosition = movingPlatform.endPosition;
            
            // Active handles on start and end position
            Handles.Label(startPosition, "Start", "button");
            Handles.Label(endPosition, "End", "button");

            // Update the platform position in the editor
            movingPlatform.UpdatePosition(movingPlatform.editorPosition);

            // Draw a line between start and end position
            Handles.DrawDottedLine(startPosition, endPosition, 2.0f);

            // Put a label in the middle of the distance
            Handles.Label(Vector3.Lerp(startPosition, endPosition, 0.5f), "Distance: " + (endPosition - startPosition).magnitude);
        }
    }
}
