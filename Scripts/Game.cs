using System.Collections.Generic;
using Godot;

public partial class Game
{
	public Player player { get; set; }
	public Node currentNode { get; set; }
	public enum Minigame { Overworld, ShovelMinigame, TowerDefenseMinigame}
	public Minigame currentMinigame = Minigame.Overworld;
	public Dictionary<Minigame, int> minigameHighscores = new();

	public Game()
	{
		foreach (Minigame minigame in System.Enum.GetValues(typeof(Minigame)))
		{
			minigameHighscores[minigame] = 0;
		}
	}
}
