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
        private const int Height = 500;
        public Vector2 Position;
        public Vector2 Velocity;
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
            Velocity.Y += Mass * Gravity * deltaTime;
            if (Position.Y >= Height)
                Velocity.Y = 0;
            Position.Y += Velocity.Y * deltaTime;
            if (Position.Y > Height)
                Position.Y = Height;
            if (Position.Y < Height)
                HasDrag = true;
        }
    }
}
