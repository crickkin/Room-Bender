using Godot;
using System;

public class UIManager : Node2D
{
    private Node2D _gameOver;
    private AudioStreamPlayer2D _gameOverSFX;

    public override void _Ready()
    {
        _gameOver = GetNode<Node2D>("Game Over");
        _gameOverSFX = GetNode<AudioStreamPlayer2D>("GameOverSFX");

        var player = GetTree().CurrentScene.GetNode("Player");
        player.Connect("PlayerDied", this, "OnPlayerDeath");
    }

    private void OnPlayerDeath()
    {
        _gameOver.Visible = true;
        _gameOverSFX.Play();
    }
}
