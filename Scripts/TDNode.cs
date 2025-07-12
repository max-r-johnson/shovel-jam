using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class TDNode : Node2D
{
	public Game game { get { return GameManager.Game; } }
	public int numLevels = 3;
	public int currentLevel = 0;
	public int maxLevel = 1;
	public int currentWave = 1;

	public override void _Ready()
	{
		game.currentNode = this;
		ColorRect levelDisplay = GetNode<ColorRect>("LevelDisplay");
		levelDisplay.Visible = true;
		// numLevels is amount of jsons
		for (int i = 0; i < numLevels; i++)
		{
			int levelIndex = i + 1;
			Button levelButton = new Button();
			levelButton.Text = "Level " + levelIndex;
			levelButton.Name = "Level" + levelIndex;
			levelButton.CustomMinimumSize = new Vector2(100, 100);
			levelDisplay.GetNode<GridContainer>("LevelGrid").AddChild(levelButton);
			levelButton.Pressed += () =>
			{
				currentLevel = levelIndex;
				GD.Print("Pressed " + levelButton.Name);
				parseLevelData();
			};
		}
	}

	public override void _Process(double delta)
	{

	}

	public void startWave()
	{
		GD.Print("Starting wave " + currentWave);
	}

	public void parseLevelData()
	{
		GD.Print("currentLevel: " + currentLevel);
		FileAccess file = FileAccess.Open("res://Levels/Level" + currentLevel + ".json", FileAccess.ModeFlags.Read);
		GD.Print(file);
		string levelData = file.GetAsText();
		Dictionary parsedData = (Dictionary)Json.ParseString(levelData);
		file.Close();

		GD.Print("Parsed level data: " + parsedData);
		GD.Print(parsedData["waves"]);
	}
}
