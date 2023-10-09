using System;
using System.Diagnostics;
using Godot;
using MageQuest.StateMachines;

namespace MageQuest.Combat
{
    public partial class Damager : Area3D
    {
        [Export] int areaDamage;

        int damage;
        public override void _Ready()
        {
            damage = areaDamage;
            BodyEntered += OnBodyEntered;
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        private void OnBodyEntered(Node3D body)
        {
            CharacterStats charStats = (CharacterStats)body.GetNode("CharacterStats");
            if (charStats != null)
            {
                charStats.ApplyDamage(damage);
                Debug.Print($"Hit {body.Name}; it has {charStats.GetCurrentHealth()} HP remaining");
            }
        }
    }
}