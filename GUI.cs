using Godot;
using System;

public class GUI : CanvasLayer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//
	//  }
	public void UpdateScore(int playerScore, int enemyScore)
	{
		GetNode<Label>("MarginContainer/HBoxContainer/PlayerScore").Text = playerScore.ToString("N0");
		GetNode<Label>("MarginContainer/HBoxContainer/EnemyScore").Text = enemyScore.ToString("N0");
	}
}
