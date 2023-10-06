using Godot;

public partial class ForceHandler : Node
{
    float verticalVelocity;

    public Vector3 Movement => Vector3.Up * verticalVelocity;
    public CharacterBody3D Body3D { get; private set; }

    public override void _Ready()
    {
        Body3D = (CharacterBody3D)GetParent();
    }

    public override void _PhysicsProcess(double delta)
    {
        if ((verticalVelocity < 0f) && Body3D.IsOnFloor())
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity -= (float)ProjectSettings.GetSetting(StringRefs.GravityPath) * (float)delta;
        }
    }
}