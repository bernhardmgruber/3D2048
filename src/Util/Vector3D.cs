using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Util
{
    class Vector3D
    {
        public float x;
        public float y;
        public float z;

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            }
        }

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void moveRelative(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }


        public static Vector3D operator+(Vector3D vec1, Vector3D vec2)
        {
            return new Vector3D(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
        }

        public static Vector3D operator -(Vector3D vec1, Vector3D vec2)
        {
            return new Vector3D(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
        }

    }
}
