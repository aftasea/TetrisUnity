﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeType
{
	None = 0,
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
