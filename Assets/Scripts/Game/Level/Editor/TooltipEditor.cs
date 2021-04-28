using UnityEditor;

[CustomEditor(typeof(Utils.TooltipBox), true)]
public class TooltipEditor : Editor
{
    private void OnSceneGUI()
    {
        using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
        {
            Utils.TooltipBox tooltipBox = target as Utils.TooltipBox;

            if (tooltipBox.gameObject.activeSelf)
            {
                tooltipBox.tooltips.Line1.text = tooltipBox.Line1;
                tooltipBox.tooltips.Line2.text = tooltipBox.Line2;
                tooltipBox.tooltips.Line3.text = tooltipBox.Line3;
                tooltipBox.tooltips.Line4.text = tooltipBox.Line4;
                tooltipBox.tooltips.Line5.text = tooltipBox.Line5;
            }
        }
    }
}
