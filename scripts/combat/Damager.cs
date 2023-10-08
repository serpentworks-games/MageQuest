using System;
using System.Diagnostics;
using Godot;
using MageQuest.StateMachines;

namespace MageQuest.Combat
{
    public partial class Damager : Area3D
    {
        public override void _Ready()
        {
            this.BodyEntered += OnBodyEntered;
        }

        private void OnBodyEntered(Node3D body)
        {
            Debug.Print($"Hit: {body.Name}");
        }
    }
}