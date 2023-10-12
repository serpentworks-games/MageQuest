using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Godot;
using MageQuest.Combat;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    class EnemyPatrolState : EnemyBaseState
    {
        float timeSinceArrivedAtWaypoint;
        int currentIndex = 0;

        public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void EnterState()
        {
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 1f);
        }

        public override void TickState(float deltaTime)
        {

        }

        public override void TickPhysicsState(float deltaTime)
        {
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
            timeSinceArrivedAtWaypoint += deltaTime;
            if (timeSinceArrivedAtWaypoint < stateMachine.WaypointDwellTime)
            {
                stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 0f);
                return;
            }
            stateMachine.AnimationTree.Set(StringRefs.AnimTreeVelocityBlendParam, 1f);
            Move(deltaTime, nextPos);
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
            currentIndex = stateMachine.PatrolPath.GetNextIndex(currentIndex);
        }

        private Vector3 GetCurrentWayPoint()
        {
            return stateMachine.PatrolPath.GetWaypointPos(currentIndex);
        }


    }
}