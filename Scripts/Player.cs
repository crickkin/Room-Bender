using Godot;
using System;

public class Player : Area2D
{
	private int _moveFactor = 96;

	private enum State { Idle, Dead };
	private State _state = State.Idle;

	private AnimatedSprite _animatedSprite;

	[Signal]
	public delegate void PositionUpdate(Vector2 position, bool horizontalMovement, Vector2 direction);

	[Signal]
	public delegate void JewelCollected();

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}

	public override void _Process(float delta)
	{
		HandleInputs();

		if (Input.IsActionJustPressed("ui_select"))
		{
			ChangeState(State.Dead);
		}
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
		if (!GameScene.Instance.BetweenEdge(Position + movement))
			return;
		
		Position += movement;
		bool horizontal = (direction == Vector2.Left || direction == Vector2.Right);

		EmitSignal(nameof(PositionUpdate), Position, horizontal, direction);
	}

	public void Collect()
	{
		EmitSignal(nameof(JewelCollected));
	}

	private void _on_AnimatedSprite_animation_finished()
	{
		// Replace with function body.
		if (_animatedSprite.Animation == "death")
		{
			GD.Print("R.i.p. player");
			Visible = false;
			_animatedSprite.Playing = false;
		}
	}
}


