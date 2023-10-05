using Godot;

public partial class CameraRig : Node3D
{
    [Export] public float MouseSensitivity { get; private set; } = 5;
    [Export] public float UpperRotationLimit { get; private set; } = -0.75f;
    [Export] public float LowerRotationLimit { get; private set; } = 0.25f;
    [Export] public float MinCameraZoom { get; private set; } = 5;
    [Export] public float MaxCameraZoom { get; private set; } = 10;

    public SpringArm3D SpringArm3D { get; private set; }

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
        SpringArm3D = (SpringArm3D)GetNode("SpringArm3D");
    }

    public override void _Process(double delta)
    {
        GlobalPosition = GetParentNode3D().GlobalPosition;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion eventMouseMotion)
        {
            float xRot = Mathf.Clamp(
                Rotation.X - eventMouseMotion.Relative.Y /
                1000 * MouseSensitivity, UpperRotationLimit, LowerRotationLimit
                );
            float yRot = Rotation.Y - eventMouseMotion.Relative.X / 1000 * MouseSensitivity;
            Rotation = new Vector3(xRot, yRot, 0);
        }

        if (@event is InputEventMouseButton eventMouseButton)
        {
            if ((int)eventMouseButton.ButtonIndex == 4) //Scroll wheel
            {
                if (SpringArm3D.SpringLength < MaxCameraZoom)
                {
                    SpringArm3D.SpringLength += 0.1f;
                }
            }

            if ((int)eventMouseButton.ButtonIndex == 5) //Scroll wheel
            {
                if (SpringArm3D.SpringLength > MinCameraZoom)
                {
                    SpringArm3D.SpringLength -= 0.1f;
                }
            }
        }
    }
}