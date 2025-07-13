using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class TDNode : Node2D
{
	public Game game { get { return GameManager.Game; } }
	public int currentLevel { get { return game.TDCurrentLevel; } set { game.TDCurrentLevel = value; } }
	public int maxLevel = 1;
	public int currentWave = 1;

	public override void _Ready()
	{
		GD.Print(currentLevel);
		game.currentNode = this;
		if (currentLevel == 0)
		{
			ColorRect levelDisplay = GetNode<ColorRect>("LevelDisplay");
			levelDisplay.Visible = true;
			// numLevels is amount of jsons
			for (int i = 0; i < 3; i++)
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
					GetTree().ChangeSceneToFile("res://Levels/TDLevel" + levelIndex + ".tscn");
					GD.Print("Pressed " + levelButton.Name);
					parseLevelData();
				};
			}
		}
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (currentLevel != 0)
		{
			if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				TileMapLayer backgroundTileMap = GetNode<Node2D>("Background").GetNode<TileMapLayer>("BackgroundTileMap");
				TileMapLayer interactableTileMap = GetNode<Node2D>("Background").GetNode<TileMapLayer>("InteractableTileMap");
				// Convert mouse position to local cell coordinates
				Vector2 localPosition = GetGlobalMousePosition();
				Vector2I cell = backgroundTileMap.LocalToMap(localPosition);
				string tag = (string)backgroundTileMap.GetCellTileData(cell).GetCustomData("Tag");
				if (tag == "Placeable")
				{
					for (int i = -1; i < 2; i++)
					{
						for (int j = -1; j < 2; j++)
						{
							if ((string)backgroundTileMap.GetCellTileData(new Vector2I(cell.X + i, cell.Y + j)).GetCustomData("Tag") == "Placeable")
							{
								GD.Print("Placeable tiles at cells: " + new Vector2I(cell.X + i, cell.Y + j));
							}
						}
					}
				}
				if (tag == "Spawn")
				{
					GD.Print("Clicked on spawn point at cell: " + cell);
					// show next wave
				}
				else if (tag == "Base")
				{
					GD.Print("Clicked on base point at cell: " + cell);
					// Show base health
				}
			}
		}
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
