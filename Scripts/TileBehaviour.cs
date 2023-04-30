using Godot;
using System;
using System.Collections.Generic;

public class TileBehaviour : Node2D
{
	private int _moveFactor = 96;

	private const string JEWEL = "res://Actors/Jewel.tscn";
	private const string ENEMY = "res://Actors/Enemy.tscn";

	public override void _Ready() 
	{
		GD.Randomize();

		if (Position != new Vector2(640, 360)) // posição inicial do player
		{
			Roll(true);
		}
	}

	private void Roll(bool firstCall = false)
	{
		float itemSpawnChance = (float) GD.RandRange(0.0, 1.0);

		if (itemSpawnChance > .5)
		{
			float enemySpawnChance = (float)GD.RandRange(0.0, 1.0);
			if (!firstCall && enemySpawnChance > .7)
			{
				var enemy = GD.Load<PackedScene>(ENEMY).Instance() as Area2D;
				enemy.Position = Position;
				GetTree().CurrentScene.AddChild(enemy);
			}
			else if (itemSpawnChance > .75)
			{
				var jewel = GD.Load<PackedScene>(JEWEL).Instance();
				AddChild(jewel);
			}
		}
	}

	public void Move(Vector2 direction)
	{
		Position += direction * _moveFactor;
		EdgeHandling();
	}

	private void EdgeHandling()
	{
		Vector2 correctedPosition = Position;

		if (GameScene.Instance.BetweenEdge(Position))
			return;

		if (correctedPosition.x >= GameScene.Instance.Edges.Right)
		{
			correctedPosition.x = GameScene.Instance.Edges.Left + _moveFactor;
		}
		else if (correctedPosition.x <= GameScene.Instance.Edges.Left)
		{
			correctedPosition.x = GameScene.Instance.Edges.Right - _moveFactor;
		}
		if (correctedPosition.y >= GameScene.Instance.Edges.Bottom)
		{
			correctedPosition.y = 72 + _moveFactor;
		}
		else if (correctedPosition.y <= 72)
		{
			correctedPosition.y = GameScene.Instance.Edges.Bottom - _moveFactor;
		}

		Position = correctedPosition;
		Roll();
	}
}
