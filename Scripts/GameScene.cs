using Godot;
using System;

public class GameScene : Node2D
{
	public static GameScene Instance { get; private set; }
	public Quad Edges { get; private set; } = new Quad(top: 72, bottom: 648, right: 928, left: 352);

	public override void _Ready()
	{
		Instance = this;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

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
