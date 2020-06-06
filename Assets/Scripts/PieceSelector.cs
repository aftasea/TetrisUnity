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
	public GridPosition testPos;
	public PieceDefinition testPiece;

	[SerializeField]
	private PieceDefinition[] pieces;

	public Piece GetRandomPiece()
	{
		Piece piece = new Piece(testPiece.shape);
		piece.topLeftPos = testPiece.spawnPosition;
		return piece;
	}
}
