using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public enum MoveAction
	{
		Left,
		Right
	}

	public event System.Action<MoveAction> OnMovePressed;
	public event System.Action OnRotatePressed;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			OnMovePressed?.Invoke(MoveAction.Left);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			OnMovePressed?.Invoke(MoveAction.Right);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			OnRotatePressed?.Invoke();
		}
	}
}
