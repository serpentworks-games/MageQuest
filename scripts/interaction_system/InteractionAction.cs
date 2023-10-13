using System;
using System.Diagnostics;
using Godot;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class InteractionAction : Node3D
    {
        [Export] public bool IsOneShot { get; private set; } = false;
        [Export] public float StartDelay { get; private set; } = 0;
        [Export] public float CoolDown { get; private set; } = 0;

        protected bool isTriggered = false;
        float startTime = 0;

        public virtual void PerformInteraction()
        {

        }

        public virtual void OnInteraction()
        {
            if (IsOneShot && isTriggered) return;

            isTriggered = true;

            if (CoolDown > 0)
            {
                if (Time.GetTicksUsec() > startTime + CoolDown)
                {
                    startTime = Time.GetTicksUsec() + StartDelay;
                    Execute();
                }
            }
            else
            {
                Execute();
            }
        }

        private void Execute()
        {
            if (StartDelay > 0)
            {
                SceneTreeTimer timer = GetTree().CreateTimer(StartDelay);
                timer.Timeout += PerformInteraction;
            }
            else
            {
                PerformInteraction();
            }
        }
    }
}