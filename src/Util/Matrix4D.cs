using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Util
{
    class Matrix4D
    {
        private float[,] m = new float[4, 4];

        public float this[int col, int row]
        {
            get
            {
                return m[col, row];
            }
            set
            {
                m[col, row] = value;
            }
        }

        public float[] toArray()
        {
            float[] result = new float[16];
            for (int c = 0; c < 4; c++)
                for (int r = 0; r < 4; r++)
                    result[c * 4 + r] = m[c, r];
            return result;
        }

        public static Matrix4D operator *(Matrix4D a, Matrix4D b)
        {
            Matrix4D r = new Matrix4D();

            r[0, 0] = a[0, 0] * b[0, 0] + a[1, 0] * b[0, 1] + a[2, 0] * b[0, 2] + a[3, 0] * b[0, 3];
            r[0, 1] = a[0, 1] * b[0, 0] + a[1, 1] * b[0, 1] + a[2, 1] * b[0, 2] + a[3, 1] * b[0, 3];
            r[0, 2] = a[0, 2] * b[0, 0] + a[1, 2] * b[0, 1] + a[2, 2] * b[0, 2] + a[3, 2] * b[0, 3];
            r[0, 3] = a[0, 3] * b[0, 0] + a[1, 3] * b[0, 1] + a[2, 3] * b[0, 2] + a[3, 3] * b[0, 3];

            r[1, 0] = a[0, 0] * b[1, 0] + a[1, 0] * b[1, 1] + a[2, 0] * b[1, 2] + a[3, 0] * b[1, 3];
            r[1, 1] = a[0, 1] * b[1, 0] + a[1, 1] * b[1, 1] + a[2, 1] * b[1, 2] + a[3, 1] * b[1, 3];
            r[1, 2] = a[0, 2] * b[1, 0] + a[1, 2] * b[1, 1] + a[2, 2] * b[1, 2] + a[3, 2] * b[1, 3];
            r[1, 3] = a[0, 3] * b[1, 0] + a[1, 3] * b[1, 1] + a[2, 3] * b[1, 2] + a[3, 3] * b[1, 3];

            r[2, 0] = a[0, 0] * b[2, 0] + a[1, 0] * b[2, 1] + a[2, 0] * b[2, 2] + a[3, 0] * b[2, 3];
            r[2, 1] = a[0, 1] * b[2, 0] + a[1, 1] * b[2, 1] + a[2, 1] * b[2, 2] + a[3, 1] * b[2, 3];
            r[2, 2] = a[0, 2] * b[2, 0] + a[1, 2] * b[2, 1] + a[2, 2] * b[2, 2] + a[3, 2] * b[2, 3];
            r[2, 3] = a[0, 3] * b[2, 0] + a[1, 3] * b[2, 1] + a[2, 3] * b[2, 2] + a[3, 3] * b[2, 3];

            r[3, 0] = a[0, 0] * b[3, 0] + a[1, 0] * b[3, 1] + a[2, 0] * b[3, 2] + a[3, 0] * b[3, 3];
            r[3, 1] = a[0, 1] * b[3, 0] + a[1, 1] * b[3, 1] + a[2, 1] * b[3, 2] + a[3, 1] * b[3, 3];
            r[3, 2] = a[0, 2] * b[3, 0] + a[1, 2] * b[3, 1] + a[2, 2] * b[3, 2] + a[3, 2] * b[3, 3];
            r[3, 3] = a[0, 3] * b[3, 0] + a[1, 3] * b[3, 1] + a[2, 3] * b[3, 2] + a[3, 3] * b[3, 3];

            return r;
        }

        public static Matrix4D Identity()
        {
            Matrix4D r = new Matrix4D();
            for (int i = 0; i < 4; i++)
                r[i, i] = 1;
            return r;
        }

        public static Matrix4D Translate(Vector3D v)
        {
            Matrix4D r = Identity();
            r[3, 0] = v.x;
            r[3, 1] = v.y;
            r[3, 2] = v.z;
            return r;
        }

        public static Matrix4D RotateX(float angle)
        {
            float s = (float)Math.Sin((float)angle);
            float c = (float)Math.Cos((float)angle);
            Matrix4D r = Identity();
            r[1, 1] = c;
            r[1, 2] = -s;
            r[2, 1] = s;
            r[2, 2] = c;
            return r;
        }

        public static Matrix4D RotateY(float angle)
        {
            float s = (float)Math.Sin((float)angle);
            float c = (float)Math.Cos((float)angle);
            Matrix4D r = Identity();
            r[0, 0] = c;
            r[0, 2] = s;
            r[2, 0] = -s;
            r[2, 2] = c;
            return r;
        }

        public static Matrix4D RotateZ(float angle)
        {
            float s = (float)Math.Sin((float)angle);
            float c = (float)Math.Cos((float)angle);
            Matrix4D r = Identity();
            r[0, 0] = c;
            r[0, 1] = -s;
            r[1, 0] = s;
            r[1, 1] = c;
            return r;
        }
    }
}
