using Godot;
using System;

public partial class ShovelController : CharacterBody2D
{
	public Game game { get { return GameManager.Game; } }

	public override void _Ready()
	{
		game.currentNode = this;
		float shovelXPos = 135f;
		float shovelYPos = 357f;
	}

	public override void _Process(double delta)
	{
		
	}
}
