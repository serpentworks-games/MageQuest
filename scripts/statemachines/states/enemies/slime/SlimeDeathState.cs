using Godot;
using MageQuest.StateMachines;
using MageQuest.Utils;

class SlimeDeathState : EnemyDeathState
{
    public SlimeDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void TickPhysicsState(float deltaTime)
    {
        base.TickPhysicsState(deltaTime);
    }

    public override void TickState(float deltaTime)
    {
        base.TickState(deltaTime);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}