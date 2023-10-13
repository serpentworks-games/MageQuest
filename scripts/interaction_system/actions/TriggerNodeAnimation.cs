using System.Diagnostics;
using Godot;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class TriggerNodeAnimation : InteractionAction
    {
        [Export] string animName;
        [Export] Node3D nodeToAnimate;

        public override void PerformInteraction()
        {
            var animPlayer = nodeToAnimate.GetNodeOrNull<AnimationPlayer>("AnimationPlayer");
            if (animPlayer == null)
            {
                Debug.Print($"CAUTION! {nodeToAnimate.Name} has no AnimationPlayer! No animations will play!");
                return;
            }

            animPlayer.Play(animName);
        }
    }
}