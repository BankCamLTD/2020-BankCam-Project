using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;



// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace BankApp
{
    public partial class Form1 : Form
    {
            
        static KinectSensor sensor = KinectSensor.KinectSensors[0];

        PictureBox pictureBox1;
        PictureBox pictureBox3;
        List<Label> jointLabels;
        bool alarm = false;


        public Form1()
        {

            InitializeComponent();
            jointLabels = new List<Label>();
            jointLabels.Add(label1);
            jointLabels.Add(label2);
            jointLabels.Add(label3);
            jointLabels.Add(label4);
            jointLabels.Add(label5);
            jointLabels.Add(label6);
            jointLabels.Add(label7);
            jointLabels.Add(label8);
            jointLabels.Add(label9);
            jointLabels.Add(label10);
            jointLabels.Add(label11);
            jointLabels.Add(label12);
            jointLabels.Add(label13);
            jointLabels.Add(label14);
            jointLabels.Add(label15);
            jointLabels.Add(label16);
            jointLabels.Add(label17);
            jointLabels.Add(label18);
            jointLabels.Add(label19);
            jointLabels.Add(label20);
            pictureBox1.Controls.Add(pictureBox3);
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.BackColor = Color.Transparent;
            sensor.AllFramesReady += FramesReady;

        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            sensor.SkeletonStream.Enable();

            sensor.AllFramesReady += FramesReady;
            sensor.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sensor.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sensor.ElevationAngle < sensor.MaxElevationAngle-4)
            {
                sensor.ElevationAngle += 4;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(sensor.ElevationAngle > sensor.MinElevationAngle+4)
            {
                sensor.ElevationAngle -= 4;
            }
           
        }

        void FramesReady(object sender, AllFramesReadyEventArgs e)
        {
            ColorImageFrame VFrame = e.OpenColorImageFrame();
            if (VFrame == null) return;
            byte[] pixelS = new byte[VFrame.PixelDataLength];
            Bitmap bmap = ImageToBitmap(VFrame);


            SkeletonFrame SFrame = e.OpenSkeletonFrame();
            if (SFrame == null) return;

            Graphics g = Graphics.FromImage(bmap);
            Skeleton[] Skeletons = new Skeleton[SFrame.SkeletonArrayLength];
            SFrame.CopySkeletonDataTo(Skeletons);

            foreach (Skeleton S in Skeletons)
            {
                //List<JointInfo> jointInfos = new List<JointInfo>();
                if (S.TrackingState == SkeletonTrackingState.Tracked)
                {
                    foreach(JointType j in Enum.GetValues(typeof(JointType)))
                    {
                        JointInfo.Update(S.Joints[j]);
                        //jointInfos.Add(new JointInfo(S.Joints[j]));
                    }
                    for(int i = 0; i < 20; i++)
                    {
                        if(JointInfo.allJoints[i] != null)
                        {
                            jointLabels[i].Text = JointInfo.allJoints[i].ToString();
                        }
                        else
                        {
                            jointLabels[i].Text = " ";
                        }
                    }  
                   foreach(JointInfo j in JointInfo.allJoints)
                   {
                        if (j != null)
                        {
                            MarkAtxy(j.position, Brushes.Blue, g);
                           
                        }  

                   }
                   //Testing required coords
                 /* Debug.Print(JointInfo.HandLeft.position.y +
                      " : " + JointInfo.HandRight.position.y + 
                        " : " + JointInfo.Head.position.y);
                        */
                    //Check for the relevant pose
                   if((JointInfo.HandRight.position.y) > JointInfo.Head.position.y && (JointInfo.HandLeft.position.y)> JointInfo.Head.position.y)
                   {
                        bool alarm = true;
                        Debug.Print("Alarm");

                        if(alarm == true)
                        {
                            //Play Alarm on detecting hands above head
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\ciara\Source\Repos\2020-BankCam-Project\sound99.wav");
                            player.PlayLooping();
                        }
                   }
                
                    //body
                    DrawBone(JointType.Head, JointType.ShoulderCenter, S, g);
                    DrawBone(JointType.ShoulderCenter, JointType.Spine, S, g);
                    DrawBone(JointType.Spine, JointType.HipCenter, S, g);
                    //left leg
                    DrawBone(JointType.HipCenter, JointType.HipLeft, S, g);
                    DrawBone(JointType.HipLeft, JointType.KneeLeft, S, g);
                    DrawBone(JointType.KneeLeft, JointType.AnkleLeft, S, g);
                    DrawBone(JointType.AnkleLeft, JointType.FootLeft, S, g);
                    //Right Leg
                    DrawBone(JointType.HipCenter, JointType.HipRight, S, g);
                    DrawBone(JointType.HipRight, JointType.KneeRight, S, g);
                    DrawBone(JointType.KneeRight, JointType.AnkleRight, S, g);
                    DrawBone(JointType.AnkleRight, JointType.FootRight, S, g);
                    //Left Arm
                    DrawBone(JointType.ShoulderCenter, JointType.ShoulderLeft, S, g);
                    DrawBone(JointType.ShoulderLeft, JointType.ElbowLeft, S, g);
                    DrawBone(JointType.ElbowLeft, JointType.WristLeft, S, g);
                    DrawBone(JointType.WristLeft, JointType.HandLeft, S, g);
                    //Right Arm
                    DrawBone(JointType.ShoulderCenter, JointType.ShoulderRight, S, g);
                    DrawBone(JointType.ShoulderRight, JointType.ElbowRight, S, g);
                    DrawBone(JointType.ElbowRight, JointType.WristRight, S, g);
                    DrawBone(JointType.WristRight, JointType.HandRight, S, g);

                }



            }
            
           
            pictureBox1.Image = bmap;
            SFrame.Dispose();
            VFrame.Dispose();
        }

    

        void DrawBone(JointType j1, JointType j2, Skeleton S, Graphics g)
        {
            Point p1 = GetJoint(j1, S);
            Point p2 = GetJoint(j2, S);
            g.DrawLine(Pens.Red, p1, p2);
        }

        Point GetJoint(JointType j, Skeleton S)
        {
            SkeletonPoint Sloc = S.Joints[j].Position;
            ColorImagePoint Cloc = sensor.MapSkeletonPointToColor(Sloc, ColorImageFormat.RgbResolution640x480Fps30);

            return new Point(Cloc.X, Cloc.Y);
        }

        void FrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
           

            ColorImageFrame imageFrame = e.OpenColorImageFrame();
            if (imageFrame != null)
            {
                Bitmap bmap = ImageToBitmap(imageFrame);
                pictureBox1.Image = bmap;
                imageFrame.Dispose();
            }
        }


        void MarkAtxy(Vector3 position, Brush brush, Graphics g)
        {
            Pen pen = new Pen(brush);
            g.DrawLine(pen, new Point(position.xMax(640), position.yMax(480) - 10), new Point(position.xMax(640), position.yMax(480) + 10));
            g.DrawLine(pen, new Point(position.xMax(640) - 10, position.yMax(480)), new Point(position.xMax(640) + 10, position.yMax(480)));
        }


        Bitmap ImageToBitmap(
                   ColorImageFrame Image)
        {
            byte[] pixeldata =
                     new byte[Image.PixelDataLength];
            Image.CopyPixelDataTo(pixeldata);
            Bitmap bmap = new Bitmap(
                   Image.Width,
                   Image.Height,
                   PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(
              new Rectangle(0, 0,
                         Image.Width, Image.Height),
              ImageLockMode.WriteOnly,
              bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixeldata, 0, ptr,
                       Image.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        public void Stop()
        {
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

    }
}
