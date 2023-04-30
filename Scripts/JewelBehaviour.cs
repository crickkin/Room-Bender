using Godot;
using System;

public class JewelBehaviour : Area2D
{
	private AnimatedSprite _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private void _on_Jewel_area_entered(object area)
	{
		Player player = area as Player;

		if (player != null)
		{
			// GD.Print("Player collided!");
			player.Collect();
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