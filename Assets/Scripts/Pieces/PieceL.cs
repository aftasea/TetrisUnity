using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceL : IPieceDefinition
{
	public Color PieceColor { get; } = new Color(1, 0.6f, 0);
	
	public int[][,] ShapeRotations { get; } = new int[][,] {
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 1, 1, 1, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 1, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 0, 1, 0 },
			{ 1, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		}
	};
}
