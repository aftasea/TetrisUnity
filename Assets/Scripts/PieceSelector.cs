using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ShapeType
{
	None,
	I,
	O,
	T,
	S,
	Z,
	J,
	L
}

public class PieceSelector : MonoBehaviour
{
	public Piece testPiece;

	[SerializeField]
	private Piece[] pieces;

	public Piece GetRandomPiece()
	{
		return pieces[1];
	}
}
