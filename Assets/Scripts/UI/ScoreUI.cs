using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
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
		scoreLabel.text = "Current Score: " + scoreManager.Score;
	}
}
