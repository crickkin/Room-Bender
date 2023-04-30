using Godot;
using System;

public class Player : Area2D
{
	private int _moveFactor = 96;
	private int _life = 3;

	private bool _isDead = false;

	public bool IsDead => _isDead;

	private enum State { Idle, Dead };
	private State _state = State.Idle;

	private AnimatedSprite _animatedSprite;

	[Signal] public delegate void PositionUpdate(Vector2 position, bool horizontalMovement, Vector2 direction);
	[Signal] public delegate void JewelCollected();
	[Signal] public delegate void LifeUpdate(int life);
	[Signal] public delegate void PlayerDied();

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

	public override void _Process(float delta)
	{
		if (_isDead) return;

		HandleInputs();
	}

	#region Inputs
	private void HandleInputs()
	{
		Vector2 movement = Vector2.Zero;

		if (Input.IsActionJustPressed("ui_up"))
		{
			movement = Vector2.Up;
		}
		else if (Input.IsActionJustPressed("ui_down"))
		{
			movement = Vector2.Down;
		}
		else if (Input.IsActionJustPressed("ui_right"))
		{
			movement = Vector2.Right;
		}
		else if (Input.IsActionJustPressed("ui_left"))
		{
			movement = Vector2.Left;
		}

		Move(movement);
	}
	#endregion

	private void ChangeState(State newState)
	{
		_state = newState;
		_animatedSprite.Animation = "death";
	}

	private void Move(Vector2 direction)
	{
		if (direction == Vector2.Zero)
			return;
		
		Vector2 movement = direction * _moveFactor;
		if (!GameScene.Instance.BetweenEdge(Position + movement, offset: 96))
			return;
		
		Position += movement;
		bool horizontal = (direction == Vector2.Left || direction == Vector2.Right);

		EmitSignal(nameof(PositionUpdate), Position, horizontal, direction);
	}

	public void Collect()
	{
		EmitSignal(nameof(JewelCollected));
	}

	public Player TakeDamage()
	{
		_life--;
		EmitSignal(nameof(LifeUpdate), _life);

		if (_life <= 0)
		{
			Die();
		}

		return this;
	}

	private void Die()
	{
		_animatedSprite.Animation = "death";
	}

	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation == "death")
		{
			GD.Print("R.i.p. player");
			Visible = false;
			_animatedSprite.Playing = false;
			EmitSignal(nameof(PlayerDied));
		}
	}
}


