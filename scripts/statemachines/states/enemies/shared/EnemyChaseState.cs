using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    public class EnemyChaseState : EnemyBaseState
    {
        Vector3 target;
        float stateDuration;

        public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
            stateDuration = stateMachine.SuspicionWaitTime;
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
                stateMachine.SwitchState(new EnemyAttackState(stateMachine));
                return;
            }
            if (!IsInChaseRange())
            {
                stateDuration -= deltaTime;
                if (stateDuration > 0)
                {
                    stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 0f);
                    return;
                }
                if(stateMachine.PatrolPath != null)
                {
                    stateMachine.SwitchState(new EnemyPatrolState(stateMachine));
                }
                else
                {
                    stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 1f);
                    target = stateMachine.GuardPosition;
                    if ((target - stateMachine.Body3D.Position).Length() < 0.1)
                    {
                        stateMachine.SwitchState(new EnemyIdleState(stateMachine));
                        return;
                    }
                }
            }

            Move(deltaTime, target);
        }

        public override void TickState(float deltaTime)
        {

        }

        public override void ExitState()
        {

        }
    }
}