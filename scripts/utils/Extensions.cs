using System;
using Godot;

public static class Extentions
{
    public static void QueueFreeWithDelay(Node node, float delay)
    {
        Timer timer = new Timer();
        timer.WaitTime = delay;
        timer.Timeout += node.QueueFree;
    }

    public static float RepeatValue(float time, float length)
    {
        return Mathf.Clamp(time - Mathf.Floor(time / length) * length, 0, length);
    }

    public static float Clamp01(float value)
    {
        if (value <0f)
            return 0f;
        else if (value > 1f)
            return 1f;
        else
            return value;
    }

    public static float LerpClamped(float a, float b, float t)
    {
        return a + (b - a) * Clamp01(t);
    }

    public static float PingPong(float t, float length)
    {
        t = RepeatValue(t, length * 2f);
        return length - MathF.Abs(t - length);
    }

}