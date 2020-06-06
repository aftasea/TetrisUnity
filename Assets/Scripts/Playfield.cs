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

		InitGrid();
		SpawnShape();
	}

	private void OnDestroy()
	{
		input.OnMovePressed -= MovePiece;
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

	private void MovePiece(InputHandler.Action action)
	{
		GridPosition nextPos = CurrentPiece.topLeftPos;

		if (action == InputHandler.Action.MoveLeft)
			nextPos.col--;
		else if(action == InputHandler.Action.MoveRight)
			nextPos.col++;

		if (!WillCollide(nextPos))
			CurrentPiece.topLeftPos = nextPos;
	}

	private bool WillCollide(GridPosition nextPos)
	{
		for (int r = 0; r < CurrentPiece.Shape.GetLength(0); ++r)
		{
			for (int c = 0; c < CurrentPiece.Shape.GetLength(1); ++c)
			{
				var shapeValue = CurrentPiece.Shape[r, c];
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

		return !WillCollide(nextPos);
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
