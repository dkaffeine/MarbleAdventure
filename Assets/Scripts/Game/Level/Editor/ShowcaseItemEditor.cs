using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShowcaseItem), true)]
public class ShowcaseItemEditor : Editor
{
    private void OnSceneGUI()
    {
        ShowcaseItem showcase = target as ShowcaseItem;
        showcase.DisplayPriceAndItem();
    }
}
