using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Microsoft.Kinect;
using _3D2048.Logic;

namespace _3D2048.Util
{
    class KinectInput
    {

        private KinectSensor sensor;
        private GameLogic logic;
        private Camera cam;
        private bool watchMovement = false;
        private bool moveRight = false;
        private bool moveLeft = false;
        private bool moveUp = false;
        private bool moveDown = false;
        private bool moveForward = false;
        private bool moveBack = false;
        private bool moveTriggered = false;

        public KinectInput(GameLogic logic, Camera cam)
        {
            this.logic = logic;
            this.cam = cam;
            KinectStart();
        }

        public void KinectStart()
        {

            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (KinectSensor potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (this.sensor != null)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

        }

        /// <summary>
        /// Event handler for Kinect sensor's SkeletonFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons.Length > 0)
            {
                Skeleton workingSkeleton = skeletons[0];
                Vector3D rightHand = convertSkeletonPoint(workingSkeleton.Joints[JointType.HandRight].Position);
                Vector3D rightShoulder = convertSkeletonPoint(workingSkeleton.Joints[JointType.ShoulderRight].Position);
                float triggerDistance = (rightShoulder - convertSkeletonPoint(workingSkeleton.Joints[JointType.ShoulderLeft].Position)).Length;
                Vector3D handShoulderVector = rightHand - rightShoulder;
                
                if (watchMovement)
                {

                    if (rightHand.x > rightShoulder.x + (triggerDistance / 2) && !moveTriggered) // Right movement
                    {
                        Console.WriteLine("EXEC right");
                        logic.Move(Direction.Right);
                        moveTriggered = true;
                    }
                    else if (rightHand.x < rightShoulder.x - (triggerDistance) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC left");
                        logic.Move(Direction.Left);
                        moveTriggered = true;
                    }
                    else if (rightHand.y > rightShoulder.y + (triggerDistance / 1.5) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC up");
                        logic.Move(Direction.Up);
                        moveTriggered = true;
                    }
                    else if (rightHand.y < rightShoulder.y - triggerDistance && !moveTriggered)
                    {
                        Console.WriteLine("EXEC down");
                        logic.Move(Direction.Down);
                        moveTriggered = true;
                    }
                    else if (rightHand.z < rightShoulder.z - (triggerDistance * 1.5) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC back");
                        logic.Move(Direction.Back);
                        moveTriggered = true;
                    }
                    else if (rightHand.z > rightShoulder.z - (triggerDistance / 1.5) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC fwd");
                        logic.Move(Direction.Forward);
                        moveTriggered = true;
                    }
                    else if ((rightHand.x < rightShoulder.x + (triggerDistance / 1.9)) &&
                       (rightHand.x > rightShoulder.x - (triggerDistance / 1.5)) &&
                        (rightHand.y < rightShoulder.y + (triggerDistance / 1.5)) &&
                        (rightHand.y > rightShoulder.y - (triggerDistance / 1.5)) &&
                        (rightHand.z > rightShoulder.z - (triggerDistance * 1.3)) &&
                        (rightHand.z < rightShoulder.z - (triggerDistance / 1.3)))
                    {
                        Console.WriteLine("RESET " + rightHand.x.ToString() + "|" + rightShoulder.x.ToString());
                        moveTriggered = false;
                    }

                    return;
                    if (rightHand.x > rightShoulder.x && handShoulderVector.y < handShoulderVector.x && handShoulderVector.Length < triggerDistance && moveRight)
                    {
                        Console.WriteLine("kinect move right exec");
                        logic.Move(logic.getMoveDependentDirection(Direction.Right, cam));
                        moveRight = false;
                    }
                    else if (rightHand.x > rightShoulder.x && handShoulderVector.y < handShoulderVector.x && handShoulderVector.Length > triggerDistance)
                    {
                        Console.WriteLine("kinect move right init");
                        moveRight = true;
                    }
                    else if (rightHand.x < rightShoulder.x && handShoulderVector.y < handShoulderVector.x && handShoulderVector.Length < triggerDistance && moveLeft)
                    {
                        Console.WriteLine("kinect move left exec");
                        logic.Move(logic.getMoveDependentDirection(Direction.Left, cam));
                        moveLeft = false;
                    }
                    else if (rightHand.x < rightShoulder.x && handShoulderVector.y < handShoulderVector.x && handShoulderVector.Length > triggerDistance)
                    {
                        Console.WriteLine("kinect move left init");
                        moveLeft = true;
                    }
                    else if (rightHand.y > rightShoulder.y && handShoulderVector.y > handShoulderVector.x && handShoulderVector.Length < triggerDistance && moveUp)
                    {
                        Console.WriteLine("kinect move up exec");
                        logic.Move(logic.getMoveDependentDirection(Direction.Up, cam));
                        moveUp = false;
                    }
                    else if (rightHand.y > rightShoulder.y && handShoulderVector.y > handShoulderVector.x && handShoulderVector.Length > triggerDistance)
                    {
                        Console.WriteLine("kinect move up init");
                        moveUp = true;
                    }
                    else if (rightHand.y < rightShoulder.y && handShoulderVector.y > handShoulderVector.x && handShoulderVector.Length < triggerDistance && moveDown)
                    {
                        Console.WriteLine("kinect move down exec");
                        logic.Move(logic.getMoveDependentDirection(Direction.Down, cam));
                        moveDown = false;
                    }
                    else if (rightHand.y < rightShoulder.y && handShoulderVector.y > handShoulderVector.x && handShoulderVector.Length > triggerDistance)
                    {
                        Console.WriteLine("kinect move down init");
                        moveDown = true;
                    }
                }
                else
                {
                    if (rightHand.y > rightShoulder.y && handShoulderVector.Length > triggerDistance)
                    {
                        Console.WriteLine("watch movement");
                        watchMovement = true;
                    }
                }

            }
        }

        private Vector3D convertSkeletonPoint(SkeletonPoint point)
        {
            return new Vector3D(point.X, point.Y, point.Z);
        }



    }
}
