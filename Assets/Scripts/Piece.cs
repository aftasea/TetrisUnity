using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
	private int rotationIndex;

	private IPieceDefinition definition;

	public Piece(IPieceDefinition definition, int columnCount)
	{
		this.definition = definition;

		topLeftPos = new GridPosition(0,
			Mathf.CeilToInt((columnCount - Shape.GetLength(1)) / 2f)
		);
	}

	public int[,] Shape
	{
		get { return definition.ShapeRotations[rotationIndex]; }
	}

	public GridPosition topLeftPos = new GridPosition(0, 0);

	public int[,] GetRotatedShape()
	{
		int index = (rotationIndex + 1) % definition.ShapeRotations.Length;
		return definition.ShapeRotations[index];
	}

	public void Rotate(Rotation direction)
	{
		if (direction == Rotation.Clockwise)
		{
			rotationIndex = (rotationIndex + 1) % definition.ShapeRotations.Length;
		}
		else
		{
			rotationIndex = (rotationIndex - 1) % definition.ShapeRotations.Length;
			if (rotationIndex < 0)
				rotationIndex += definition.ShapeRotations.Length;
		}
		AudioManager.Play(SoundId.Rotate);
	}
}
