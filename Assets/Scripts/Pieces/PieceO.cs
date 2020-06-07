using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceO : IPieceDefinition
{
	public ShapeType Id { get; } = ShapeType.O;

	public int[][,] ShapeRotations { get; } = new int[][,] {
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		}
	};
}
