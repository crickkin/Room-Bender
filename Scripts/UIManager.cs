using Godot;
using System;

public class UIManager : Node2D
{
    private Node2D _gameOver;
    private Node2D _tutorial;
    private AudioStreamPlayer2D _gameOverSFX;

    private Label _playerTimerLayer;

    public override void _Ready()
    {
        _gameOver = GetNode<Node2D>("Game Over");
        _tutorial = GetNode<Node2D>("Tutorial");
        _gameOverSFX = GetNode<AudioStreamPlayer2D>("GameOverSFX");
        _playerTimerLayer = GetNode<Label>("PlayerTimer");

        GetTree().CurrentScene.Connect("ShowTutorial", this, "ShowTutorial");

        var player = GetTree().CurrentScene.GetNode("Player");
        player.Connect("PlayerDied", this, "OnPlayerDeath");
        player.Connect("UpdateTimer", this, "OnTimerUpdate");
    }

    private void OnTimerUpdate(int timer)
    {
        if (timer < 0) 
            return;

        _playerTimerLayer.Text = timer.ToString();
    }

    private void OnPlayerDeath()
    {
        _gameOver.Visible = true;
        _gameOverSFX.Play();
    }

    private void ShowTutorial(bool show)
    {
        _tutorial.Visible = show;
    }
}
