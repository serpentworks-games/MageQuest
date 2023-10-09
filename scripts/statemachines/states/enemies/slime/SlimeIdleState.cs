using Godot;
using MageQuest.Utils;
using System;
using System.Diagnostics;

namespace MageQuest.StateMachines.States
{
    public partial class SlimeIdleState : EnemyBaseState
    {
        public SlimeIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 0f);
        }

        public override void TickPhysicsState(float deltaTime)
        {

        }

        public override void TickState(float deltaTime)
        {
            if (IsInAttackRange())
            {
                stateMachine.SwitchState(new SlimeAttackState(stateMachine));
                return;
            }
            if (IsInChaseRange())
            {
                stateMachine.SwitchState(new SlimeChaseState(stateMachine));
                return;
            }
        }

        public override void ExitState()
        {

        }
    }
}
