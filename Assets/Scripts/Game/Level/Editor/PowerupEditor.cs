using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Powerup), true)]
public class PowerupEditor : Editor
{
    private void OnSceneGUI()
    {
        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            Powerup powerup = target as Powerup;
            Vector3 position = powerup.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
            Handles.Label(position, "Powerup:" + powerup.powerupType.ToString());
        }
    }
}
