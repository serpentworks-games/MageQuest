using Godot;
using MageQuest.StateMachines.States;

namespace MageQuest.StateMachines
{
    public partial class SlimeStateMachine : EnemyStateMachine
    {
        public override void _Ready()
        {
            base._Ready();
            SwitchState(new SlimeIdleState(this));
        }

        public override void _Process(double delta)
        {
            if (CharacterStats.GetCurrentHealth() == 0)
            {
                SwitchState(new SlimeDeathState(this));
            }
            base._Process(delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
        }
    }
}