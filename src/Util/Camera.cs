using _3D2048.Logic;
using _3D2048.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Util
{
    class Camera
    {

        public const double fieldOfView = 45;

        public Vector3D cubeRotation
        {
            get;
            set;
        }
        public float zoom
        {
            get;
            set;
        }

        public Camera()
        {
            cubeRotation = new Vector3D(10, 0, 0);
            zoom = -GameState.size*1.85f;
        }

        public CubeFace getFrontFace()
        {
            Vector3D frontVec = new Vector3D(0, 0, 1);

            // create camera rotation matrix
            Matrix4D mv = Matrix4D.Identity();
            mv = mv * Matrix4D.RotateX(Renderer.toRadians(cubeRotation.x)); // FIXME: move toRadians out of renderer
            mv = mv * Matrix4D.RotateY(Renderer.toRadians(cubeRotation.y));
            mv = mv * Matrix4D.RotateZ(Renderer.toRadians(cubeRotation.z));

            frontVec = mv * frontVec;

            // find component with largest magnitude
            if (Math.Abs(frontVec.x) > Math.Abs(frontVec.y))
            {
                if (Math.Abs(frontVec.x) > Math.Abs(frontVec.z))
                {
                    // x
                    if (frontVec.x > 0)
                        return CubeFace.RIGHT;
                    else
                        return CubeFace.LEFT;
                }
                else
                {
                    // z
                    if (frontVec.z > 0)
                        return CubeFace.FRONT;
                    else
                        return CubeFace.BACK;
                }
            }
            else
            {
                if (Math.Abs(frontVec.y) > Math.Abs(frontVec.z))
                {
                    // y
                    if (frontVec.y > 0)
                        return CubeFace.TOP;
                    else
                        return CubeFace.BOTTOM;
                }
                else
                {
                    // z
                    if (frontVec.z > 0)
                        return CubeFace.FRONT;
                    else
                        return CubeFace.BACK;
                }
            }

            //while (cubeRotation.y < 0)
            //{
            //	cubeRotation.y = 360 + cubeRotation.y;
            //}
            //if (cubeRotation.y > 315 || cubeRotation.y <= 45)
            //{
            //	return CubeFace.FRONT;
            //}
            //else if (cubeRotation.y > 45 && cubeRotation.y <= 135)
            //{
            //	return CubeFace.LEFT;
            //}
            //else if (cubeRotation.y > 135 && cubeRotation.y <= 225)
            //{
            //	return CubeFace.BACK;
            //}
            //else if (cubeRotation.y > 225 && cubeRotation.y <= 315)
            //{
            //	return CubeFace.RIGHT;
            //}
            //else return CubeFace.FRONT;
        }
        public void resetCamera()
        {
            cubeRotation = new Vector3D(0.0f, 0.0f, 0.0f);
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
