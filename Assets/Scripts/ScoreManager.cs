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

	public int CurrentBestScore
	{
		get;
		private set;
	}

	private int previousBestScore;

	private void Awake()
	{
		playfield = GetComponent<Playfield>();

		AddEventListeners();

		previousBestScore = Persistence.GetInt(scoreKey);
		CurrentBestScore = previousBestScore;
	}

	private void OnDestroy()
	{
		RemoveEventListeners();
	}

	private void AddEventListeners()
	{
		playfield.OnLinesCleared += AddPoints;
		Game.OnGameStart += ResetScore;
		Game.OnGameOver += UpdateHighScore;
	}

	private void RemoveEventListeners()
	{
		playfield.OnLinesCleared -= AddPoints;
		Game.OnGameStart -= ResetScore;
		Game.OnGameOver -= UpdateHighScore;
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

		if (Score > CurrentBestScore)
			CurrentBestScore = Score;
	}

	private void UpdateHighScore()
	{
		if (CurrentBestScore > previousBestScore)
		{
			previousBestScore = CurrentBestScore;
			Persistence.SetInt(scoreKey, CurrentBestScore);
		}
	}

	private void ResetScore()
	{
		Score = 0;
	}
}
