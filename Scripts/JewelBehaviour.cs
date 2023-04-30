using Godot;
using System;

public class JewelBehaviour : Area2D
{
	private AnimatedSprite _animatedSprite;
	private bool _collected = false;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

	public override void _Process(float delta)
	{
		if (!GameScene.Instance.BetweenEdge(GlobalPosition))
		{
			QueueFree();
		}
	}

	private void _on_Jewel_area_entered(object area)
	{
		if (_collected) return;
		
		Player player = area as Player;

		if (player != null)
		{
			player.Collect();
			_collected = true;
			_animatedSprite.Animation = "collected";
		}
	}
	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation == "collected")
		{
			QueueFree();
		}
	}

}
