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

	}
}
