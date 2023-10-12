using Godot;
using MageQuest.Combat;

public partial class Projectile : CharacterBody3D
{
    [Export] float speed = 4f;
    [Export] float maxLifetime = 5f;

    Vector3 startPos;

    Damager damager;
    SceneTreeTimer timer;

    public override void _Ready()
    {
        damager = (Damager)GetNode("Damager");
        base._Ready();

        timer = GetTree().CreateTimer(maxLifetime);
        timer.Timeout += QueueFree;
    }

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        Velocity = Vector3.Left * speed;
        Velocity = Velocity.Rotated(Vector3.Up, GlobalRotation.Y);
        MoveAndSlide();   
    }

    public void SetupProjectile(Vector3 startPos)
    {
        this.startPos = startPos;
        Position = startPos;
    }
}