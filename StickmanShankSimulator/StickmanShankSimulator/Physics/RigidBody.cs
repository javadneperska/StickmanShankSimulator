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
        public readonly float Length, Strength, SidewaysBias;
        public readonly RigidBodyStatus Status;

        public RigidBody(Node a, Node b, float str, float sideways = 5, RigidBodyStatus status = RigidBodyStatus.Extending)
        {
            A = a;
            B = b;
            Length = A.Position.Distance(B.Position);
            Console.WriteLine("len: " + Length);
            Strength = str;
            Status = status;
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
                /*if (A.Velocity.Length() == 0)
                {
                    B.Velocity -= B.Velocity.Normalize() * (B.Velocity.Length() > Strength ? Strength : B.Velocity.Length());
                }
                if (B.Velocity.Length() == 0)
                {
                    A.Velocity -= A.Velocity.Normalize() * (A.Velocity.Length() > Strength ? Strength : A.Velocity.Length());
                }*/
                if (distance < Length)
                {
                    float delta = Length - distance;
                    Vector2 action = (B.Position - A.Position).Normalize() * (delta > Strength ? Strength : delta);
                    B.Position += action;
                    B.Velocity.Y -= B.Velocity.Y > action.Y ? action.Y*2 : B.Velocity.Y;
                    A.Velocity.Y -= A.Velocity.Y > action.Y ? action.Y*2 : A.Velocity.Y;
                }
                if (distance > Length)
                {
                    float delta = -(Length - distance);
                    Vector2 action = (B.Position - A.Position).Normalize() * (delta > Strength ? Strength : delta);
                    B.Position -= action;
                    B.Velocity.Y -= B.Velocity.Y > action.Y ? action.Y*2 : B.Velocity.Y;
                    A.Velocity.Y -= A.Velocity.Y > action.Y ? action.Y*2 : A.Velocity.Y;
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

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 3;

            g.DrawLine(pen, A.Position.X, A.Position.Y, B.Position.X, B.Position.Y);
        }
    }
}
