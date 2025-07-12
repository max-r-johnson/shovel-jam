using Minigame = Game.Minigame;

public partial class Shop
{
	public Game game { get { return GameManager.Game; } }
	public Minigame minigame;

	public Shop(Minigame minigame)
	{
		this.minigame = minigame;
	}
}
