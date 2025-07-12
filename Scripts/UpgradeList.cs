using Minigame = Game.Minigame;

public partial class TriShot : Upgrade
{
    public TriShot() : base()
    {
        childUpgrades = [new TriShotDamage(), new ExtraTriShot1()];
        text = "Shoot three coal at once";
        cost = [100];
        minigame = Minigame.Overworld;
    }

    public override void upgradeMethod()
    {
        // projectiles.add(new TriShotProjectile());
        // or something
    }
}

public partial class TriShotDamage : Upgrade
{

    public TriShotDamage() : base()
    {
        text = "Your tri-shot coal does more damage";
        cost = [300, 500, 700];
        minigame = Minigame.Overworld;
    }

    public override void upgradeMethod()
    {

    }
}

public partial class ExtraTriShot1 : Upgrade
{
    public ExtraTriShot1() : base()
    {
        text = "Gain an extra tri-shot projectile";
        cost = [1000,1500];
        minigame = Minigame.Overworld;
    }

    public override void upgradeMethod()
    {

    }
}
