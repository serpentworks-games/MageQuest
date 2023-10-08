using Godot;
using MageQuest.StateMachines.States;

namespace MageQuest.StateMachines
{
    public partial class SlimeStateMachine : EnemyStateMachine
    {
        [Export] public Node3D pointToMoveTo;

        public NavigationAgent3D Agent { get; private set; }

        public override void _Ready()
        {
            Agent = (NavigationAgent3D)GetNode("../NavigationAgent3D");
            base._Ready();
            SwitchState(new SlimeIdleState(this));
        }

        public override void _Process(double delta)
        {
            //if(PlayerBody3D.IsDead) return;
            //Death state
            //if(MonsterHealth <= 0) 
            // SwitchState(new SlimeDeathState(this))

            //Attack state
            //if(CanAttackPlayer())
            //  SwitchState(new SlimeAttackState(this))

            //Chase State
            //else if(CanSeePlayer())
            //  SwitchState(new SlimeChaseState(this))

            //Idle State
            //else
            //  SwitchState(new SlimeIdleState(this))
            base._Process(delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            if (pointToMoveTo == null) { return; }
            if (Agent.TargetDesiredDistance < 1) { return; }

            Vector3 direction = (pointToMoveTo.Position - CharacterBody3D.Position).Normalized();

            Vector3 velocity = CalculateVelocity(direction);
            CharacterBody3D.Velocity = velocity;

            ApplyRotation(delta, direction);

            CharacterBody3D.MoveAndSlide();
            base._PhysicsProcess(delta);
        }

        private Vector3 CalculateVelocity(Vector3 direction)
        {
            Agent.TargetPosition = pointToMoveTo.Position;
            Vector3 velocity = CharacterBody3D.Velocity;

            velocity.X = direction.X * MoveSpeed;
            velocity.Z = direction.Z * MoveSpeed;
            return velocity;
        }

        private void ApplyRotation(double delta, Vector3 direction)
        {
            Vector3 rotation = EnemyMesh.Rotation;
            float arcTangent = Mathf.Atan2(direction.Z, direction.X);

            rotation.Y = Mathf.LerpAngle(
                EnemyMesh.Rotation.Y,
                arcTangent - CharacterBody3D.Rotation.Y,
                RotationSpeed * (float)delta
            );

            EnemyMesh.Rotation = rotation;
        }
    }
}