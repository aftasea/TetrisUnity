using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldLayout : MonoBehaviour
{
	[SerializeField]
	private GameObject gridCellPrefab = null;

	private Playfield playfield;

	private List<GameObject> visualObjects = new List<GameObject>();

	private void Awake()
	{
		playfield = FindObjectOfType<Playfield>();
		playfield.OnGridSizeChanged += UpdateGrid;
		CreateGrid();
	}

	private void OnDestroy()
	{
		playfield.OnGridSizeChanged -= UpdateGrid;
	}

	private void CreateGrid()
	{
		Transform parentObject = transform;

		for (int r = 0; r < playfield.Rows; ++r)
		{
			for (int c = 0; c < playfield.Columns; ++c)
			{
				visualObjects.Add(Instantiate(gridCellPrefab, new Vector3(c, -r, 0), Quaternion.identity, parentObject));
			}
		}
	}

	private void UpdateGrid()
	{
		foreach (GameObject o in visualObjects)
		{
			Destroy(o);
		}
		visualObjects.Clear();
		CreateGrid();
	}
}
