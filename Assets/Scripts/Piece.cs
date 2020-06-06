using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
	private int[][,] shapeRotations;
	private int rotationIndex = 0;

	public Piece(IPieceDefinition definition)
	{
		shapeRotations = definition.ShapeRotations;
		topLeftPos = definition.SpawnPosition;
	}

	public int[,] Shape
	{
		get { return shapeRotations[rotationIndex]; }
	}

	public GridPosition topLeftPos = new GridPosition(0, 0);

	public int[,] GetRotatedShape()
	{
		int index = (rotationIndex + 1) % shapeRotations.Length;
		return shapeRotations[index];
	}

	public void Rotate(Rotation direction)
	{
		if (direction == Rotation.Clockwise)
		{
			rotationIndex = (rotationIndex + 1) % shapeRotations.Length;
		}
		else
		{
			rotationIndex = (rotationIndex - 1) % shapeRotations.Length;
			if (rotationIndex < 0)
				rotationIndex += shapeRotations.Length;
		}
	}
}
