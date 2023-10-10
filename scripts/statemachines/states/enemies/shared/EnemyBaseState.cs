using System.Diagnostics;
using System.Numerics;
using Godot;
using Vector3 = Godot.Vector3;

namespace MageQuest.StateMachines.States
{
    public abstract class EnemyBaseState : State
    {
        protected EnemyStateMachine stateMachine;

        public EnemyBaseState(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            stateMachine.Agent.VelocityComputed += OnVelocityComputed;
        }

        protected bool IsInChaseRange()
        {
            float distance = (stateMachine.PlayerBody3D.Position - stateMachine.Body3D.Position).LengthSquared();
            return distance <= stateMachine.ChaseDistance * stateMachine.ChaseDistance;
        }

        protected bool IsInAttackRange()
        {
            float distance = (stateMachine.PlayerBody3D.Position - stateMachine.Body3D.Position).LengthSquared();
            return distance <= stateMachine.AttackRange * stateMachine.AttackRange;
        }

        protected void ApplyForces(Vector3 motion, float moveSpeed)
        {
            stateMachine.Body3D.Velocity = (motion + stateMachine.ForceHandler.Movement) * moveSpeed;
        }

        protected void ApplyRotation(double delta, Vector3 direction)
        {
            Vector3 rotation = stateMachine.CharacterMesh.Rotation;
            float arcTangent = Mathf.Atan2(direction.X, direction.Z);

            rotation.Y = Mathf.LerpAngle(
                stateMachine.CharacterMesh.Rotation.Y,
                arcTangent - stateMachine.Body3D.Rotation.Y,
                stateMachine.RotationSpeed * (float)delta
            );

            stateMachine.CharacterMesh.Rotation = rotation;
        }

        protected void SetMovementTarget(Vector3 moveTarget)
        {
            stateMachine.Agent.TargetPosition = moveTarget;
        }

        protected void OnVelocityComputed(Vector3 safeVelocity)
        {
            stateMachine.Body3D.Velocity = safeVelocity;
        }

        protected void ApplyNavAgentMovement()
        {
            if (stateMachine.Agent.IsNavigationFinished()) { return; }

            var nextPos = stateMachine.Agent.GetNextPathPosition();
            var currentPos = stateMachine.Body3D.GlobalPosition;
            var newVelocity = (nextPos - currentPos).Normalized() * stateMachine.MoveSpeed;
            if (stateMachine.Agent.AvoidanceEnabled)
                stateMachine.Agent.Velocity = newVelocity;
            else
                OnVelocityComputed(newVelocity);
        }
    }
}