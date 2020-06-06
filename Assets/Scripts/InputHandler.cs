using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rotation
{
	Clockwise,
	Counterclockwise
}

public enum Move
{
	Left,
	Right
}

public class InputHandler : MonoBehaviour
{

	public event System.Action<Move> OnMovePressed;
	public event System.Action<Rotation> OnRotatePressed;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			OnMovePressed?.Invoke(Move.Left);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			OnMovePressed?.Invoke(Move.Right);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.X))
		{
			OnRotatePressed?.Invoke(Rotation.Clockwise);
		}
		else if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Z))
		{
			OnRotatePressed?.Invoke(Rotation.Counterclockwise);
		}
	}
}
