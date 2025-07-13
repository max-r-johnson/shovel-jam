using System.Collections.Generic;
using Godot;

public partial class Game
{
	public Player player { get; set; }
	public Node currentNode { get; set; }
	public enum Minigame { Overworld, ShovelMinigame, TowerDefenseMinigame}
	public Minigame currentMinigame = Minigame.Overworld;
	public Vector2 playerOverworldPosition = new Vector2(0, 0);
	public int TDCurrentLevel = 0;
	public Dictionary<Minigame, int> minigameHighscores = new();

	public Game()
	{
		foreach (Minigame minigame in System.Enum.GetValues(typeof(Minigame)))
		{
			minigameHighscores[minigame] = 0;
		}
	}
}
