using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(PieceDefinition))]
public class PieceDefinitionEditor : Editor
{
	int pieceSquareSize = 1;
	
	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		base.OnInspectorGUI();

		PieceDefinition piece = (PieceDefinition)target;
				
		pieceSquareSize = EditorGUILayout.IntField("pieceSquareSize", piece.shape.GetLength(0));
		
		for (int r = 0; r < pieceSquareSize; ++r)
		{
			EditorGUILayout.BeginHorizontal();
			for (int c = 0; c < pieceSquareSize; ++c)
			{
				int newValue = EditorGUILayout.Toggle(piece.shape[r, c] != 0) ? 1 : 0;
				piece.shape[r, c] = newValue;

				EditorUtility.SetDirty(target);
			}
			EditorGUILayout.EndHorizontal();
		}

		EditorUtility.SetDirty(target);

		serializedObject.ApplyModifiedProperties();
	}
}