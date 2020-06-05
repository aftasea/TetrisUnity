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
		StartCoroutine(Fall());
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
	}

	private IEnumerator Fall()
	{
		yield return new WaitForSeconds(initialFallTime);
		
		if (CanFall())
		{
			CurrentPiece.topLeftPos.x++;
			StartCoroutine(Fall());
		}
		else
		{
			LandPiece();
		}		
	}

	private bool CanFall()
	{
		int nextRow = CurrentPiece.topLeftPos.x + 1;
		//Vector2Int nextPos = new Vector2Int(
		//	CurrentPiece.topLeftPos.x + 1,
		//	CurrentPiece.topLeftPos.y + 1
		//);

		for (int pieceRow = CurrentPiece.Shape.Count - 1; pieceRow >= 0; --pieceRow)
		{
			//for (int pieceColumn = CurrentPiece.Shape[pieceRow].Count - 1; pieceColumn >= 0; --pieceColumn)
			//{
				if (nextRow + pieceRow >= Rows)
				{
					// landed! don't continue falling
					return false;
				}
			//}
		}

		return true;
	}

	private void LandPiece()
	{
		for (int pieceRow = CurrentPiece.Shape.Count - 1; pieceRow >= 0; --pieceRow)
		{
			for (int pieceColumn = CurrentPiece.Shape[pieceRow].Count - 1; pieceColumn >= 0; --pieceColumn)
			{
				var shapeValue = CurrentPiece.Shape[pieceRow][pieceColumn];
				if (shapeValue != 0)
				{
					int gridRow = CurrentPiece.topLeftPos.x + pieceRow;
					int gridColumn = CurrentPiece.topLeftPos.y + pieceColumn;
					Grid[gridRow][gridColumn] = shapeValue;
				}
			}
		}
	}
}
