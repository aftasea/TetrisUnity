using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldLayout : MonoBehaviour
{
	[SerializeField]
	private GameObject gridCellPrefab;

	private Playfield playfield;

	private void Awake()
	{
		playfield = FindObjectOfType<Playfield>();
		CreateGrid();
	}

	private void CreateGrid()
	{
		Transform parent = transform;

		for (int r = 0; r < playfield.Rows; ++r)
		{
			for (int c = 0; c < playfield.Columns; ++c)
			{
				Instantiate(gridCellPrefab, new Vector3(c, -r, 0), Quaternion.identity, parent);
			}
		}
	}
}
