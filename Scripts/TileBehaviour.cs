using Godot;
using System;

public class TileBehaviour : Node2D
{
	private int _moveFactor = 96;

	public void Move(Vector2 direction)
	{
		Position += direction * _moveFactor;
		EdgeHandling();
	}

	private void EdgeHandling()
	{
		Vector2 correctedPosition = Position;

		if (correctedPosition.x >= GameScene.Instance.Edges.Right)
		{
			correctedPosition.x = GameScene.Instance.Edges.Left + _moveFactor;
		}
		else if (correctedPosition.x <= GameScene.Instance.Edges.Left)
		{
			correctedPosition.x = GameScene.Instance.Edges.Right - _moveFactor;
		}

		if (correctedPosition.y >= GameScene.Instance.Edges.Bottom)
		{
			correctedPosition.y = 72 + _moveFactor;
		}
		else if (correctedPosition.y <= 72)
		{
			correctedPosition.y = GameScene.Instance.Edges.Bottom - _moveFactor;
		}

		Position = correctedPosition;
	}
}
