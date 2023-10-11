using System;
using Godot;

namespace MageQuest.StateMachines.States
{
    class EnemyPatrolState : EnemyBaseState
    {
        float timeSinceArrivedAtWaypoint = Mathf.Inf;
        int currentIndex;

        public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {

        }

        public override void TickState(float deltaTime)
        {

        }

        public override void TickPhysicsState(float deltaTime)
        {
            timeSinceArrivedAtWaypoint += deltaTime;

            if (IsInAttackRange())
            {
                stateMachine.SwitchState(new EnemyAttackState(stateMachine));
                return;
            }
            if (IsInChaseRange())
            {
                stateMachine.SwitchState(new EnemyChaseState(stateMachine));
                return;
            }

            Vector3 nextPos = stateMachine.GuardPosition;
            if (stateMachine.PatrolPath != null)
            {
                if (AtWayPoint())
                {
                    timeSinceArrivedAtWaypoint = 0f;
                    AdvanceWaypoints();
                }
                nextPos = GetCurrentWayPoint();
            }

            if (timeSinceArrivedAtWaypoint > stateMachine.WaypointDwellTime)
            {
                Move(deltaTime, nextPos);
            }

        }

        public override void ExitState()
        {
            stateMachine.CurrenWaypointIndex = currentIndex;
        }

        private bool AtWayPoint()
        {
            float dist = (stateMachine.Body3D.Position - GetCurrentWayPoint()).Length();
            return dist < stateMachine.WaypointTolerance;
        }

        private void AdvanceWaypoints()
        {

        }

        private Vector3 GetCurrentWayPoint()
        {
            return Vector3.Zero;
        }


    }
}