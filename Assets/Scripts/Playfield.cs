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

	private PieceSelector pieceSelector;

	public List<List<int>> Grid { get; } = new List<List<int>>();

	public Piece CurrentPiece
	{
		get;
		private set;
	}	

	private void Awake()
	{
		pieceSelector = GetComponent<PieceSelector>();
		InitGrid();
		SpawnShape();
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
		CurrentPiece = pieceSelector.GetRandomPiece();
		StartCoroutine(Fall());
	}

	private IEnumerator Fall()
	{
		yield return new WaitForSeconds(initialFallTime);
		
		if (CanFall())
		{
			CurrentPiece.topLeftPos.row++;
			StartCoroutine(Fall());
		}
		else
		{
			LandPiece();
		}		
	}

	private bool CanFall()
	{
		GridPosition nextPos = CurrentPiece.topLeftPos;
		nextPos.row++;

		for (int r = 0; r < CurrentPiece.Shape.GetLength(0); ++r)
		{
			for (int c = 0; c < CurrentPiece.Shape.GetLength(1); ++c)
			{
				var shapeValue = CurrentPiece.Shape[r, c];
				if (shapeValue != 0)
				{
					if (nextPos.row + r >= Rows)
					{
						// landed! don't continue falling
						return false;
					}

					if (Grid[nextPos.row + r][nextPos.col + c] != 0)
					{
						// another block is in place
						return false;
					}
				}
			}
		}

		return true;
	}

	private void LandPiece()
	{
		for (int r = 0; r < CurrentPiece.Shape.GetLength(0); ++r)
		{
			for (int c = 0; c < CurrentPiece.Shape.GetLength(1); ++c)
			{
				var shapeValue = CurrentPiece.Shape[r, c];
				if (shapeValue != 0)
				{
					int gridRow = CurrentPiece.topLeftPos.row + r;
					int gridColumn = CurrentPiece.topLeftPos.col + c;
					Grid[gridRow][gridColumn] = shapeValue;
				}
			}
		}
		SpawnShape();
	}
}
