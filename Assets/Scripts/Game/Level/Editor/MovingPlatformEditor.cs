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

            // Update the platform position in the editor
            movingPlatform.UpdatePosition(movingPlatform.editorPosition);

            // Get starting and ending position;
            Vector3 startPosition = movingPlatform.startPosition;
            Vector3 endPosition = movingPlatform.endPosition;

            MovingObstacle movingObstacle = target as MovingObstacle;

            if (movingObstacle != null)
            {
                // Move start and end position from local coordinates to global coordinates
                startPosition = movingObstacle.transform.TransformPoint(startPosition);
                endPosition = movingObstacle.transform.TransformPoint(endPosition);
            }
            // Active handles on start and end position
            Handles.Label(startPosition, "Start", "button");
            Handles.Label(endPosition, "End", "button");

            // Draw a line between start and end position
            Handles.DrawDottedLine(startPosition, endPosition, 2.0f);

            // Put a label in the middle of the distance
            Handles.Label(Vector3.Lerp(startPosition, endPosition, 0.5f), "Distance: " + (endPosition - startPosition).magnitude);
        }
    }
}
