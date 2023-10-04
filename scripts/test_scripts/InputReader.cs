using System;
using System.Diagnostics;
using Godot;

public partial class InputReader : Node
{
    public event Action JumpEvent;
    public event Action AttackEvent;

    [Export] public Vector2 MovementValue { get; private set; }

    public override void _Process(double delta)
    {
        OnJump();
        OnAttack();
        OnMove();
    }

    public void OnJump()
    {
        if (Input.IsActionPressed("jump"))
        {
            Debug.Print("Jump pressed!");
            JumpEvent?.Invoke();
        }
    }

    public void OnAttack()
    {
        if (Input.IsActionPressed("attack"))
            AttackEvent?.Invoke();
    }

    public void OnMove()
    {
        MovementValue = Input.GetVector("moveRight", "moveLeft", "moveDown", "moveUp");
    }

}