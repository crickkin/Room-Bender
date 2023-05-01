using Godot;
using System;

public class GameScene : Node2D
{
	public static GameScene Instance { get; private set; }
	public Quad Edges { get; private set; } = new Quad(top: 72, bottom: 648, right: 928, left: 352);

	private bool _gameEnded = false;

	private static bool tutorial = false;

	public bool TutorialCompleted => tutorial;

	[Signal] public delegate void ShowTutorial(bool show);

	public override void _Ready()
	{
		Instance = this;

		if (!tutorial)
		{
			GD.Print("Não fez o tutorial");
			EmitSignal(nameof(ShowTutorial), true);
			// tutorial = true;
		}

		var player = GetTree().CurrentScene.GetNode("Player");
		player.Connect("PlayerDied", this, "OnPlayerDeath");
	}

	public override void _Process(float delta)
	{
		HandleTutorial();

		if (!_gameEnded) return;

		if (Input.IsActionJustPressed("restart"))
		{
			GetTree().ReloadCurrentScene();
		}
	}

	private void HandleTutorial()
	{
		if (!tutorial)
		{
			if (Input.IsActionJustPressed("ui_accept"))
			{
				tutorial = true;
				EmitSignal(nameof(ShowTutorial), false);
			}
		}
	}

	private void OnPlayerDeath()
	{
		_gameEnded = true;
	}

	public bool BetweenEdge(Vector2 position, float offset = 0)
	{
		return !(position.x >= (Edges.Right - offset) || position.x <= (Edges.Left + offset) || 
			position.y >= (Edges.Bottom - offset) || position.y <= (Edges.Top + offset));
	}

	public static Vector2 Lerp(Vector2 from, Vector2 to, float _in)
	{
		Vector2 destination = new Vector2(0, 0);
		destination.x = Mathf.Lerp(from.x, to.x, _in);
		destination.y = Mathf.Lerp(from.y, to.y, _in);

		return destination;
	}

	public static Vector2 Abs(Vector2 value)
	{
		return new Vector2(Mathf.Abs(value.x), Mathf.Abs(value.y));
	}

	[Serializable]
	public class Quad
	{
		public float Top { get; set; }
		public float Bottom { get; set; }
		public float Right { get; set; }
		public float Left { get; set; }

		public Quad(float top, float bottom, float right, float left)
		{
			Top = top;
			Bottom = bottom;
			Right = right;
			Left = left;
		}
	}
}
