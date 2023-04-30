using Godot;
using System;

public class Player : Area2D
{
	private int _moveFactor = 50;

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

		Position += movement * _moveFactor;
	}
}
