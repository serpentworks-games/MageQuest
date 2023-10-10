using Godot;
using MageQuest.Utils;
using System;
using System.Diagnostics;

namespace MageQuest.StateMachines.States
{
    public partial class SlimeIdleState : EnemyIdleState
    {
        public SlimeIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void TickState(float deltaTime)
        {
            base.TickState(deltaTime);
        }

        public override void TickPhysicsState(float deltaTime)
        {
            base.TickPhysicsState(deltaTime);
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}
