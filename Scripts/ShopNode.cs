using Godot;
using Minigame = Game.Minigame;

public partial class ShopNode : Node
{
	public Game game { get { return GameManager.Game; } }
	public Minigame minigame;

	public override void _Ready()
	{
		game.currentNode = this;
		minigame = game.currentMinigame;
		GetNode<Button>("Back").Pressed += () => onBack();
		GetNode<Button>("Start").Pressed += () => onStart();
	}

	public override void _Process(double delta)
	{
	}

	public void onStart()
	{
		GetTree().ChangeSceneToFile("res://Scenes/" + minigame + ".tscn");
	}

	public void onBack()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Overworld.tscn");
		game.currentMinigame = Minigame.Overworld;
	}
}
