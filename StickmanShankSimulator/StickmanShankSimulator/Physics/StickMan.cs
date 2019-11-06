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
        public Node L_Foot, R_Foot, L_Knee, R_Knee, Waist, Chest, L_Elbow, R_Elbow, L_Hand, R_Hand, Head;
        public RigidBody L_Calf, R_Calf, L_Thigh, R_Thigh, Trunk, L_Biceps, R_Biceps, L_Forearm, R_Forearm, Neck;
        public float Scale;

        public StickMan(float X, float Y, float scale = 1)
        {
            Waist = new Node(X, Y, 10);
            L_Knee = new Node(Waist.Position.X - (10 * scale), Waist.Position.Y + (25 * scale), 10);
            R_Knee = new Node(Waist.Position.X + (10 * scale), Waist.Position.Y + (25 * scale), 10);
            L_Foot = new Node(L_Knee.Position.X, L_Knee.Position.Y + (25 * scale), 10);
            R_Foot = new Node(R_Knee.Position.X, R_Knee.Position.Y + (25 * scale), 10);
            Chest = new Node(Waist.Position.X, Waist.Position.Y - (35 * scale), 10);
            L_Elbow = new Node(Chest.Position.X - (20 * scale), Chest.Position.Y + (15 * scale), 10);
            R_Elbow = new Node(Chest.Position.X + (20 * scale), Chest.Position.Y + (15 * scale), 10);
            L_Hand = new Node(L_Elbow.Position.X, L_Elbow.Position.Y + (20 * scale), 10);
            R_Hand = new Node(R_Elbow.Position.X, R_Elbow.Position.Y + (20 * scale), 10);
            Head = new Node(Chest.Position.X, Chest.Position.Y - (10 * scale), 10);

            L_Calf = new RigidBody(L_Foot, L_Knee, 3.5f);
            R_Calf = new RigidBody(R_Foot, R_Knee, 3.5f);
            L_Thigh = new RigidBody(L_Knee, Waist, 3.5f);
            R_Thigh = new RigidBody(R_Knee, Waist, 3.5f);
            Trunk = new RigidBody(Waist, Chest, 3.5f);
            L_Biceps = new RigidBody(Chest, L_Elbow, 3.5f);
            R_Biceps = new RigidBody(Chest, R_Elbow, 3.5f);
            L_Forearm = new RigidBody(L_Elbow, L_Hand, 3.5f);
            R_Forearm = new RigidBody(R_Elbow, R_Hand, 3.5f);
            Neck = new RigidBody(Head, Chest, 3.5f);

            Scale = scale;
        }

        public void Draw(Graphics g)
        {
            Brush brush = Brushes.Black;

            L_Calf.Draw(g);
            R_Calf.Draw(g);
            L_Thigh.Draw(g);
            R_Thigh.Draw(g);
            Trunk.Draw(g);
            L_Biceps.Draw(g);
            R_Biceps.Draw(g);
            L_Forearm.Draw(g);
            R_Forearm.Draw(g);
            Neck.Draw(g);

            Rectangle rect = new Rectangle();
            rect.X = (int)((float)Head.Position.X - (10 * Scale));
            rect.Y = (int)((float)Head.Position.Y - (15 * Scale));
            rect.Width = (int)((float)20 * Scale);
            rect.Height = (int)((float)20 * Scale);

            g.FillEllipse(brush, rect);
        }
        public void Update(float deltaTime)
        {
            L_Calf.Update(deltaTime);
            R_Calf.Update(deltaTime);
            L_Thigh.Update(deltaTime);
            R_Thigh.Update(deltaTime);
            Trunk.Update(deltaTime);
            L_Biceps.Update(deltaTime);
            R_Biceps.Update(deltaTime);
            L_Forearm.Update(deltaTime);
            R_Forearm.Update(deltaTime);
            Neck.Update(deltaTime);
        }
    }
}
