using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PieceDefinition", order = 1)]
public class PieceDefinition : ScriptableObject
{
	public int bar;

	public Vector2Int myVec2;

	public GridPosition spawnPosition = new GridPosition(0, 0);

	[SerializeField]
	public List<List<int>> shape = new List<List<int>> {
		new List<int>{ 1, 1 },
		new List<int>{ 1, 1 }
	};
}