using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickmanShankSimulator.Physics
{
    class RigidBody
    {
        public Node A, B;
        public float Length, Strength, SidewaysBias;
        RigidBodyStatus Status;

        public RigidBody(Node a, Node b)
        {
            A = a;
            B = b;
        }

        public void Update(float deltaTime)
        {
            float oldXDiff = B.Position.X - A.Position.X;

            A.Update(deltaTime);
            B.Update(deltaTime);
            
            if (Status == RigidBodyStatus.Idle)
                return;

            float distance = A.Position.Distance(B.Position);

            if (Status == RigidBodyStatus.Extending)
            {
                if (distance < Length)
                {
                    float delta = Length - distance;
                    B.Position += (B.Position - A.Position) * (delta > Strength ? Strength : delta);
                }
            }
            if (Status == RigidBodyStatus.Contracting)
            {
                if (distance > (Length / 2.0f))
                {
                    float delta = (Length / 2.0f) - distance;
                    B.Position -= (B.Position - A.Position) * (delta > Strength ? Strength : delta);
                }
            }
            
            float newXDiff = B.Position.X - A.Position.X;
            if (newXDiff != oldXDiff)
            {
                float diff = newXDiff - oldXDiff;
                B.Position.X -= diff - (diff * SidewaysBias);
            }
        }

        public void Draw(Graphics cancer)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 3;

            cancer.DrawLine(pen, A.Position.X, A.Position.Y, B.Position.X, B.Position.Y);
        }
    }
}
