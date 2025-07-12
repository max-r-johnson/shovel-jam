using Godot;
using Minigame = Game.Minigame;

public partial class Player : Node2D
{
	public Game game { get { return GameManager.Game; } }
	public Minigame currentMinigame = Minigame.Overworld;
	public float speed = 800f;
	public Player()
	{

	}

	public override void _Ready()
	{
		game.player = this;
	}

	public override void _Process(double delta)
	{
		Vector2 direction = Vector2.Zero;
		if (currentMinigame == Minigame.ShovelMinigame || currentMinigame == Minigame.Overworld)
		{
			if (Input.IsActionPressed("ui_right"))
				direction.X += 1;
			if (Input.IsActionPressed("ui_left"))
				direction.X -= 1;
		}
		if (currentMinigame == Minigame.Overworld)
		{
			if (Input.IsActionPressed("ui_down"))
				direction.Y += 1;
			if (Input.IsActionPressed("ui_up"))
				direction.Y -= 1;
		}

		direction = direction.Normalized();
		Position += direction * speed * (float)delta;

		if (Input.IsActionJustPressed("ui_accept"))
		{
			Interactable closestInteractable = null;
			if (currentMinigame == Minigame.Overworld)
			{
				foreach (Node child in game.currentNode.GetChildren())
				{
					if (child is Interactable interactable)
					{
						if (Position.DistanceTo(interactable.Position) < Position.DistanceTo(closestInteractable?.Position ?? Vector2.Inf) && Position.DistanceTo(interactable.Position) < 150f)
						{
							closestInteractable = (Interactable)child;
						}
					}
				}
				if (closestInteractable != null)
				{
					closestInteractable.interact();
				}
			}
			if (currentMinigame == Minigame.ShovelMinigame)
			{
				// Fire projectile
			}
			if (currentMinigame == Minigame.TowerDefenseMinigame)
			{
				// Start round?
			}
		}
		foreach (Node child in game.currentNode.GetChildren())
		{
			if (child is Interactable interactable)
			{
				if (Position.DistanceTo(interactable.Position) < 150f)
				{
					interactable.showProximityDescription();
				}
				else
				{
					interactable.hideProximityDescription();
				}
			}
		}
	}
}
