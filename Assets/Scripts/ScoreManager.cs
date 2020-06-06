using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	private int pointsPerSingle = 1;
	[SerializeField]
	private int pointsPerDouble = 3;
	[SerializeField]
	private int pointsPerTriple = 5;
	[SerializeField]
	private int pointsPerTetris = 8;

	private Playfield playfield;

	public int Score
	{
		get;
		private set;
	}

	private void Awake()
	{
		playfield = GetComponent<Playfield>();
		playfield.OnLinesCleared += AddPoints;
	}

	private void OnDestroy()
	{
		playfield.OnLinesCleared -= AddPoints;
	}

	private void AddPoints(int lineCount)
	{
		switch (lineCount)
		{
			case 4:
				Score += pointsPerTetris;
				break;
			case 3:
				Score += pointsPerTriple;
				break;
			case 2:
				Score += pointsPerDouble;
				break;
			case 1:
				Score += pointsPerSingle;
				break;
		}
	}
}
