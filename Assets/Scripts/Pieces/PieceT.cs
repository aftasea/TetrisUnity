using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceT : IPieceDefinition
{
	public Color PieceColor { get; } = new Color(0.6f, 0.2f, 1);

	public int[][,] ShapeRotations { get; } = new int[][,] {
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 1, 1, 1, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 1, 0, 0 },
			{ 1, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 1, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 1, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 }
		}
	};
}
