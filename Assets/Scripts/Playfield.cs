using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
	[SerializeField]
	private int columns = 10;
	public int Columns
	{
		get { return columns; }
	}

	[SerializeField]
	private int rows = 20;
	public int Rows
	{
		get { return rows; }
	}

	[Tooltip("Speed in seconds per unit")]
	[SerializeField]
	private float initialFallTime = 1f;

	public List<List<int>> Grid { get; } = new List<List<int>>();

	public PieceDefinition CurrentPiece
	{
		get;
		private set;
	}
	

	private void Awake()
	{
		InitGrid();
		SpawnShape();
		StartCoroutine("Fall");
	}

	private void InitGrid()
	{
		for (int r = 0; r < rows; ++r)
		{
			List<int> row = new List<int>();
			for (int c = 0; c < columns; ++c)
			{
				row.Add(0);
			}
			Grid.Add(row);
		}
	}

	private void SpawnShape()
	{
		CurrentPiece = new PieceDefinition();
		//int gridPosX = piece.topLeftPos.x;
		//int gridPosY;

		//foreach (var row in piece.Shape)
		//{
		//	gridPosY = piece.topLeftPos.y;
		//	foreach (var col in row)
		//	{
		//		Grid[gridPosX][gridPosY] = 1;
		//		gridPosY++;
		//	}
		//	gridPosX++;
		//}
	}

	private IEnumerator Fall()
	{
		yield return new WaitForSeconds(initialFallTime);
		CurrentPiece.topLeftPos.y++;
		StartCoroutine("Fall");
	}
}
