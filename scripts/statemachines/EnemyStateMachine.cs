using Godot;
using MageQuest.Combat;
using System;

namespace MageQuest.StateMachines
{
    public partial class EnemyStateMachine : StateMachine
    {
        //Public Configs
        [ExportCategory("StateMachine")]
        [ExportGroup("Combat Variables")]
        [Export] public float ChaseDistance { get; private set; } = 5f;
        [Export] public float AttackRange { get; private set; } = 1f;

        //State
        public bool CanChasePlayer { get; private set; }
        public bool CanAttackPlayer { get; private set; }

        //Refs
        public AnimationTree AnimationTree { get; private set; }
        public Node3D EnemyMesh { get; private set; }
        public CharacterBody3D CharacterBody3D { get; private set; }
        public CharacterBody3D PlayerBody3D { get; private set; }


        public override void _Ready()
        {
            AnimationTree = (AnimationTree)GetNode("../AnimationTree");
            CharacterBody3D = (CharacterBody3D)GetParent();
            PlayerBody3D = (CharacterBody3D)GetNode("../../../Characters/Player");
            EnemyMesh = (Node3D)GetNode("../Mesh");

        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
        }
    }
}