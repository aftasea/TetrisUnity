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

	private void Update()
	{
		if (Game.IsRunning)
			ElapsedTime += Time.deltaTime;
	}
}
