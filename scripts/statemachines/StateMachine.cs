using Godot;
using MageQuest.Combat;
using MageQuest.Core;
using MageQuest.StateMachines.States;

namespace MageQuest.StateMachines
{
    public partial class StateMachine : Node
    {
        [ExportGroup("Movement/Anim Variables")]
        [Export] public float MoveSpeed { get; private set; }
        [Export] public float RotationSpeed { get; private set; }
        [Export] public float AnimLerpDampTime { get; private set; }

        [ExportGroup("Combat Variables")]
        [Export] public AttackData[] Attacks { get; private set; }
        [Export] public WeaponHandler Weapon { get; private set; }

        public CharacterStats CharacterStats { get; private set; }
        public CharacterBody3D Body3D { get; private set; }
        public Node3D CharacterMesh { get; private set; }
        public AnimationTree AnimationTree { get; private set; }
        public AnimationPlayer AnimationPlayer { get; private set; }
        public ForceHandler ForceHandler { get; private set; }


        State currentState;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            InitRefs();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            currentState?.TickState((float)delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            currentState?.TickPhysicsState((float)delta);
        }

        public virtual void InitRefs()
        {
            Body3D = (CharacterBody3D)GetParent();
            CharacterMesh = (Node3D)GetNode("../Mesh");
            AnimationTree = (AnimationTree)GetNode("../AnimationTree");
            AnimationPlayer = (AnimationPlayer)GetNode("../AnimationPlayer");
            CharacterStats = (CharacterStats)GetNode("../CharacterStats");
            ForceHandler = (ForceHandler)GetNode("../ForceHandler");
        }

        public void SwitchState(State newState)
        {
            currentState?.ExitState();

            currentState = newState;
            currentState?.EnterState();
        }

    }
}
