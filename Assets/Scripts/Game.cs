using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	enum State
	{
		StartScreen,
		Running,
		GameOver
	}

	public static event System.Action OnGameStart;

	private static Game instance;
	private State state = State.StartScreen;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogWarning("There is already an instance of Game");
			DestroyImmediate(this);
		}
	}

	private void OnDestroy()
	{
		instance = null;
	}

	public static bool IsRunning
	{
		get { return instance.state == State.Running; }
	}

	public static void StartGame()
	{
		instance.state = State.Running;
		OnGameStart?.Invoke();
	}

	public static void GameOver()
	{
		instance.state = State.GameOver;
	}
}
