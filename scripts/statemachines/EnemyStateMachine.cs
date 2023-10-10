using Godot;

namespace MageQuest.StateMachines
{
    public partial class EnemyStateMachine : StateMachine
    {
        //Public Configs
        [ExportGroup("Enemy Specific Variables")]
        [Export] public float ChaseDistance { get; private set; } = 5f;
        [Export] public float AttackRange { get; private set; } = 1f;

        //State
        public bool CanChasePlayer { get; private set; }
        public bool CanAttackPlayer { get; private set; }
        public Vector3 GuardPosition { get; private set; }

        //Refs
        public CharacterBody3D PlayerBody3D { get; private set; }
        public NavigationAgent3D Agent { get; private set; }


        public override void _Ready()
        {
            base._Ready();
            GuardPosition = Body3D.GlobalPosition;
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