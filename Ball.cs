using Godot;
using System;

public class Ball : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    public float Speed;

    private Random _rand;

    private Vector2 _screenSize;

    private Vector2 _ballSize;

    private Vector2 _velocity;

    [Signal]
    public delegate void LeftScreen(Vector2 position);

    [Signal]
    public delegate void ChangedPosition(Vector2 position);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _ballSize = GetNode<ColorRect>("ColorRect").RectSize;
        _screenSize = GetViewportRect().Size;

        _rand = RandomSingleton.Instance;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        if (Position.y < 0)
        {
            _velocity = new Vector2(
                _velocity.x,
                Math.Abs(_velocity.y));
        }

        // Off the bottom
        if (Position.y + _ballSize.y > _screenSize.y)
        {
            _velocity = new Vector2(
                _velocity.x,
                -Math.Abs(_velocity.y));
        }

        var oldPosition = Position;

        KinematicCollision2D collision = MoveAndCollide(_velocity * delta);

        if (collision != null)
        {
            _velocity.x *= -1;
            _velocity *= 1.1f;
        }

        if (Position - oldPosition != Vector2.Zero)
        {
            EmitSignal("ChangedPosition", Position);
        }
    }

    public void ResetTo(Vector2 position)
    {
        Position = position;
        _velocity = Vector2.Zero;
    }

    public void StartGame()
    {
        var randomVelocity = Vector2.Down.Rotated((float)(-Mathf.Pi * _rand.NextDouble()));

        _velocity = randomVelocity.Normalized() * Speed;
    }

    public void OnExitScreen()
    {
        EmitSignal("LeftScreen", Position);
    }

    private void OnBallbodyEntered(object body)
    {
        GD.Print("Collided");
        _velocity = new Vector2(-_velocity.x, _velocity.y);
    }
}