using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public class FloorBehaviour : Node2D
{
	private List<TileBehaviour> _tiles = new List<TileBehaviour>();

	public override void _Ready()
	{
		foreach (var item in GetChildren())
		{

			var tile = item as TileBehaviour;

			if (tile != null)
			{
				_tiles.Add(tile);
			}
		}

		var player = GetTree().CurrentScene.GetNode<Area2D>("Player");
		player.Connect("PositionUpdate", this, "OnPlayerPositionUpdate");
	}

	private void OnPlayerPositionUpdate(Vector2 newPosition, bool horizontalMovement, Vector2 direction)
	{
		foreach (var tile in _tiles)
		{
			if ((horizontalMovement && (tile.Position.y == newPosition.y)) || 
				!horizontalMovement && (tile.Position.x == newPosition.x))
			{
				tile.Move(direction * -1);
			}
		}
	}
}
