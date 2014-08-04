using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Util
{
    class Cuboid
    {
        public Vector3D origin;
        public float width;
        public float height;
        public float length;

        public Cuboid(Vector3D origin, float width, float height, float length)
        {
            this.origin = origin;
            this.width = width;
            this.height = height;
            this.length = length;
        }

        public Vector3D[] getCorners()
        {
            Vector3D[] corners = new Vector3D[8];
            corners[0] = origin;
            corners[1] = origin + new Vector3D(0, height, 0);
            corners[2] = origin + new Vector3D(width, height, 0);
            corners[3] = origin + new Vector3D(0, 0, width);
            corners[4] = origin + new Vector3D(0, 0, length);
            corners[5] = origin + new Vector3D(0, height, length);
            corners[6] = origin + new Vector3D(width, height, length);
            corners[7] = origin + new Vector3D(width, 0, length);
            return corners;
        }
    }
}
