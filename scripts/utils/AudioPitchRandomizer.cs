using Godot;
using System;

namespace MageQuest.Utils
{
    public partial class AudioPitchRandomizer : AudioStreamPlayer
    {
        [Export] float lowerRange = 0.95f;
        [Export] float upperRange = 1.08f;

        RandomNumberGenerator randomNumGen = new();

        public override void _Ready()
        {
            randomNumGen.Randomize();
            ChangePitch();
            Finished += ChangePitch;
        }

        public void ChangePitch()
        {
            PitchScale = randomNumGen.RandfRange(lowerRange, upperRange);
        }
    }
}
