using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickmanShankSimulator.Physics
{
    class StickMan
    {
        public Node L_Foot, R_Foot, L_Knee, R_Knee, Waist, Chest, L_Elbow, R_Elbox, L_Hand, R_Hand, Head;
        public RigidBody L_Calf, R_Calf, L_Thigh, R_Thigh, Trunk, L_Biceps, R_Biceps, L_Forearm, R_Forearm, Neck;

        public StickMan()
        {
            L_Foot = new Node();
            R_Foot = new Node();
            L_Knee = new Node();
            R_Knee = new Node();
            Waist = new Node();
            Chest = new Node();
            L_Elbow = new Node();
            R_Elbox = new Node();
            L_Hand = new Node();
            R_Hand = new Node();
            Head = new Node();

            L_Calf = new RigidBody();
            R_Calf = new RigidBody();
            L_Thigh = new RigidBody();
            R_Thigh = new RigidBody();
            Trunk = new RigidBody();
            L_Biceps = new RigidBody();
            R_Biceps = new RigidBody();
            L_Forearm = new RigidBody();
            R_Forearm = new RigidBody();
            Neck = new RigidBody();
        }

        public void Draw(Graphics cancer)
        {
            Brush brush = Brushes.Black;

            L_Calf.Draw(cancer);
            R_Calf.Draw(cancer);
            L_Thigh.Draw(cancer);
            R_Thigh.Draw(cancer);
            Trunk.Draw(cancer);
            L_Biceps.Draw(cancer);
            R_Biceps.Draw(cancer);
            L_Forearm.Draw(cancer);
            R_Forearm.Draw(cancer);
            Neck.Draw(cancer);

            Rectangle rect = new Rectangle();
            rect.X = (int) Head.Position.X;
            rect.Y = (int) Head.Position.Y;
            rect.Width = 20;
            rect.Height = 20;

            cancer.FillEllipse(brush, rect);
        }
    }
}
