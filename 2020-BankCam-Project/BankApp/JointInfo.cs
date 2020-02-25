using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class JointInfo
    {
        public Vector3 position;
        public Joint type;
        public String name;

        public JointInfo(Joint type)
        {
            this.type = type;
            this.name = type.JointType.ToString();
            this.position = new Vector3(type);
        }

        public override String ToString()
        {
            return name + ": " + position;
        }
    }
}
