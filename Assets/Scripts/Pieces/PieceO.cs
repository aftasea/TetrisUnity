using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceO : IPieceDefinition
{
	private GridPosition spawnPosition = new GridPosition(0, 3);
	public GridPosition SpawnPosition
	{
		get { return spawnPosition; }
	}

	public int[][,] ShapeRotations { get; } = new int[][,] {
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		}
	};
}
