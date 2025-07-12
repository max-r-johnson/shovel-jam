using Minigame = Game.Minigame;

public partial class Upgrade

{
    public Game game { get { return GameManager.Game; } }
    public Minigame minigame;

    public Upgrade(Minigame minigame)
    {
        this.minigame = minigame;
    }
}
