using System;
using System.Numerics;

namespace CasseBriqueSandra.Sandra;

class Utils
{
    public static bool ColliedByBox(IActor p1, IActor p2)
    {
        return p1.BoundingBox.Intersects(p2.BoundingBox);
    }
    public static float Angle(Vector2 a, Vector2 b)
    {
        return (float)Math.Atan2(b.Y - a.Y, b.X - a.X);
    }

}
