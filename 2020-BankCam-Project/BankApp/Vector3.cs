using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x+1;
            this.y = y+1;
            this.z = z+1;
        }

        public Vector3(Joint joint)
        {
            this.x = joint.Position.X+1;
            this.y = joint.Position.Y+1;
            this.z = joint.Position.Z+1;
        }

        

        public override String ToString()
        {
            return "x:" + xMax(640) + " y:" + yMax(480);
        }

        public int xMax(int width)
        {
            return (int)Math.Max(0, Math.Min(x * (float)(width/2), (float)width));
        }

        public int yMax(int height)
        {
            return (height -((int)Math.Max(0, Math.Min(y * (float)(height/2), (float)height))));
        }
    }

}
