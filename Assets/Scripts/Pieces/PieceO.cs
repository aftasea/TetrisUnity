using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceO : IPieceDefinition
{
	public Color PieceColor { get; } = Color.yellow;

	public int[][,] ShapeRotations { get; } = new int[][,] {
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		}
	};
}
