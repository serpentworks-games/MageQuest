using System;
using Godot;
using MageQuest.Combat;
using MageQuest.StateMachines.States;

namespace MageQuest.StateMachines
{
    public partial class EnemyStateMachine : StateMachine
    {
        //Public Configs
        [ExportGroup("Enemy Specific Variables")]
        [Export] public float ChaseDistance { get; private set; } = 5f;
        [Export] public float AttackRange { get; private set; } = 1f;
        [Export] public float SuspicionWaitTime { get; private set; }

        [ExportGroup("Patrol Variables")]
        [Export] public PatrolPath PatrolPath { get; private set; }
        [Export] public float WaypointDwellTime { get; private set; }
        [Export] public float WaypointTolerance { get; private set; }

        //State
        public bool CanChasePlayer { get; private set; }
        public bool CanAttackPlayer { get; private set; }
        public Vector3 GuardPosition { get; private set; }
        public int CurrenWaypointIndex { get; set; }

        //Refs
        public CharacterBody3D PlayerBody3D { get; private set; }
        public NavigationAgent3D Agent { get; private set; }


        public override void _Ready()
        {
            base._Ready();
            GuardPosition = Body3D.GlobalPosition;
            CharacterStats.OnDamageApplied += HandleImpacts;
        }

        private void HandleImpacts()
        {
            SwitchState(new EnemyImpactState(this));
        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
        }

        public override void InitRefs()
        {
            Agent = (NavigationAgent3D)GetNode("../NavigationAgent3D");
            PlayerBody3D = (CharacterBody3D)GetNode("../../../Characters/Player");
            base.InitRefs();
        }
    }
}