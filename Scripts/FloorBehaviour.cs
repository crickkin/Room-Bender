using Godot;
using System;
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

		if (_tiles.Count > 0)
		{
			_tiles[0].ActivateTileMovement(false);
		}

	}
}
