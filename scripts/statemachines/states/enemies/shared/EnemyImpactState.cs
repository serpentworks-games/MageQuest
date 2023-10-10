using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    public class EnemyImpactState : EnemyBaseState
    {
        float stateDuration;
        public EnemyImpactState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
            stateDuration = stateMachine.ImpactStateTime;
        }

        public override void EnterState()
        {
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeHitTriggerRequestParam, (int)AnimationNodeOneShot.OneShotRequest.Fire);
        }

        public override void TickState(float deltaTime)
        {
            stateDuration -= deltaTime;
            if (stateDuration <= 0f)
            {
                stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            }
        }

        public override void TickPhysicsState(float deltaTime)
        {

        }

        public override void ExitState()
        {

        }

    }
}