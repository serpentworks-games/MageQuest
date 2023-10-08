using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Godot;
using MageQuest.Utils;
using Quaternion = Godot.Quaternion;
using Vector2 = Godot.Vector2;
using Vector3 = Godot.Vector3;

namespace MageQuest.StateMachines.States
{
    class PlayerMoveState : PlayerBaseState
    {
        Vector3 movement;

        public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {

        }

        public override void TickState(float deltaTime)
        {
            UpdateAnimationTree();
        }

        public override void TickPhysicsState(float deltaTime)
        {
            if (stateMachine.InputReader.IsAttackPressed)
            {
                stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0));
                return;
            }
            CalculateMovement();

            ApplyRotation(deltaTime, movement);

            ApplyForces(movement, stateMachine.MoveSpeed);
            stateMachine.Body3D.MoveAndSlide();
        }

        public override void ExitState()
        {

        }

        private void CalculateMovement()
        {
            float camY = stateMachine.CameraRig.Transform.Basis.GetEuler().Y;

            movement = new()
            {
                X = stateMachine.InputReader.MovementValue.X,
                Y = 0,
                Z = stateMachine.InputReader.MovementValue.Y
            };
            movement = movement.Rotated(Vector3.Up, camY).Normalized();
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

        private void UpdateAnimationTree()
        {
            float currentBlendPos = (float)stateMachine.AnimationTree.Get(StringRefs.AnimTreeVelocityBlendParam);
            float moveToBlendPos;

            if (stateMachine.InputReader.MovementValue == Vector2.Zero) moveToBlendPos = 0;
            else moveToBlendPos = 1;

            double blendValue = Mathf.Lerp(currentBlendPos, moveToBlendPos, stateMachine.AnimLerpDampTime);
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, blendValue);
        }
    }
}