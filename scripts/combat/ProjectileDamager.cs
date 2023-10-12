using System.Diagnostics;
using Godot;
using MageQuest.Combat;

public partial class ProjectileDamager : Damager
{
    public override void OnBodyEntered(Node3D body)
    {
        CharacterStats charStats = (CharacterStats)body.GetNodeOrNull("CharacterStats");

        if (charStats != null)
        {
            charStats.ApplyDamage(damage);
            Debug.Print($"Hit {body.Name}; it has {charStats.GetCurrentHealth()} HP remaining");
        }
        GetParent().QueueFree();
    }
}