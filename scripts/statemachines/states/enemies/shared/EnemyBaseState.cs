using Godot;

namespace MageQuest.StateMachines.States
{
    public abstract class EnemyBaseState : State
    {
        protected EnemyStateMachine stateMachine;

        public EnemyBaseState(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
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

        protected void ApplyMovement(Vector3 targetPos, float deltaTime)
        {
            stateMachine.Agent.TargetPosition = targetPos;

            if (stateMachine.Agent.TargetDesiredDistance < 1) { return; }

            Vector3 direction = (targetPos - stateMachine.Body3D.Position).Normalized();
            Vector3 velocity = CalculateVelocity(direction);
            stateMachine.Body3D.Velocity = velocity;

            ApplyRotation(deltaTime, direction);

            stateMachine.Body3D.MoveAndSlide();
        }

        protected Vector3 CalculateVelocity(Vector3 direction)
        {
            Vector3 velocity = stateMachine.Body3D.Velocity;

            velocity.X = direction.X * stateMachine.MoveSpeed;
            velocity.Z = direction.Z * stateMachine.MoveSpeed;
            return velocity;
        }

        protected void ApplyRotation(double delta, Vector3 direction)
        {
            Vector3 rotation = stateMachine.CharacterMesh.Rotation;
            float arcTangent = Mathf.Atan2(direction.Z, direction.X);

            rotation.Y = Mathf.LerpAngle(
                stateMachine.CharacterMesh.Rotation.Y,
                arcTangent - stateMachine.Body3D.Rotation.Y,
                stateMachine.RotationSpeed * (float)delta
            );

            stateMachine.CharacterMesh.Rotation = rotation;
        }
    }
}