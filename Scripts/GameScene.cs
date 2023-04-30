using Godot;
using System;

public class GameScene : Node2D
{

	public override void _Ready()
	{
		//
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
}
