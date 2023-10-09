using Godot;
using MageQuest.Combat;

namespace MageQuest.StateMachines.States
{
    public class SlimeAttackState : EnemyBaseState
    {
        readonly AttackData attackData;
        public SlimeAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
        {
            attackData = stateMachine.Attacks[0];
        }

        public override void EnterState()
        {
            stateMachine.Weapon.SetWeaponDamage(attackData.AttackDamage);
            stateMachine.AnimationTree.Set(attackData.TriggerRequestParamPath, (int)AnimationNodeOneShot.OneShotRequest.Fire);
        }

        public override void ExitState()
        {

        }

        public override void TickPhysicsState(float deltaTime)
        {

        }

        public override void TickState(float deltaTime)
        {
            if(!(bool)stateMachine.AnimationTree.Get(attackData.TriggerActiveParamPath))
            {
                if(!IsInAttackRange())
                {
                    stateMachine.SwitchState(new SlimeChaseState(stateMachine));
                    return;
                }

                stateMachine.SwitchState(new SlimeIdleState(stateMachine));
            }
        }
    }
}