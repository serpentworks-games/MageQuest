using Godot;
using MageQuest.Combat;

namespace MageQuest.StateMachines.States
{
    public class EnemyAttackState : EnemyBaseState
    {
        public AttackData attackData;
        public float attackDuration;

        public EnemyAttackState(EnemyStateMachine stateMachine, int attackIndex = 0) : base(stateMachine)
        {
            attackData = stateMachine.Attacks[attackIndex];
            attackDuration = attackData.AttackSpeed;
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
            attackDuration -= deltaTime;
            if (!(bool)stateMachine.AnimationTree.Get(attackData.TriggerActiveParamPath) && attackDuration <= 0f)
            {
                if (!IsInAttackRange())
                {
                    stateMachine.SwitchState(new EnemyChaseState(stateMachine));
                    return;
                }

                stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            }
        }
    }
}