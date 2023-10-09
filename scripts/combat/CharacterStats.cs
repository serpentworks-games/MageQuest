using System;
using Godot;
namespace MageQuest.Combat
{
    public partial class CharacterStats : Node
    {
        [Export] public int MaxHealth { get; private set; }

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
        }

        public int GetCurrentHealth()
        {
            return currentHealth;
        }
    }
}