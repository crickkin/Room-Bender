using Godot;
using System;

public class TileBehaviour : Node2D
{
	private int _moveFactor = 96;

	public void Move(Vector2 direction)
	{
		Position += direction * _moveFactor;
	}
}
