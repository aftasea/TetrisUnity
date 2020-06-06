using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Piece
{
	public int baz;

	//[SerializeField]
	//ShapeType type;

	//public Vector3 lookAtPoint = Vector3.zero;

	//public bool[,] board = new bool[3, 3];

	//[SerializeField]
	private List<List<int>> shape = new List<List<int>> {
		new List<int>{ 1, 1 },
		new List<int>{ 1, 1 }
	};
	public List<List<int>> Shape
	{
		get { return shape; }
	}

	public GridPosition topLeftPos = new GridPosition(0, 0);
}
