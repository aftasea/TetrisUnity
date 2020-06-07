using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelector : MonoBehaviour
{
	private IPieceDefinition[] pieces = {
		new PieceI(), new PieceJ(), new PieceL(),
		new PieceO(), new PieceS(), new PieceT(),
		new PieceZ()
	};

	public Piece GetRandomPiece(int columnCount)
	{
		IPieceDefinition pieceDef = pieces[Random.Range(0, pieces.Length)];
		Piece piece = new Piece(pieceDef, columnCount);
		return piece;
	}
}
