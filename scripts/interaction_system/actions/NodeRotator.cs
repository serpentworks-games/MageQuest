using System.Diagnostics;
using Godot;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class NodeRotator : SimpleNodeTransformer
    {
        [Export] Node3D objectToRotate;
        [Export] Vector3 axis = Vector3.Forward;
        [Export(PropertyHint.Range, "0,360,")] float startRotation = 0;
        [Export(PropertyHint.Range, "0,360,")] float endRotation = 90f;

        public override void PerformTransform(float pos, float delta)
        {
            //     float curvePos = accelCurve.Sample(pos);
            //     float lerpedValue = Extentions.LerpClamped(startRotation, endRotation, curvePos);

            //     objectToRotate.RotateObjectLocal(axis, lerpedValue * delta);

            //     Debug.Print($"Curve Pos: {curvePos}");
            //     Debug.Print($"Value Lerped: {lerpedValue * delta}");

            Tween tween = GetTree().CreateTween();
            tween.TweenProperty(objectToRotate, "rotation", endRotation, loopDuration).SetTrans(Tween.TransitionType.Linear);
        }
    }
}