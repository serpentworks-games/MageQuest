using System.Diagnostics;
using Godot;
using MageQuest.StateMachines;
using MageQuest.StateMachines.States;
using MageQuest.Utils;

class EnemyDeathState : EnemyBaseState
{
    float delay = 1f; //hiss magic number hiss!!!
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {
        stateMachine.AnimationTree.Set(StringRefs.AnimTreeDeathTriggerRequestParam, (int)AnimationNodeOneShot.OneShotRequest.Fire);
    }

    public override void TickPhysicsState(float deltaTime)
    {

    }

    public override void TickState(float deltaTime)
    {
        if ((bool)stateMachine.AnimationTree.Get(StringRefs.AnimTreeDeathTriggerActiveParam))
        {
            delay -= deltaTime;
            if (delay <= 0)
            {
                stateMachine.Body3D.Visible = false;
                stateMachine.Body3D.ProcessMode = Node.ProcessModeEnum.Disabled;
            }
        }
    }

    public override void ExitState()
    {

    }

    private void DisableNodes()
    {

    }
}