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
	private string scoreKey = "score";

	public int Score
	{
		get;
		private set;
	}

	public int BestScore
	{
		get;
		private set;
	}

	private void Awake()
	{
		playfield = GetComponent<Playfield>();

		AddEventListeners();

		BestScore = Persistence.GetInt(scoreKey);
	}

	private void OnDestroy()
	{
		RemoveEventListeners();
	}

	private void AddEventListeners()
	{
		playfield.OnLinesCleared += AddPoints;
		playfield.OnGameOver += UpdateHighScore;
	}

	private void RemoveEventListeners()
	{
		playfield.OnLinesCleared += AddPoints;
		playfield.OnLinesCleared += AddPoints;
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

	private void UpdateHighScore()
	{
		if (Score > BestScore)
			Persistence.SetInt(scoreKey, Score);
	}
}
