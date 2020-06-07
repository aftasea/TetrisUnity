using UnityEngine;

public interface IPieceDefinition
{
	Color PieceColor
	{
		get;
	}

	int[][,] ShapeRotations
	{
		get;
	}
}
