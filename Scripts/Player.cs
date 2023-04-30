using Godot;
using System;

public class Player : Area2D
{
	private int _moveFactor = 96;

	[Signal]
	public delegate void Moved(Vector2 direction);

	public override void _Ready()
	{
		
	}

	public override void _Process(float delta)
	{
		HandleInputs();
	}

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

	private void Move(Vector2 direction)
	{
		if (direction == Vector2.Zero)
			return;
		
		Position += direction * _moveFactor;
		EmitSignal(nameof(Moved), direction);
	}
}
