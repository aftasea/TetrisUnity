﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDefinition
{
	private List<List<int>> shape = new List<List<int>> {
		new List<int>{ 1, 1 },
		new List<int>{ 1, 1 }
	};
	public List<List<int>> Shape
	{
		get { return shape; }
	}

	public Vector2Int topLeftPos = new Vector2Int(0, 0);
}