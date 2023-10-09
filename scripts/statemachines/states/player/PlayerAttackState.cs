using System;
using Godot;
using MageQuest.Combat;
using MageQuest.Utils;

namespace MageQuest.StateMachines.States
{
    class PlayerAttackState : PlayerBaseState
    {
        readonly AttackData attackData;
        public PlayerAttackState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
        {
            attackData = stateMachine.Attacks[attackIndex];
        }

        public override void EnterState()
        {
            stateMachine.Weapon.SetWeaponDamage(attackData.AttackDamage);
            stateMachine.AnimationTree.Set(attackData.TriggerRequestParamPath, (int)AnimationNodeOneShot.OneShotRequest.Fire);
        }

        public override void TickPhysicsState(float deltaTime)
        {

        }

        public override void TickState(float deltaTime)
        {
            if (!(bool)stateMachine.AnimationTree.Get(attackData.TriggerActiveParamPath))
            {
                stateMachine.SwitchState(new PlayerMoveState(stateMachine));
            }
        }

        public override void ExitState()
        {

        }

    }
}