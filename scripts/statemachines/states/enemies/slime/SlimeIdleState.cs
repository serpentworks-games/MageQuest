using Godot;
using MageQuest.Utils;
using System;

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
            if (stateMachine.CanAttackPlayer)
                stateMachine.SwitchState(new SlimeAttackState(stateMachine));
            else if (stateMachine.CanChasePlayer)
                stateMachine.SwitchState(new SlimeChaseState(stateMachine));
        }

        public override void ExitState()
        {

        }
    }
}
