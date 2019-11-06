using System;
using System.Collections.Generic;
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
    }
}
