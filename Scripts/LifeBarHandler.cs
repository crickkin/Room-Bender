using Godot;
using System;
using System.Collections.Generic;

public class LifeBarHandler : Node2D
{
	private List<AnimatedSprite> _lifeIcons = new List<AnimatedSprite>();

	public override void _Ready()
	{
		int i = 0;
		foreach (var element in GetChildren())
		{
			var life = element as AnimatedSprite;
			if (life != null)
			{
				_lifeIcons.Add(life);
				life.Frame = i;
				i += 2;
			}
		}

		var player = GetTree().CurrentScene.GetNode("Player");
		player.Connect("LifeUpdate", this, "OnLifeUpdate");
	}

	private void OnLifeUpdate(int life)
	{
		for (int i = 0; i < 3; i++)
		{
			_lifeIcons[i].Visible = i <= (life - 1);
		}
	}
}
