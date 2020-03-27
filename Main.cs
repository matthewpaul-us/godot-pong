using Godot;
using System;

public class Main : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private int _playerScore;

	private int _enemyScore;

	private Vector2 _screenSize;

	private GUI _gui;
	private Ball _ball;
	private Vector2 _ballInitialPosition;
	private Enemy _enemy;
	private Vector2 _enemyInitialPosition;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screenSize = GetViewport().Size;

		_ball = GetNode<Ball>("Ball");
		_ballInitialPosition = _ball.Position;

		_enemy = GetNode<Enemy>("Enemy");
		_enemyInitialPosition = _enemy.Position;

		_gui = GetNode<GUI>("GUI");
		_gui.UpdateScore(0, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Input.IsActionJustPressed("quit"))
		{
			GetTree().Quit();
		}

		if (Input.IsActionJustPressed("reset"))
		{
			Reset();
			_ball.StartGame();
		}
	}

	private void OnBallLeftScreen(Vector2 position)
	{
		if (position.x > _screenSize.x / 2)
			_playerScore += 1;
		else
			_enemyScore += 1;

		_gui.UpdateScore(_playerScore, _enemyScore);
	}

	public void Reset()
	{
		_ball.ResetTo(_ballInitialPosition);
		_enemy.Position = _enemyInitialPosition;
		_enemy.Difficulty = _playerScore - _enemyScore;
	}
}
