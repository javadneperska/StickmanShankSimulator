using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickmanShankSimulator.Physics
{
    class Node
    {
        private const float Gravity = 0.981f;
        public Vector2 Position;
        public float Mass;
        public bool HasDrag;

        public Node(float X, float Y, int mass)
        {
            Position.X = X;
            Position.Y = Y;
            Mass = mass;
        }

        public void Update(float deltaTime)
        {
            Position.Y += Mass * Gravity * deltaTime;
            if (Position.Y > 720)
                Position.Y = 720;
        }
    }
}
