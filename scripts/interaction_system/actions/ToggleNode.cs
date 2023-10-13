using Godot;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class ToggleNode : InteractionAction
    {
        [Export] Node3D[] nodesToToggle;

        public override void PerformInteraction()
        {
            foreach (var node in nodesToToggle)
            {
                node.Visible = !node.Visible;
                if (node.ProcessMode == ProcessModeEnum.Inherit)
                {
                    node.ProcessMode = ProcessModeEnum.Disabled;
                }
                else if (node.ProcessMode == ProcessModeEnum.Disabled)
                {
                    node.ProcessMode = ProcessModeEnum.Inherit;
                }
            }
        }
    }
}