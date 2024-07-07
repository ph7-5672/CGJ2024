using Cgj_2024.code;
using Cgj_2024.code.BackEnd;
using Cgj_2024.code.BackEnd.Phase;
using Godot;
using System;
using System.Linq;

public partial class PlayerRound_MobillsePhase : Control
{
    public override void _Ready()
    {
        base._Ready();
        Confirm.Pressed += ConfirmPressed;
    }

    void ConfirmPressed()
    {
        CurrentPhase.PlayerMobilizedTribes = [.. Game.Instance.SelectedGoblinTribes];
        Game.Instance.SelectedGoblinTribes.Clear();
        Game.Instance.World.NextPhase();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Visible = World.IsPlayerControl && World.CurrentPhase is MobilisePhase;
        SetVisable(Visible);
        Confirm.Disabled = Game.Instance.SelectedGoblinTribes.Count == 0;

        if (Visible)
        {
            GoblinTroopsLabel.Text = Game.Instance.SelectedGoblinTribes.Select(t => t.Troops).Sum().ToString();
            HumanTroopsLabel.Text = Game.Instance.SelectedHumanTerritory.Tribe.Troops.ToString();
        }
    }

    void SetVisable(bool visable)
    {
        Confirm.Visible = visable;
    }

    [Export] Button Confirm;
    [Export] Label GoblinTroopsLabel;
    [Export] Label HumanTroopsLabel;

    World World => Game.Instance.World;
    MobilisePhase CurrentPhase => World.CurrentPhase as MobilisePhase;
}
