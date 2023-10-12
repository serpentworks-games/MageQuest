using System.Diagnostics;
using Godot;

public static class Extentions
{
    public static void QueueFreeWithDelay(Node node, float delay)
    {
        Timer timer = new Timer();
        timer.WaitTime = delay;
        timer.Timeout += node.QueueFree;
    }
}