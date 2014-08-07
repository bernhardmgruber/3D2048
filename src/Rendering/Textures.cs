using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _3D2048.Rendering
{
    class Textures
    {
        String texturePath = "textures/base.bmp";
        OpenGL gl;
        Bitmap baseBitmap;
        Dictionary<int, Texture> cachedTextures;

        public Textures(OpenGL gl)
        {
            cachedTextures = new Dictionary<int, Texture>();
            this.gl = gl;
            this.baseBitmap = new Bitmap(texturePath);
        }

        public Texture get(int number)
        {
            if (cachedTextures.ContainsKey(number))
            {
                return cachedTextures[number];
            }
            else
            {
                Texture t = createTexture(number);
                cachedTextures.Add(number, t);
                return t;
            }
        }

        public Texture createTexture(int number)
        {
            Bitmap b = (Bitmap)this.baseBitmap.Clone();
            Graphics g = Graphics.FromImage(b);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            RectangleF rect = new RectangleF(0, 0, b.Width, b.Height);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(number.ToString(), new Font("Courier New", (int)(0.3 * b.Width)), Brushes.Black, rect, sf);
            g.Flush();
            Texture t = new Texture();
            t.Create(this.gl, b);
            return t;
        }
    }
}
