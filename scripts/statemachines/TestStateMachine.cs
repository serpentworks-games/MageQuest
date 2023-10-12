using MageQuest.StateMachines;
using MageQuest.StateMachines.States;

public partial class TestStateMachine : EnemyStateMachine
{

    public override void _Ready()
    {
        base._Ready();
        Godot.SceneTreeTimer sceneTreeTimer = GetTree().CreateTimer(1f);
        sceneTreeTimer.Timeout += Patrol;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public void Patrol()
    {
        SwitchState(new EnemyPatrolState(this));
    }
}