using Godot;
using System;

public partial class StateMachine : Node
{
    State currentState;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        currentState?.TickState((float)delta);
    }

    public void SwitchState(State newState)
    {
        currentState?.ExitState();

        currentState = newState;
        currentState?.EnterState();
    }

}
