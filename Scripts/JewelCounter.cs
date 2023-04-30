using Godot;
using System;

public class JewelCounter : Label
{
	private int count = 0;

	public override void _Ready()
	{
		var player = GetTree().CurrentScene.GetNode("Player");
		player.Connect("JewelCollected", this, "OnJewelCollect");
	}

	private void OnJewelCollect()
	{
		count++;
		Text = count.ToString();
	}

}
