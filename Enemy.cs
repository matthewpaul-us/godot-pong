using Godot;
using System;

public class Enemy : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	[Export]
	public float BaseSpeed;

	[Export]
	public int Difficulty;

	[Export]
	public int SpeedMultiplier;

	private Vector2 _velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(float delta)
	{
		MoveAndCollide(_velocity * delta);
	}

	public void OnBallChangedPosition(Vector2 ballPosition)
	{
		var direction = Vector2.Zero;
		if (ballPosition.y > Position.y)
		{
			direction = Vector2.Down;
		}
		else if (ballPosition.y < Position.y)
		{
			direction = Vector2.Up;
		}

		_velocity = direction * (BaseSpeed + SpeedMultiplier * Difficulty);
	}
}
