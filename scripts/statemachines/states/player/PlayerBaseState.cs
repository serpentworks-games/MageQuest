using System.Diagnostics;
using Godot;

namespace MageQuest.StateMachines.States
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        protected void ApplyForces(Vector3 motion, float moveSpeed)
        {
            stateMachine.Body3D.Velocity = (motion + stateMachine.ForceHandler.Movement) * moveSpeed;
        }

        protected void ReturnToMovement()
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }
}