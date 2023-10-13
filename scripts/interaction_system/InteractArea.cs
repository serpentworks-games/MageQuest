using Godot;
using MageQuest.InteractionSystem.Actions;
using MageQuest.StateMachines;
using System;
using System.Diagnostics;

namespace MageQuest.InteractionSystem
{
    public partial class InteractArea : Area3D
    {
        [Export] public InteractionType InteractOn { get; private set; } = InteractionType.Collision;
        [Export] public InteractionAction[] Actions { get; private set; }

        public override void _Ready()
        {
            BodyEntered += OnBodyEntered;
            BodyExited += OnBodyExited;
        }

        void OnBodyEntered(Node3D body)
        {
            Debug.Print($"Entered {this.Name}");
            if (InteractOn == InteractionType.InputAction)
            {
                PlayerStateMachine player = body.GetNodeOrNull<PlayerStateMachine>("StateMachine");
                if (player != null)
                {
                    player.CanInteract = true;
                }
            }
            else
            {
                OnInteract();
            }
        }

        void OnBodyExited(Node3D body)
        {
            Debug.Print($"Exited {this.Name}");
            if (InteractOn == InteractionType.InputAction)
            {
                PlayerStateMachine player = body.GetNodeOrNull<PlayerStateMachine>("StateMachine");
                if (player != null)
                {
                    player.CanInteract = false;
                }
            }
        }

        public void OnInteract()
        {
            foreach (var item in Actions)
            {
                item.OnInteraction();
            }
        }
    }
}