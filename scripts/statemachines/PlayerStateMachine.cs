using MageQuest.Core;
using MageQuest.StateMachines.States;

namespace MageQuest.StateMachines
{
    public partial class PlayerStateMachine : StateMachine
    {
        //Public Configs


        //Refs
        public InputReader InputReader { get; private set; }
        public CameraRig CameraRig { get; private set; }


        public override void _Ready()
        {
            base._Ready();
            SwitchState(new PlayerMoveState(this));
            CharacterStats.OnDamageApplied += HandleImpacts;
        }

        public override void _Process(double delta)
        {
            base._Process(delta);
        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
        }

        private void HandleImpacts()
        {
            SwitchState(new PlayerImpactState(this));
        }

        public override void InitRefs()
        {
            InputReader = (InputReader)GetNode("../InputReader");
            CameraRig = (CameraRig)GetNode("../CamRig");

            base.InitRefs();

        }
    }
}