using Godot;

namespace MageQuest.Combat
{
    public partial class AttackData : Resource
    {
        [Export] public string AttackName { get; private set; } = "";
        [Export] public string TriggerRequestParamPath { get; private set; } = "";
        [Export] public string TriggerActiveParamPath { get; private set; } = "";
    }
}