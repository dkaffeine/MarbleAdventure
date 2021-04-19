using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConcealPlatform), true)]
public class ConcealPlatformEditor : Editor
{
    private void OnSceneGUI()
    {
        ConcealPlatform concealPlatform = target as ConcealPlatform;
        concealPlatform.SetVisibility();
    }
}
