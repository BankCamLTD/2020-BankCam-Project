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

        public static JointInfo AnkleLeft;
        public static JointInfo AnkleRight;
        public static JointInfo ElbowLeft;
        public static JointInfo ElbowRight;
        public static JointInfo FootLeft;
        public static JointInfo FootRight;
        public static JointInfo HandLeft;
        public static JointInfo HandRight;
        public static JointInfo Head;
        public static JointInfo HipCenter;
        public static JointInfo HipLeft;
        public static JointInfo HipRight;
        public static JointInfo KneeLeft;
        public static JointInfo KneeRight;
        public static JointInfo ShoulderCenter;
        public static JointInfo ShoulderLeft;
        public static JointInfo ShoulderRight;
        public static JointInfo Spine;
        public static JointInfo WristLeft;
        public static JointInfo WristRight;
        public static List<JointInfo> allJoints;

        public Vector3 position;
        public Joint type;
        public String name;

        static JointInfo()
        {
            allJoints = new List<JointInfo>();
            allJoints.Add(AnkleLeft);
            allJoints.Add(AnkleRight);
            allJoints.Add(ElbowLeft);
            allJoints.Add(ElbowRight);
            allJoints.Add(FootLeft);
            allJoints.Add(FootRight);
            allJoints.Add(HandLeft);
            allJoints.Add(HandRight);
            allJoints.Add(Head);
            allJoints.Add(HipCenter);
            allJoints.Add(HipLeft);
            allJoints.Add(HipRight);
            allJoints.Add(KneeLeft);
            allJoints.Add(KneeRight);
            allJoints.Add(ShoulderCenter);
            allJoints.Add(ShoulderLeft);
            allJoints.Add(ShoulderRight);
            allJoints.Add(Spine);
            allJoints.Add(WristLeft);
            allJoints.Add(WristRight);
        }

        public static void Update(Joint joint)
        {
            switch (joint.JointType)
            {
                case JointType.AnkleLeft:
                    if(AnkleLeft == null)
                    {
                        AnkleLeft = new JointInfo(joint);
                        ListUpdate(0, AnkleLeft);
                    }
                    else
                    {
                        AnkleLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.AnkleRight:
                    if (AnkleRight == null)
                    {
                        AnkleRight = new JointInfo(joint);
                        ListUpdate(1, AnkleRight);
                    }
                    else
                    {
                        AnkleRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.ElbowLeft:
                    if (ElbowLeft == null)
                    {
                        ElbowLeft = new JointInfo(joint);
                        ListUpdate(2, ElbowLeft);
                    }
                    else
                    {
                        ElbowLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.ElbowRight:
                    if (ElbowRight == null)
                    {
                        ElbowRight = new JointInfo(joint);
                        ListUpdate(3, ElbowRight);
                    }
                    else
                    {
                        ElbowRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.FootLeft:
                    if (FootLeft == null)
                    {
                        FootLeft = new JointInfo(joint);
                        ListUpdate(4, FootLeft);
                    }
                    else
                    {
                        FootLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.FootRight:
                    if (FootRight == null)
                    {
                        FootRight = new JointInfo(joint);
                        ListUpdate(5, FootRight);
                    }
                    else
                    {
                       FootRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.HandLeft:
                    if (HandLeft == null)
                    {
                        HandLeft = new JointInfo(joint);
                        ListUpdate(6, HandLeft);
                    }
                    else
                    {
                        HandLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.HandRight:
                    if (HandRight == null)
                    {
                        HandRight = new JointInfo(joint);
                        ListUpdate(7, HandRight);
                    }
                    else
                    {
                        HandRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.Head:
                    if (Head == null)
                    {
                        Head = new JointInfo(joint);
                        ListUpdate(8, Head);
                    }
                    else
                    {
                        Head.position = new Vector3(joint);
                    }
                    break;
                case JointType.HipCenter:
                    if (HipCenter == null)
                    {
                        HipCenter = new JointInfo(joint);
                        ListUpdate(9, HipCenter);
                    }
                    else
                    {
                        HipCenter.position = new Vector3(joint);
                    }
                    break;
                case JointType.HipLeft:
                    if (HipLeft == null)
                    {
                        HipLeft = new JointInfo(joint);
                        ListUpdate(10, HipLeft);
                    }
                    else
                    {
                        HipLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.HipRight:
                    if (HipRight == null)
                    {
                        HipRight = new JointInfo(joint);
                        ListUpdate(11, HipRight);
                    }
                    else
                    {
                        HipRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.KneeLeft:
                    if (KneeLeft == null)
                    {
                        KneeLeft = new JointInfo(joint);
                        ListUpdate(12, KneeLeft);
                    }
                    else
                    {
                        KneeLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.KneeRight:
                    if (KneeRight == null)
                    {
                        KneeRight = new JointInfo(joint);
                        ListUpdate(13, KneeRight);
                    }
                    else
                    {
                        KneeRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.ShoulderCenter:
                    if (ShoulderCenter == null)
                    {
                        ShoulderCenter = new JointInfo(joint);
                        ListUpdate(14, ShoulderCenter);
                    }
                    else
                    {
                        ShoulderCenter.position = new Vector3(joint);
                    }
                    break;
                case JointType.ShoulderLeft:
                    if (ShoulderLeft == null)
                    {
                        ShoulderLeft = new JointInfo(joint);
                        ListUpdate(15, ShoulderLeft);
                    }
                    else
                    {
                        ShoulderLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.ShoulderRight:
                    if (ShoulderRight == null)
                    {
                        ShoulderRight = new JointInfo(joint);
                        ListUpdate(16, ShoulderRight);
                    }
                    else
                    {
                        ShoulderRight.position = new Vector3(joint);
                    }
                    break;
                case JointType.Spine:
                    if (Spine == null)
                    {
                        Spine = new JointInfo(joint);
                        ListUpdate(17, Spine);
                    }
                    else
                    {
                        Spine.position = new Vector3(joint);
                    }
                    break;
                case JointType.WristLeft:
                    if (WristLeft == null)
                    {
                        WristLeft = new JointInfo(joint);
                        ListUpdate(18, WristLeft);
                    }
                    else
                    {
                        WristLeft.position = new Vector3(joint);
                    }
                    break;
                case JointType.WristRight:
                    if (WristRight == null)
                    {
                        WristRight = new JointInfo(joint);
                        ListUpdate(19, WristRight);
                    }
                    else
                    {
                        WristRight.position = new Vector3(joint);
                    }
                    break;
                default:
                    Console.WriteLine("How did you get here?");
                    break;
            }
        }

        private static void ListUpdate(int index, JointInfo joint)
        {
            allJoints[index] = joint;
        }

        private JointInfo(Joint type)
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
