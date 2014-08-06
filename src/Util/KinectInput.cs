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
                Joint rightHand = workingSkeleton.Joints[JointType.HandRight];
                Joint rightShoulder = workingSkeleton.Joints[JointType.ShoulderRight];
                float triggerDistance = workingSkeleton.Joints[JointType.ShoulderRight].Position.X - workingSkeleton.Joints[JointType.ShoulderLeft].Position.X;
                if (watchMovement)
                {
                    if (rightHand.Position.X > rightShoulder.Position.X && (convertSkeletonPoint(rightHand.Position) - convertSkeletonPoint(rightShoulder.Position)).Length > triggerDistance)
                    {
                        logic.Move(logic.getMoveDependentDirection(Direction.Right, cam));
                    }
                    else if (rightHand.Position.X < rightShoulder.Position.X && (convertSkeletonPoint(rightHand.Position) - convertSkeletonPoint(rightShoulder.Position)).Length > triggerDistance)
                    {
                        logic.Move(logic.getMoveDependentDirection(Direction.Left, cam));
                    }
                }
                else
                {
                    if (rightHand.Position.Y > rightShoulder.Position.Y && (convertSkeletonPoint(rightHand.Position) - convertSkeletonPoint(rightShoulder.Position)).Length > triggerDistance)
                    {
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
