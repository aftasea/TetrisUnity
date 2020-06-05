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
	}

	private void DrawCurrentPiece()
	{
		PieceDefinition piece = playfield.CurrentPiece;
		int gridRow = piece.topLeftPos.x;
		int gridColumn;

		foreach (var pieceRow in piece.Shape)
		{
			gridColumn = piece.topLeftPos.y;
			foreach (var pieceColumn in pieceRow)
			{
				PlaceBlock(gridRow, gridColumn);
				gridColumn++;
			}
			gridRow++;
		}
	}

	private void PlaceBlock(int row, int column)
	{
		GameObject block = availableBlocks.Dequeue();
		visibleBlocks.Enqueue(block);
		block.SetActive(true);
		block.transform.position = new Vector2(column, -row);
	}

	private string FormatColor(string str, Color color)
	{
		return "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">"
			+ str
			+ "</color>";
	}
}
