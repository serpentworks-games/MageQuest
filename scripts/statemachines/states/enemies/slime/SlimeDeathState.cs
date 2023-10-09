using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Godot;
using MageQuest.StateMachines;
using MageQuest.StateMachines.States;
using MageQuest.Utils;

class SlimeDeathState : EnemyBaseState
{
    public SlimeDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
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
        SceneTreeTimer deathAnimTimer = stateMachine.GetTree().CreateTimer(0.4f); //hiss magic number hiss!!
        deathAnimTimer.Timeout += DisableNodes;

    }

    public override void ExitState()
    {

    }

    private void DisableNodes()
    {
        stateMachine.Body3D.Visible = false;
        stateMachine.Body3D.ProcessMode = Node.ProcessModeEnum.Disabled;
    }
}