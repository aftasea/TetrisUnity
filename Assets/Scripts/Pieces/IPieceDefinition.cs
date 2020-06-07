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

public interface IPieceDefinition
{
	ShapeType Id
	{
		get;
	}

	int[][,] ShapeRotations
	{
		get;
	}
}
