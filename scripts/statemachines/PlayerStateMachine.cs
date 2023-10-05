using Godot;

public partial class PlayerStateMachine : StateMachine
{
    //Public Configs
    [Export] public float MoveSpeed { get; private set; } = 6f;
    [Export] public float RotationSpeed { get; private set; } = 20f;

    //Refs
    public InputReader InputReader { get; private set; }
    public CharacterBody3D Body3D { get; private set; }
    public CameraRig CameraRig { get; private set; }
    public Node3D CharacterMesh { get; private set; }
    public AnimationTree AnimationTree { get; private set; }

    public override void _Ready()
    {
        InitRefs();

        SwitchState(new PlayerIdleState(this));
    }

    public override void _Process(double delta)
    {

        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        Body3D.MoveAndSlide();
        base._PhysicsProcess(delta);
    }

    private void InitRefs()
    {
        InputReader = (InputReader)GetNode("../InputReader");
        Body3D = (CharacterBody3D)GetParent();
        CameraRig = (CameraRig)GetNode("../CamRig");
        CharacterMesh = (Node3D)GetNode("../Rig");
        AnimationTree = (AnimationTree)GetNode("../AnimationTree");
    }
}