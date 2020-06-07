using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
	private readonly int[][,] shapeRotations;
	private int rotationIndex;

	public Piece(IPieceDefinition definition, int columnCount)
	{
		shapeRotations = definition.ShapeRotations;

		topLeftPos = new GridPosition(0,
			Mathf.CeilToInt((columnCount - Shape.GetLength(1)) / 2f)
		);
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
		AudioManager.Play(SoundId.Rotate);
	}
}
