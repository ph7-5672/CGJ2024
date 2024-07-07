using Cgj_2024.code;
using Cgj_2024.code.BackEnd;
using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;
using System;
using System.Linq;

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

        if (Visible)
        {
            LabelAttacker.Text = $"哥布林兵力: {World.CurrentTurn.CurrentRound.PlayerMobilizedTribes.Sum(t => t.Troops)}";
            LabelDefender.Text = $"领主兵力: {World.CurrentTurn.CurrentRound.AIMobilizedTribes.Sum(t => t.Troops)}";
            LabelResult.Text = World.CurrentTurn.CurrentRound.BattleResult ? ResultWin : ResultLose;
        }
        SetVisable(Visible);
    }

    void SetVisable(bool visable)
    {
        Confirm.Visible = visable;
        LabelAttacker.Visible = visable;
        LabelDefender.Visible = visable;
        LabelResult.Visible = visable;
    }

    World World => Game.Instance.World;
    [Export] Button Confirm;
    [Export] Label LabelAttacker;
    [Export] Label LabelDefender;
    [Export] Label LabelResult;

    string ResultWin => @$"我们胜利了！哦我是说，您胜利了。
占领了{Game.Instance.SelectedHumanTerritory.Name}。
兵力：{Game.Instance.SelectedHumanTerritory.Troops}
收入：{Game.Instance.SelectedHumanTerritory.Treasure}";
    static readonly string ResultLose = "我们失败了";
}
