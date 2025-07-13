using Godot;
using System;

public partial class ShovelerNode : Node2D
{
    public Game game { get { return GameManager.Game; } }

    public override void _Ready()
    {
        game.currentNode = this;
    }

    public override void _Process(double delta)
    {

    }

//called when player selects an upgrade from the tree
    public void incrementShovelUpgrade()
    {

    }
    

}
