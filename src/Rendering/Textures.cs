using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using System.Drawing;

namespace _3D2048.Rendering
{
    class Textures
    {
        String texturePath = "textures/base.bmp";
        OpenGL gl;
        Bitmap baseBitmap;

        public Textures(OpenGL gl)
        {
            this.gl = gl;
            this.baseBitmap = new Bitmap(texturePath);
        }

        public Texture get(int number)
        {
            Texture t = new Texture();
            t.Create(this.gl, this.baseBitmap);
            return t;
        }
    }
}
