using Godot;
using MageQuest.Combat;
using MageQuest.StateMachines.States;
using System;
namespace MageQuest.StateMachines
{
    public partial class StateMachine : Node
    {
        [ExportCategory("StateMachine")]
        [ExportGroup("Movement/Anim Variables")]
        [Export] public float MoveSpeed { get; private set; }
        [Export] public float RotationSpeed { get; private set; }
        [Export] public float AnimLerpDampTime { get; private set; }
        [ExportGroup("Combat Variables")]
        [Export] public HealthData HealthData { get; private set; }
        [Export] public AttackData[] Attacks { get; private set; }


        State currentState;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
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

        public void SwitchState(State newState)
        {
            currentState?.ExitState();

            currentState = newState;
            currentState?.EnterState();
        }

    }
}
