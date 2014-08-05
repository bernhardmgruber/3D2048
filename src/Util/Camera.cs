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

        public CubeFace getFrontFace()
        {
            if (cubeRotation.y > 315 || cubeRotation.y <= 45)
            {
                return CubeFace.FRONT;
            }
            else if (cubeRotation.y > 45 && cubeRotation.y <= 135)
            {
                return CubeFace.RIGHT;
            }
            else if (cubeRotation.y > 135 && cubeRotation.y <= 225)
            {
                return CubeFace.BACK;
            }
            else if (cubeRotation.y > 225 && cubeRotation.y <= 315)
            {
                return CubeFace.LEFT;
            }
            else return CubeFace.FRONT;
        }


    }

    enum CubeFace
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT,
        TOP,
        BOTTOM
    }
}
