using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MageQuest.Combat
{
    public partial class PatrolPath : Node
    {
        List<Node3D> points = new();

        public override void _Ready()
        {
            foreach (Node3D child in GetChildren().Cast<Node3D>())
            {
                points.Add(child);
            }
        }

        public int GetNextIndex(int i)
        {
            if (i + 1 == GetChildCount())
            {
                return 0;
            }

            return i + 1;
        }

        public Vector3 GetWaypointPos(int i)
        {
            return points[i].GlobalPosition;
        }
    }
}

