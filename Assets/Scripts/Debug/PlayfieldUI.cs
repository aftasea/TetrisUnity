using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayfieldUI : MonoBehaviour
{
	private Playfield playfield;
	private Text debugText;

	private void Awake()
	{
		playfield = FindObjectOfType<Playfield>();
		debugText = GetComponent<Text>();
	}

	private void Update()
	{
		Print();
	}

	private void Print()
	{
		debugText.text = "";

		foreach (var row in playfield.Grid)
		{
			foreach (var cell in row)
			{
				debugText.text += cell + " ";
			}
			debugText.text += "\n";
		}
	}
}
