using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
	public float ElapsedTime
	{
		get;
		private set;
	}

	private void Awake()
	{
		Game.OnGameStart += ResetTime;
	}

	private void OnDestroy()
	{
		Game.OnGameStart -= ResetTime;
	}

	private void Update()
	{
		if (Game.IsRunning)
			ElapsedTime += Time.deltaTime;
	}

	private void ResetTime()
	{
		ElapsedTime = 0;
	}
}
