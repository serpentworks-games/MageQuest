using System.Diagnostics;
using System.Linq;
using Godot;
using MageQuest.StateMachines.States;

namespace MageQuest.StateMachines
{
    public partial class SlimeStateMachine : EnemyStateMachine
    {
        bool isDead;
        public override void _Ready()
        {
            base._Ready();
            SwitchState(new SlimeIdleState(this));
        }

        public override void _Process(double delta)
        {
            if (CharacterStats.GetCurrentHealth() == 0 && isDead == false)
            {
                SwitchState(new SlimeDeathState(this));
                isDead = true;
            }

            base._Process(delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
        }
    }
}