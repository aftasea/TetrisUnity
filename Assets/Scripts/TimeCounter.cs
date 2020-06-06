using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
	private Playfield playfield;

	public float ElapsedTime
	{
		get;
		private set;
	}

	private bool count;

	private void Awake()
	{
		playfield = GetComponent<Playfield>();

		AddEventListeners();

		count = true;
	}

	private void OnDestroy()
	{
		RemoveEventListeners();
	}

	private void Update()
	{
		if (count)
			ElapsedTime += Time.deltaTime;
	}

	private void AddEventListeners()
	{
		playfield.OnGameOver += StopTimeCount;
	}

	private void RemoveEventListeners()
	{
		playfield.OnGameOver -= StopTimeCount;
	}

	private void StopTimeCount()
	{
		count = false;
	}
}
