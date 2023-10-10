using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    public class PlayerImpactState : PlayerBaseState
    {
        float stateDuration;
        public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine)
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
            if(stateDuration <= 0f)
            {
                ReturnToMovement();
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