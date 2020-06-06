using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
	public Piece(int[,] shape)
	{
		Shape = (int[,])shape.Clone();
	}

	public int[,] Shape
	{
		get;
		private set;
	}

	public GridPosition topLeftPos = new GridPosition(0, 0);
}
