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
		scoreLabel.text = scoreManager.Score.ToString();
	}
}
