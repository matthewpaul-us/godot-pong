using Godot;
using System;

public class PlayerController : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private Player _parent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_parent = GetOwner<Player>();
		GD.Print(_parent);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var direction = Vector2.Zero;
		if (Input.IsActionPressed("up"))
		{
			direction = Vector2.Up;
		}

		if (Input.IsActionPressed("down"))
		{
			direction = Vector2.Down;
		}

		var newPosition = _parent.Position + direction * _parent.Speed * delta;

		_parent.Position = newPosition;
	}
}
