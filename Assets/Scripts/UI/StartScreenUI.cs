using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
	private Button startButton;

	private void Awake()
	{
		startButton = GetComponentInChildren<Button>();
		startButton.onClick.AddListener(StartGame);
	}

	private void StartGame()
	{
		Game.StartGame();
		startButton.gameObject.SetActive(false);
	}
}
