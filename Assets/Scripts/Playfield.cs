using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
	[SerializeField]
	private int columns;

	[SerializeField]
	private int rows;
	
	private List<List<int>> grid = new List<List<int>>();

	private void Awake()
	{
		InitGrid();
		Print();
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
			grid.Add(row);
		}
	}

	private void Print()
	{
		string output;

		foreach (var row in grid)
		{
			output = "";
			foreach (var cell in row)
			{
				output += cell + " ";
			}
			Debug.Log(output);
		}
	}
}
