using Godot;
using MageQuest.Combat;

namespace MageQuest.StateMachines.States
{
    public class SlimeAttackState : EnemyAttackState
    {
        public SlimeAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
            attackData = stateMachine.Attacks[0];
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