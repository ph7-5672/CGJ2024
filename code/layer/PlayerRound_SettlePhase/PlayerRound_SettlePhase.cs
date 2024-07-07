using Cgj_2024.code;
using Cgj_2024.code.BackEnd;
using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;
using System;

public partial class PlayerRound_SettlePhase : Control
{
    public override void _Ready()
    {
        base._Ready();
        Confirm.Pressed += ConfirmPressed;
    }

    void ConfirmPressed()
    {
        Game.Instance.World.NextPhase();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Visible = World.IsPlayerControl && World.CurrentPhase is SettlePhase;
    }

    [Export] Button Confirm;
    World World => Game.Instance.World;

    [Export] Label LabelAttacker;
    [Export] Label LabelDefender;
}
