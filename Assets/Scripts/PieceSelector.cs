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
	private IPieceDefinition[] pieces = { new PieceO(), new PieceZ() };

	public Piece GetRandomPiece()
	{
		IPieceDefinition pieceDef = pieces[Random.Range(0, pieces.Length)];
		Piece piece = new Piece(pieceDef.Shape);
		piece.topLeftPos = pieceDef.SpawnPosition;
		return piece;
	}
}
