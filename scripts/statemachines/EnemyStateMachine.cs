using Godot;
using System;

public partial class EnemyStateMachine : StateMachine
{
    //Public Configs
    [Export] public float MoveSpeed { get; private set; } = 4f;
    [Export] public float RotationSpeed { get; private set; } = 20f;
    [Export] public float MonsterHealth { get; private set; } = 10f;
    [Export] public float ChaseDistance { get; private set; } = 5f;
    [Export] public float AttackRange { get; private set; } = 1f;
    [Export] public Node3D EnemyMesh { get; private set; }

    //State
    bool canChasePlayer;
    bool canAttackPlayer;

    //Refs
    public AnimationTree AnimationTree { get; private set; }
    public CharacterBody3D CharacterBody3D { get; private set; }
    public CharacterBody3D PlayerBody3D { get; private set; }

    public override void _Ready()
    {
        AnimationTree = (AnimationTree)GetNode("../AnimationTree");
        CharacterBody3D = (CharacterBody3D)GetParent();
        PlayerBody3D = (CharacterBody3D)GetNode("../../../Characters/Player");

    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
