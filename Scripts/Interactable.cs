using Godot;
using Minigame = Game.Minigame;

public partial class Interactable : Node2D
{
	public Game game { get { return GameManager.Game; } }
	[Export]
	public Minigame associatedMinigame;
	private bool uiInitialized = false;

	public void interact()
	{
		showDescription();
		GD.Print("Interacted with " + Name);
	}

	public void showProximityDescription()
	{
		Label description = GetNode<Label>("Description");
		if (associatedMinigame == Minigame.ShovelMinigame)
		{
			description.Text = "Shovel Coal";
		}
		else if (associatedMinigame == Minigame.TowerDefenseMinigame)
		{
			description.Text = "Call a Train Station";
		}
		description.Visible = true;
	}

	public void hideProximityDescription()
	{
		GetNode<Label>("Description").Visible = false;
	}

	public void showDescription()
	{
		ColorRect confirmationPanel = game.currentNode.GetNode<ColorRect>("Minigame Confirmation");
		if (!uiInitialized)
		{
			confirmationPanel.GetNode<Button>("Back").Pressed += () => onBack();
			confirmationPanel.GetNode<Button>("Upgrades").Pressed += () => onUpgrades();
			confirmationPanel.GetNode<Button>("Start").Pressed += () => onStart();
			uiInitialized = true;
		}
		confirmationPanel.Visible = true;
		confirmationPanel.GetNode<Label>("Minigame").Text = associatedMinigame.ToString();
		confirmationPanel.GetNode<Label>("Description").Text = "Description";
		confirmationPanel.GetNode<Label>("Score").Text = "High Score: " + game.minigameHighscores[associatedMinigame];
	}

	public void hideDescription()
	{
		game.currentNode.GetNode<ColorRect>("Minigame Confirmation").Visible = false;
	}

	public void onStart()
	{
		GetTree().ChangeSceneToFile("res://Scenes/" + associatedMinigame + ".tscn");
		if (game.currentMinigame == Minigame.Overworld)
		{
			game.playerOverworldPosition = game.player.GlobalPosition;
		}
		game.currentMinigame = associatedMinigame;
		hideDescription();
	}
	
	public void onUpgrades()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Shop.tscn");
		if (game.currentMinigame == Minigame.Overworld)
		{
			game.playerOverworldPosition = game.player.GlobalPosition;
		}
		game.currentMinigame = associatedMinigame;
		hideDescription();
	}

	public void onBack()
	{
		hideDescription();
	}
}
