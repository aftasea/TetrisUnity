using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
	[SerializeField]
	private GameObject overlay;
	[SerializeField]
	private GameObject gameOverScreen;

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
		overlay.SetActive(false);
		gameOverScreen.SetActive(false);
		startButton.gameObject.SetActive(false);
		Game.StartGame();
	}

	private void ShowGameOverScreen()
	{
		overlay.SetActive(true);
		gameOverScreen.SetActive(true);
		startButton.gameObject.SetActive(true);
	}
}
