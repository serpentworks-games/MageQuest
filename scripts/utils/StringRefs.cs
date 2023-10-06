
using System;

/// <summary>
/// A class to hold the BILLION string refs that Godot uses
/// for reference in other scripts
/// </summary>
public static class StringRefs
{
    //Shared
	//Physics
    public static string GravityPath => "physics/3d/default_gravity";

	//Anim Params
    public static string AnimTreeVelocityBlendParam => "parameters/velocity/blend_amount";
    public static string AnimTreeDeathTriggerRequestParam => "parameters/deathTrigger/request";
    public static string AnimTreeAttackTriggerRequestParam => "parameters/attackTrigger/request";
}
