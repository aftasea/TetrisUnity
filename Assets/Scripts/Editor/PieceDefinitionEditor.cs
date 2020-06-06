using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PieceDefinition))]
public class PieceDefinitionEditor : Editor
{
	//SerializedProperty lookAtPoint;
	//SerializedProperty board;

	//int[,] foo;

	//void OnEnable()
	//{
	//	lookAtPoint = serializedObject.FindProperty("lookAtPoint");
	//	board = serializedObject.FindProperty("board");
	//}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		PieceDefinition selector = (PieceDefinition)target;


		if (GUILayout.Button("Foo"))
		{
			Debug.Log("Foo");
		}
	}
}