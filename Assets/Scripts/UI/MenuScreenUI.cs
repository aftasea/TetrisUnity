using UnityEngine;
using UnityEngine.UI;

public class MenuScreenUI : MonoBehaviour
{
	[SerializeField]
	private GameObject screen = null;
	[SerializeField]
	private GameObject gameOverScreen = null;

	private Button startButton;

	private void Awake()
	{
		startButton = GetComponentInChildren<Button>();
		startButton.onClick.AddListener(StartGame);
		Game.OnGameOver += ShowGameOverScreen;
		gameOverScreen.SetActive(false);
	}

	private void OnDestroy()
	{
		Game.OnGameOver -= ShowGameOverScreen;
	}

	private void StartGame()
	{
		screen.SetActive(false);
		gameOverScreen.SetActive(false);
		Game.StartGame();
	}

	private void ShowGameOverScreen()
	{
		screen.SetActive(true);
		gameOverScreen.SetActive(true);
	}
}
