using System;
using Godot;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class SimpleNodeTransformer : InteractionAction
    {
        public enum LoopType
        {
            Once,
            PingPong,
            Repeat
        }

        [Export(PropertyHint.Enum)] public LoopType loopType;
        [Export] public float loopDuration = 1;
        [Export] public Curve accelCurve;
        [Export] public bool activate;

        float time = 0f;
        float pos = 0f;
        float dir = 1f;

        public override void PerformInteraction()
        {
            activate = true;
        }

        public override void _PhysicsProcess(double delta)
        {
            if (activate)
            {
                time += dir * (float)delta / loopDuration;

                switch (loopType)
                {
                    case LoopType.Once:
                        LoopOnce();
                        break;
                    case LoopType.PingPong:
                        LoopPingPong();
                        break;
                    case LoopType.Repeat:
                        LoopRepeat();
                        break;
                }
                PerformTransform(pos, (float)delta);
            }

        }

        private void LoopOnce()
        {
            pos = Extentions.Clamp01(time);

            if (pos >= 1)
            {
                dir *= -1;
            }
        }

        private void LoopPingPong()
        {
            pos = Extentions.PingPong(time, 1f);
        }

        private void LoopRepeat()
        {
            pos = Extentions.RepeatValue(time, 1f);
        }

        public virtual void PerformTransform(float pos, float delta)
        {

        }
    }
}