using Godot;
using System;

public class TileBehaviour : Node2D
{
	private int _moveFactor = 96;

	private bool _isActive = true;

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

	public void ActivateTileMovement(bool shouldActivate)
	{
		_isActive = shouldActivate;
	}

	private void PlayerHasMoved(Vector2 direction)
	{
		if (!_isActive)
			return;
		
		Position += direction * -1 * _moveFactor;
	}

	public static explicit operator TileBehaviour(Reference v)
	{
		throw new NotImplementedException();
	}
}
