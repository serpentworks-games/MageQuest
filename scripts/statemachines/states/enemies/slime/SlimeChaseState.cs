using System.Diagnostics;
using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    public class SlimeChaseState : EnemyChaseState
    {
        public SlimeChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void TickPhysicsState(float deltaTime)
        {
            base.TickPhysicsState(deltaTime);
        }

        public override void TickState(float deltaTime)
        {
            base.TickState(deltaTime);
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}