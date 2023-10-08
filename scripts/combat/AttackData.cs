using Godot;

namespace MageQuest.Combat
{
    public partial class AttackData : Resource
    {
        [ExportGroup("Attack Animation Params")]
        [Export] public string TriggerRequestParamPath { get; private set; } = "";
        [Export] public string TriggerActiveParamPath { get; private set; } = "";

        [ExportGroup("Damage, Collision, Projectiles")]
        [Export] public float AttackDamage { get; private set; }
        [Export] public Area3D AttackCollisionArea { get; private set; }
        [Export] public Node3D ProjectileEmitLocation { get; private set; }

    }
}