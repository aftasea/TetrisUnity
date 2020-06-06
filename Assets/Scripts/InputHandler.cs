using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public enum Action
	{
		MoveLeft,
		MoveRight
	}

	public event System.Action<Action> OnMovePressed;

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			OnMovePressed?.Invoke(Action.MoveLeft);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			OnMovePressed?.Invoke(Action.MoveRight);
		}
	}
}
