using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GridPosition))]
public class GridPositionDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		SerializedProperty row = property.FindPropertyRelative("row");
		SerializedProperty col = property.FindPropertyRelative("col");

		Rect mainLabelRect = position;
		mainLabelRect.width = EditorGUIUtility.labelWidth;
		EditorGUI.LabelField(mainLabelRect, label);

		Rect fieldRect = position;
		fieldRect.x += mainLabelRect.width;
		const int propertyCount = 2;
		fieldRect.width = ((position.width - mainLabelRect.width) / propertyCount);

		DrawField("Row", ref fieldRect, row);
		DrawField(" Col", ref fieldRect, col);
	}

	private void DrawField(string label, ref Rect rect, SerializedProperty property)
	{
		GUIContent fieldLabel = new GUIContent(label);
		Vector2 labelSize = EditorStyles.label.CalcSize(fieldLabel);
		EditorGUIUtility.labelWidth = labelSize.x;
		EditorGUI.PropertyField(rect, property, fieldLabel);
		rect.x += rect.width;
	}
}
