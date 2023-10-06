using Godot;
using System;

public partial class SlimeStateMachine : EnemyStateMachine
{

    [Export] public NavigationAgent3D agent;
    [Export] public Node3D pointToMoveTo;

    public override void _Ready()
    {
        base._Ready();
        SwitchState(new SlimeIdleState(this));

    }

    public override void _Process(double delta)
    {
        //Death state
        //Attack state
        //Chase State
        //Idle State
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (agent.TargetDesiredDistance < 1) { return; }
        Vector3 globalPosition = pointToMoveTo.Position - CharacterBody3D.Position;
        agent.TargetPosition = globalPosition;
        Vector3 velocity = CharacterBody3D.Velocity;
        velocity.X = globalPosition.Normalized().X * MoveSpeed;
        velocity.Z = globalPosition.Normalized().Z * MoveSpeed;
        CharacterBody3D.MoveAndSlide();
        base._PhysicsProcess(delta);
    }
}
