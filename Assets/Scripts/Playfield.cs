using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
	[SerializeField]
	private int columns = 10;

	[SerializeField]
	private int rows = 20;

	public List<List<int>> Grid { get; } = new List<List<int>>();

	private List<List<int>> shape = new List<List<int>> {
		new List<int>{ 1, 1 },
		new List<int>{ 1, 1 }
	};
	private Vector2Int shapeTopLeftPos = new Vector2Int(0, 0);
	

	private void Awake()
	{
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
		int gridPosX = shapeTopLeftPos.x;
		int gridPosY;

		foreach (var row in shape)
		{
			gridPosY = shapeTopLeftPos.y;
			foreach (var col in row)
			{
				Grid[gridPosX][gridPosY] = 1;
				gridPosY++;
			}
			gridPosX++;
		}
	}
}
