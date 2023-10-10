
using System;

/// <summary>
/// A class to hold the BILLION string refs that Godot uses
/// for reference in other scripts
/// </summary>
namespace MageQuest.Utils
{
    public static class StringRefs
    {
        //Shared
        //Physics
        public static string GravityPath => "physics/3d/default_gravity";

        //Anim Params
        public static string AnimTreeVelocityBlendParam => "parameters/Velocity/blend_amount";
        public static string AnimTreeDeathTriggerRequestParam => "parameters/DeathTrigger/request";
        public static string AnimTreeDeathTriggerActiveParam => "parameters/DeathTrigger/active";
        public static string AnimTreeHitTriggerRequestParam => "parameters/HitTrigger/request";
        public static string AnimTreeHitTriggerActiveParam => "parameters/HitTrigger/active";
    }
}