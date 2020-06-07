using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
	private Button startButton;

	private void Awake()
	{
		startButton = GetComponentInChildren<Button>();
		startButton.onClick.AddListener(StartGame);
		Game.OnGameOver += ShowGameOverScreen;
	}

	private void OnDestroy()
	{
		Game.OnGameOver -= ShowGameOverScreen;
	}

	private void StartGame()
	{
		Game.StartGame();
		startButton.gameObject.SetActive(false);
	}

	private void ShowGameOverScreen()
	{
		Debug.Log("GameOver");
		startButton.gameObject.SetActive(true);
	}
}
