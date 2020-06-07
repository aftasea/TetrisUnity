using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
	[SerializeField]
	private GameObject overlay;

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
		overlay.SetActive(false);
		startButton.gameObject.SetActive(false);
		Game.StartGame();
	}

	private void ShowGameOverScreen()
	{
		overlay.SetActive(true);
		startButton.gameObject.SetActive(true);
	}
}
