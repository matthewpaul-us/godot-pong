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
    private Vector2 _ballPosition;

    public enum EnemyState
    {
        WaitingForStart,
        Playing
    }

    [Export]
    public EnemyState State;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public override void _PhysicsProcess(float delta)
    {
        Think(State);
        MoveAndCollide(_velocity * delta);
    }

    public void OnBallChangedPosition(Vector2 ballPosition)
    {
        _ballPosition = ballPosition;
    }

    public void Think(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.WaitingForStart:
                break;

            case EnemyState.Playing:
                var direction = Vector2.Zero;
                if (_ballPosition.y > Position.y)
                {
                    direction = Vector2.Down;
                }
                else if (_ballPosition.y < Position.y)
                {
                    direction = Vector2.Up;
                }

                _velocity = direction * (BaseSpeed + SpeedMultiplier * Difficulty);
                break;

            default:
                break;
        }
    }

    public void StartGame()
    {
        State = EnemyState.Playing;
    }

    public void ResetTo(Vector2 position)
    {
        Position = position;
        State = EnemyState.WaitingForStart;
        _velocity = Vector2.Zero;
    }
}