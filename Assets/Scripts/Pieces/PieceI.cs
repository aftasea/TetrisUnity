﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceI : IPieceDefinition
{
	public int[][,] ShapeRotations { get; } = new int[][,] {
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 1, 1, 1 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 0, 1, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 1, 0 }
		},
		new int[,] {
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 1, 1, 1 },
			{ 0, 0, 0, 0 }
		},
		new int[,] {
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 }
		}
	};

}
