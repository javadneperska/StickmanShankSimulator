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

        public void Update(float deltaTime)
        {
            A.Update(deltaTime);
            B.Update(deltaTime);

            float distance = A.Position.Distance(B.Position);
        }

        public void Draw(Graphics cancer)
        {
            Pen pen = Pens.Black;
            pen.Width = 10;

            cancer.DrawLine(pen, A.Position.X, A.Position.Y, B.Position.X, B.Position.Y);
        }
    }
}
