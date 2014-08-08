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
        private bool moveTriggered = false;
        private int trackingId = 0;

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

                foreach (Skeleton skel in skeletons)
                {
                    if (skel.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        workingSkeleton = skel;
                        trackingId = 1;
                        skel.TrackingId = trackingId;
                    }
                }

                Vector3D rightHand = convertSkeletonPoint(workingSkeleton.Joints[JointType.HandRight].Position);
                Vector3D rightShoulder = convertSkeletonPoint(workingSkeleton.Joints[JointType.ShoulderRight].Position);
                Vector3D leftHand = convertSkeletonPoint(workingSkeleton.Joints[JointType.HandLeft].Position);
                Vector3D leftShoulder = convertSkeletonPoint(workingSkeleton.Joints[JointType.ShoulderLeft].Position);
                float triggerDistance = (rightShoulder - convertSkeletonPoint(workingSkeleton.Joints[JointType.ShoulderLeft].Position)).Length;
                Vector3D handShoulderVector = rightHand - rightShoulder;
                
                if (watchMovement)
                {

                    // Pausing
                    if (leftHand.y > leftShoulder.y + (triggerDistance / 2))
                    {
                        Console.WriteLine("Pausing " + (triggerDistance / 8).ToString());
                        watchMovement = false;
                        logic.pause();
                        return;
                    }

                    if (rightHand.x > rightShoulder.x + (triggerDistance / 2) && !moveTriggered) // Right movement
                    {
                        Console.WriteLine("EXEC right");
                        logic.Move(logic.getMoveDependentDirection(Direction.Right, cam));
                        moveTriggered = true;
                    }
                    else if (rightHand.x < rightShoulder.x - (triggerDistance) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC left");
                        logic.Move(logic.getMoveDependentDirection(Direction.Left, cam));
                        moveTriggered = true;
                    }
                    else if (rightHand.y > rightShoulder.y + (triggerDistance / 1.5) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC up");
                        logic.Move(logic.getMoveDependentDirection(Direction.Up, cam));
                        moveTriggered = true;
                    }
                    else if (rightHand.y < rightShoulder.y - triggerDistance && !moveTriggered)
                    {
                        Console.WriteLine("EXEC down");
                        logic.Move(logic.getMoveDependentDirection(Direction.Down, cam));
                        moveTriggered = true;
                    }
                    else if (rightHand.z < rightShoulder.z - (triggerDistance * 1.5) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC back");
                        logic.Move(logic.getMoveDependentDirection(Direction.Back, cam));
                        moveTriggered = true;
                    }
                    else if (rightHand.z > rightShoulder.z - (triggerDistance / 1.5) && !moveTriggered)
                    {
                        Console.WriteLine("EXEC fwd");
                        logic.Move(logic.getMoveDependentDirection(Direction.Forward, cam));
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

                    // Left hand: Rotate
                    if (leftHand.x < leftShoulder.x - (triggerDistance))
                    {
                        Vector3D vect = new Vector3D(0, -2,0);
                        cam.cubeRotation += vect;
                    }
                    else if (leftHand.x > leftShoulder.x + (triggerDistance))
                    {
                        Vector3D vect = new Vector3D(0, 2, 0);
                        cam.cubeRotation += vect;
                    }
                    
                }
                else
                {
                    if (rightHand.y > rightShoulder.y + (triggerDistance / 2))
                    {
                        Console.WriteLine("watch movement");
                        watchMovement = true;
                        moveTriggered = true;
                        logic.resume();
                        logic.gameModel.started = true;
                        System.Threading.Thread.Sleep(100);
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
