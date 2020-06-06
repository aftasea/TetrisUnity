using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
	public Piece(IPieceDefinition definition)
	{
		Shape = (int[,])definition.Shape.Clone();
		topLeftPos = definition.SpawnPosition;
	}

	public int[,] Shape
	{
		get;
		private set;
	}

	public GridPosition topLeftPos = new GridPosition(0, 0);
}
