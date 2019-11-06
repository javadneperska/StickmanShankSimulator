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

        public void Draw(Graphics cancer)
        {
            Pen pen = Pens.Black;
            pen.Width = 10;

            cancer.DrawLine(pen, A.Position.X, A.Position.Y, B.Position.X, B.Position.Y);
        }
    }
}
