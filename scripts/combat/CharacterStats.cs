using System;
using Godot;
namespace MageQuest.Combat
{
    public partial class CharacterStats : Node
    {
        [Export] public int MaxHealth { get; private set; }

        public event Action OnDamageApplied;

        int currentHealth;
        bool isDead;

        public override void _Ready()
        {
            currentHealth = MaxHealth;
        }

        public void ApplyDamage(int damage)
        {
            if (currentHealth == 0) { return; }

            currentHealth = Mathf.Max(currentHealth - damage, 0);

            OnDamageApplied?.Invoke();
        }

        public int GetCurrentHealth()
        {
            return currentHealth;
        }
    }
}