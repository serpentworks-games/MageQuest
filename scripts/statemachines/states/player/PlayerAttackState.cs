using Godot;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    class PlayerAttackState : PlayerBaseState
    {
        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeAttackTriggerRequestParam, (int)AnimationNodeOneShot.OneShotRequest.Fire);
        }

        public override void TickPhysicsState(float deltaTime)
        {

        }

        public override void TickState(float deltaTime)
        {
            int stateEnumIndex = (int)stateMachine.AnimationTree.Get(StringRefs.AnimTreeAttackTriggerRequestParam);
            if (stateEnumIndex == (int)AnimationNodeOneShot.OneShotRequest.None)
            {
                stateMachine.SwitchState(new PlayerMoveState(stateMachine));
            }
        }

        public override void ExitState()
        {

        }
    }
}