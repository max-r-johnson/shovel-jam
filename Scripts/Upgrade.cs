using System.Collections.Generic;
using Minigame = Game.Minigame;

public partial class Upgrade

{
    public Game game { get { return GameManager.Game; } }
    public Minigame minigame;
    public string text;
    // Cost of the upgrade and subsequent levels. A list of length 5 means the upgrade has 5 levels.
    public List<int> cost;
    public List<Upgrade> childUpgrades;

    public Upgrade()
    {
    }
    
    public virtual void upgradeMethod()
    {
        
    }

}
