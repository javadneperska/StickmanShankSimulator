using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickmanShankSimulator.Physics
{
    struct Vector2
    {
        public float X, Y;

        public float Distance(Vector2 b)
        {
            return (float)Math.Sqrt(Math.Pow(b.X - X, 2) - Math.Pow(b.Y - Y, 2));
        }
    }
}
