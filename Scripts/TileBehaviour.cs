using Godot;
using System;

public class TileBehaviour : Node2D
{
	private int _moveFactor = 64;

	public override void _Ready()
	{
		var player = GetTree().CurrentScene.GetNode<Area2D>("Player");

		player.Connect("Moved", this, "PlayerHasMoved");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private void PlayerHasMoved(Vector2 direction)
	{
		Position += direction * -1 * _moveFactor;
	}
}
