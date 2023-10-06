using System.Security.Cryptography.X509Certificates;
using Godot;

public partial class PlayerStateMachine : StateMachine
{
    //Public Configs
    [Export] public float MoveSpeed { get; private set; } = 6f;
    [Export] public float RotationSpeed { get; private set; } = 20f;
    [Export] public float AnimLerpDampTime { get; private set; } = 0.05f;

    //Refs
    public InputReader InputReader { get; private set; }
    public CharacterBody3D Body3D { get; private set; }
    public CameraRig CameraRig { get; private set; }
    public Node3D CharacterMesh { get; private set; }
    public AnimationTree AnimationTree { get; private set; }
    public ForceHandler ForceHandler { get; private set; }

    public override void _Ready()
    {
        InitRefs();

        SwitchState(new PlayerMoveState(this));
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    private void InitRefs()
    {
        InputReader = (InputReader)GetNode("../InputReader");
        Body3D = (CharacterBody3D)GetParent();
        CameraRig = (CameraRig)GetNode("../CamRig");
        CharacterMesh = (Node3D)GetNode("../Rig");
        AnimationTree = (AnimationTree)GetNode("../AnimationTree");
        ForceHandler = (ForceHandler)GetNode("../ForceHandler");
    }
}