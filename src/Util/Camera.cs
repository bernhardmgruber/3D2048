using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Util
{
    class Camera
    {
        public Vector3D cubeRotation
        {
            get;
            set;
        }
        public float zoom
        {
            get;
            private set;
        }

        public Camera()
        {
            cubeRotation = new Vector3D(0, 0, 0);
            zoom = 0;
        }
    }
}
