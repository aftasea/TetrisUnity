using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PieceDefinition", order = 1)]
public class PieceDefinition : ScriptableObject
{
	public GridPosition spawnPosition = new GridPosition(0, 0);

	public int[,] shape = {
		{ 0, 0, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 }
	};
}