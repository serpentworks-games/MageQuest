using Godot;

namespace MageQuest.Combat
{
    public partial class AttackData : Resource
    {
        [ExportGroup("Attack Animation Params")]
        [Export] public string TriggerRequestParamPath { get; private set; } = "";
        [Export] public string TriggerActiveParamPath { get; private set; } = "";

        [ExportGroup("Damage, Collision, Projectiles")]
        [Export] public int AttackDamage { get; private set; }
        [Export] public float AttackSpeed { get; private set; }
    }
}