using Godot;

public partial class PlayerStateMachine : StateMachine
{
    //Public Configs
    [Export] public float MoveSpeed { get; private set; }

    //Refs
    public InputReader InputReader { get; private set; }

    public override void _Ready()
    {
        InputReader = (InputReader)GetNode("../InputReader");
        SwitchState(new PlayerIdleState(this));
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}