using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickmanShankSimulator.Physics
{
    class Node
    {
        public Vector2 Position;
        public float Friction, Mass;

        public Node(float X, float Y, int mass)
        {
            Position.X = X;
            Position.Y = Y;
            Friction = 0;
            Mass = mass;
        }

        public void Update(float deltaTime)
        {

        }
    }
}
