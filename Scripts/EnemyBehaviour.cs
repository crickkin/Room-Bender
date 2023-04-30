using Godot;
using System;

public class EnemyBehaviour : Area2D
{
	private float _moveFactor = 96;

	private AnimatedSprite _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

		var player = GetTree().CurrentScene.GetNode<Area2D>("Player");
		player.Connect("PositionUpdate", this, "OnPlayerMovement");
	}

	private void OnPlayerMovement(Vector2 newPosition, bool horizontal, Vector2 direction)
	{
		if ((horizontal && (Position.y == newPosition.y)) ||
				!horizontal && (Position.x == newPosition.x))
		{
			Move(direction * -1);
		}
	}

	private void Move(Vector2 direction)
	{
		Position += direction * _moveFactor;
		if (!GameScene.Instance.BetweenEdge(Position))
		{
			DieMonsterYouDontBelongInThisWorld();
		}
	}

	private void DieMonsterYouDontBelongInThisWorld()
	{
		_animatedSprite.Animation = "death";
	}

	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation == "death")
		{
			QueueFree();
		}
	}
	private void _on_Enemy_area_entered(object area)
	{
        Player player = area as Player;

        if (player != null)
        {
			if (!player.TakeDamage().IsDead)
			{
				DieMonsterYouDontBelongInThisWorld();
			}
        }
	}
}