using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
	private ScoreManager scoreManager;
	private Text scoreLabel;

	private void Awake()
	{
		scoreManager = FindObjectOfType<ScoreManager>();
		scoreLabel = GetComponent<Text>();
	}

	private void Update()
	{
		scoreLabel.text = scoreManager.BestScore.ToString();
	}
}
