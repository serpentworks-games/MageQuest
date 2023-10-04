using System.Diagnostics;
using System.Numerics;
using Godot;
using Quaternion = Godot.Quaternion;
using Vector2 = Godot.Vector2;
using Vector3 = Godot.Vector3;

class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void EnterState()
    {

    }

    public override void TickState(float deltaTime)
    {
        float currentBlendPos = (float)stateMachine.AnimationTree.Get(StringRefs.MoveBlendTreeName);
        float moveToBlendPos = stateMachine.Body3D.Velocity.Normalized().Length();
        double blendValue = Mathf.Lerp(currentBlendPos, moveToBlendPos, 0.05); //hiss magic value hiss!!
        stateMachine.AnimationTree.Set(StringRefs.MoveBlendTreeName, blendValue);
    }

    public override void TickPhysicsState(float deltaTime)
    {
        float camY = stateMachine.CameraRig.Transform.Basis.GetEuler().Y;

        Vector3 movement = new()
        {
            X = stateMachine.InputReader.MovementValue.X,
            Y = 0,
            Z = stateMachine.InputReader.MovementValue.Y
        };
        movement = movement.Rotated(Vector3.Up, camY).Normalized();
        stateMachine.Body3D.Velocity = movement * stateMachine.MoveSpeed;

        ApplyRotation(deltaTime, movement);
    }

    public override void ExitState()
    {

    }

    private void ApplyRotation(float deltaTime, Vector3 movement)
    {
        if (stateMachine.InputReader.MovementValue != Vector2.Zero)
        {
            Vector3 charMeshRotation = stateMachine.CharacterMesh.Rotation;

            float arcTangent = Mathf.Atan2(movement.X, movement.Z);

            charMeshRotation.Y = Mathf.LerpAngle(
                stateMachine.CharacterMesh.Rotation.Y,
                arcTangent - stateMachine.Body3D.Rotation.Y,
                stateMachine.RotationSpeed * deltaTime
            );

            stateMachine.CharacterMesh.Rotation = charMeshRotation;
        }
    }


}