using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldView : MonoBehaviour
{
	[SerializeField]
	private GameObject blockPrefab;

	private Playfield playfield;
	private Queue<GameObject> availableBlocks = new Queue<GameObject>();
	private Queue<GameObject> visibleBlocks = new Queue<GameObject>();

	private void Awake()
	{
		playfield = FindObjectOfType<Playfield>();
		InstantiateBlocks();
	}

	private void Update()
	{
		ClearBlocks();
		DrawLanded();
		DrawCurrentPiece();
	}

	void InstantiateBlocks()
	{
		Transform parentObject = transform;
		int gridSize = playfield.Rows * playfield.Columns;
		const int blocksPerPiece = 4;
		int extraBuffer = playfield.Columns * blocksPerPiece;

		for (int i = gridSize + extraBuffer; i > 0; --i)
		{
			GameObject go = Instantiate(blockPrefab, parentObject);
			go.SetActive(false);
			availableBlocks.Enqueue(go);
		}
	}

	private void ClearBlocks()
	{
		GameObject block;
		while (visibleBlocks.Count > 0)
		{
			block = visibleBlocks.Dequeue();
			block.SetActive(false);
			availableBlocks.Enqueue(block);
		}
	}

	private void DrawLanded()
	{
		GridPosition pos = new GridPosition(0, 0);
		foreach (var row in playfield.Grid)
		{
			pos.col = 0;
			foreach (var colum in row)
			{
				if (playfield.Grid[pos.row][pos.col] != 0)
					PlaceBlock(pos.row, pos.col);
				pos.col++;
			}
			pos.row++;
		}
	}

	private void DrawCurrentPiece()
	{
		if (playfield.CurrentPiece == null)
			return;

		int[,] shape = playfield.CurrentPiece.Shape;

		for (int r = 0; r < shape.GetLength(0); ++r)
		{
			for (int c = 0; c < shape.GetLength(1); ++c)
			{
				if (shape[r, c] != 0)
				{
					PlaceBlock(
						playfield.CurrentPiece.topLeftPos.row + r,
						playfield.CurrentPiece.topLeftPos.col + c
					);
				}
			}
		}
	}

	private void PlaceBlock(int row, int column)
	{
		GameObject block = availableBlocks.Dequeue();
		visibleBlocks.Enqueue(block);
		block.SetActive(true);
		block.transform.position = new Vector2(column, -row);
	}
}
