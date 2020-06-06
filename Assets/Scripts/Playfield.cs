﻿using System.Collections;
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
	private InputHandler input;

	public List<List<int>> Grid { get; } = new List<List<int>>();

	public Piece CurrentPiece
	{
		get;
		private set;
	}	

	private void Awake()
	{
		input = GetComponent<InputHandler>();
		pieceSelector = GetComponent<PieceSelector>();

		input.OnMovePressed += MovePiece;
		input.OnRotatePressed += RotatePiece;

		InitGrid();
		SpawnShape();
	}

	private void OnDestroy()
	{
		input.OnMovePressed -= MovePiece;
	}

	private void InitGrid()
	{
		AddNewEmptyLines(rows);
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

	private bool WillCollide(ref GridPosition nextPos, int[,] shape)
	{
		for (int r = 0; r < shape.GetLength(0); ++r)
		{
			for (int c = 0; c < shape.GetLength(1); ++c)
			{
				var shapeValue = shape[r, c];
				if (shapeValue != 0)
				{
					if (nextPos.col + c < 0)
					{
						// Will collide beyond left border
						return true;
					}

					if (nextPos.col + c >= Columns)
					{
						// Will collide beyond right border
						return true;
					}

					if (nextPos.row + r >= Rows)
					{
						// Will collide beyond bottom border
						return true;
					}

					if (Grid[nextPos.row + r][nextPos.col + c] != 0)
					{
						// Another block is in place
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool CanFall()
	{
		GridPosition nextPos = CurrentPiece.topLeftPos;
		nextPos.row++;

		return !WillCollide(ref nextPos, CurrentPiece.Shape);
	}

	private void MovePiece(Move direction)
	{
		GridPosition nextPos = CurrentPiece.topLeftPos;

		if (direction == Move.Left)
			nextPos.col--;
		else if (direction == Move.Right)
			nextPos.col++;

		if (!WillCollide(ref nextPos, CurrentPiece.Shape))
			CurrentPiece.topLeftPos = nextPos;
	}

	private void RotatePiece(Rotation direction)
	{
		int[,] rotatedShape = CurrentPiece.GetRotatedShape();

		if (!WillCollide(ref CurrentPiece.topLeftPos, rotatedShape))
			CurrentPiece.Rotate(direction);
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

		CheckCompletedLines();
		SpawnShape();
	}

	private void CheckCompletedLines()
	{
		List<int> completedLineIndexes = GetCompletedLines();

		if (completedLineIndexes.Count > 0)
		{
			ClearLines(completedLineIndexes);
			AddNewEmptyLines(completedLineIndexes.Count);			
		}
	}

	private List<int> GetCompletedLines()
	{
		List<int> completedLineIndexes = new List<int>();

		for (int r = Grid.Count - 1; r >= 0; --r)
		{
			int blocksInRow = 0;
			foreach (var cell in Grid[r])
			{
				if (cell == 0)
					break;

				++blocksInRow;
			}

			if (blocksInRow == Grid[r].Count)
				completedLineIndexes.Add(r);
		}

		return completedLineIndexes;
	}

	private void ClearLines(List<int> completedLineIndexes)
	{
		foreach (int i in completedLineIndexes)
		{
			Grid.RemoveAt(i);
		}
	}

	private void AddNewEmptyLines(int lineCount)
	{
		for (int r = 0; r < lineCount; ++r)
		{
			List<int> row = new List<int>();
			for (int c = 0; c < columns; ++c)
			{
				row.Add(0);
			}
			Grid.Insert(0, row);
		}
	}
}
