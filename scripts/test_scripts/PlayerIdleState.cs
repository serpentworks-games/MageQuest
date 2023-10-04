using System.Diagnostics;
using System.Numerics;
using Godot;
using Vector3 = Godot.Vector3;

class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {

    }

    public override void TickState(float deltaTime)
    {
        Vector3 movement = new()
        {
            X = stateMachine.InputReader.MovementValue.X,
            Y = 0,
            Z = stateMachine.InputReader.MovementValue.Y
        };
        stateMachine.GetParent<Node3D>().Translate(movement * stateMachine.MoveSpeed * deltaTime);
    }

    public override void ExitState()
    {

    }
}