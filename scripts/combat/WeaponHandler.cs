using System.Diagnostics;
using Godot;

namespace MageQuest.Combat
{
    public partial class WeaponHandler : Node3D
    {
        [Export] public Damager DamageArea { get; private set; }
        [Export] public Node3D ProjectileStartLocation { get; private set; }
        [Export] public PackedScene ProjectileScene { get; private set; }

        public int WeaponDamage { get; private set; }

        public void EnableWeaponDamageArea()
        {
            DamageArea.Monitoring = true;
        }

        public void DisableWeaponDamageArea()
        {
            DamageArea.Monitoring = false;
        }

        public void SetWeaponDamage(int damage)
        {
            WeaponDamage = damage;
            DamageArea?.SetDamage(damage);
            //Projectile?.SetDamage(damage);
        }

        public void InstantiateProjectile()
        {
            Debug.Print("Pew pew!");
            Projectile projectile = ProjectileScene.Instantiate<Projectile>();
            
            projectile.SetupProjectile(ProjectileStartLocation.Position);
            GetTree().CurrentScene.AddChild(projectile);
            projectile.Transform = ProjectileStartLocation.GlobalTransform;
        }
    }
}