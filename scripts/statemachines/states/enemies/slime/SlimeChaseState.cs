using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    public class SlimeChaseState : EnemyBaseState
    {
        Vector3 target;

        public SlimeChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 1f);
        }

        public override void TickPhysicsState(float deltaTime)
        {
            target = stateMachine.PlayerBody3D.GlobalPosition;

            if (IsInAttackRange())
            {
                stateMachine.SwitchState(new SlimeAttackState(stateMachine));
                return;
            }
            if (!IsInChaseRange())
            {
                target = stateMachine.GuardPosition;
                if ((target - stateMachine.Body3D.Position).Length() < 0.1)
                {
                    stateMachine.SwitchState(new SlimeIdleState(stateMachine));
                    return;
                }
            }

            SetMovementTarget(target);
            ApplyNavAgentMovement();

            Vector3 direction = (target - stateMachine.Body3D.Position).Normalized();
            ApplyRotation(deltaTime, direction);
            ApplyForces(direction, stateMachine.MoveSpeed);
            stateMachine.Body3D.MoveAndSlide();
        }

        public override void TickState(float deltaTime)
        {

        }

        public override void ExitState()
        {

        }
    }
}