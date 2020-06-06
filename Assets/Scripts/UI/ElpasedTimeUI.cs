using UnityEngine;
using UnityEngine.UI;
using System;

public class ElpasedTimeUI : MonoBehaviour
{
	private TimeCounter timeCounter;
	private Text timeLabel;

	private void Awake()
	{
		timeCounter = FindObjectOfType<TimeCounter>();
		timeLabel = GetComponent<Text>();
	}

	private void Update()
	{
		timeLabel.text = FormattedTime();
	}

	private string FormattedTime()
	{
		return TimeSpan.FromSeconds(timeCounter.ElapsedTime).ToString(@"mm\:ss");
	}
}
