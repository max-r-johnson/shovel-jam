using Godot;
using System;

public partial class Obstacle : Area2D
{
	public Game game { get { return GameManager.Game; } }

	public override void _Ready()
	{
		game.currentNode = this;
		
	}

	public override void _Process(double delta)
	{

	}
}
