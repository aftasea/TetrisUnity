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

	public List<List<int>> Grid { get; } = new List<List<int>>();

	private Piece piece = new Piece();
	

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
		int gridPosX = piece.topLeftPos.x;
		int gridPosY;

		foreach (var row in piece.Shape)
		{
			gridPosY = piece.topLeftPos.y;
			foreach (var col in row)
			{
				Grid[gridPosX][gridPosY] = 1;
				gridPosY++;
			}
			gridPosX++;
		}
	}

	private IEnumerator Fall()
	{
		yield return new WaitForSeconds(1f);
		piece.topLeftPos.y++;
	}
}
