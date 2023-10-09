using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    public class SlimeChaseState : EnemyBaseState
    {
        public SlimeChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 1f);
        }

        public override void ExitState()
        {

        }

        public override void TickPhysicsState(float deltaTime)
        {
            if (IsInAttackRange())
            {
                stateMachine.SwitchState(new SlimeAttackState(stateMachine));
                return;
            }
            if (!IsInChaseRange())
            {
                stateMachine.SwitchState(new SlimeIdleState(stateMachine));
                return;
            }

            ApplyMovement(stateMachine.PlayerBody3D.Position, deltaTime);
        }

        public override void TickState(float deltaTime)
        {

        }
    }
}