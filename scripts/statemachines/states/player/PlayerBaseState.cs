using System.Diagnostics;
using Godot;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion, float moveSpeed)
    {
        stateMachine.Body3D.Velocity = (motion + stateMachine.ForceHandler.Movement) * moveSpeed;
        stateMachine.Body3D.MoveAndSlide();
    }
}