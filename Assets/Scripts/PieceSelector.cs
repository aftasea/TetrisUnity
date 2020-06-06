using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ShapeType
{
	None,
	I,
	J,
	L,
	O,
	S,
	T,
	Z
}

public class PieceSelector : MonoBehaviour
{
	public GridPosition testPos;
	public PieceDefinition testPiece;

	[SerializeField]
	private IPieceDefinition[] pieces = {
		new PieceI(), new PieceJ(), new PieceL(),
		new PieceO(), new PieceS(), new PieceT(),
		new PieceZ()
	};

	public Piece GetRandomPiece()
	{
		IPieceDefinition pieceDef = pieces[Random.Range(0, pieces.Length)];
		Piece piece = new Piece(pieceDef.Shape);
		piece.topLeftPos = pieceDef.SpawnPosition;
		return piece;
	}
}
