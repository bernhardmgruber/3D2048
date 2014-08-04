using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace _3D2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -6.0f);

            //gl.Rotate(rtri, 0.0f, 1.0f, 0.0f);

            //  Bind the texture.
            //texture.Bind(gl);

            gl.Begin(OpenGL.GL_QUADS);

            // Front Face
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 1.0f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 1.0f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, 1.0f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, 1.0f);	// Top Left Of The Texture and Quad

            // Back Face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, -1.0f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, -1.0f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(1.0f, 1.0f, -1.0f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(1.0f, -1.0f, -1.0f);	// Bottom Left Of The Texture and Quad

            // Top Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, -1.0f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, 1.0f, 1.0f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, 1.0f, 1.0f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, -1.0f);	// Top Right Of The Texture and Quad

            // Bottom Face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-1.0f, -1.0f, -1.0f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(1.0f, -1.0f, -1.0f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 1.0f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 1.0f);	// Bottom Right Of The Texture and Quad

            // Right face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, -1.0f, -1.0f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 1.0f, -1.0f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(1.0f, 1.0f, 1.0f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(1.0f, -1.0f, 1.0f);	// Bottom Left Of The Texture and Quad

            // Left Face
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, -1.0f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-1.0f, -1.0f, 1.0f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, 1.0f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-1.0f, 1.0f, -1.0f);	// Top Left Of The Texture and Quad
            gl.End();

            gl.Flush();

            //rtri += 1.0f;// 0.2f;						// Increase The Rotation Variable For The Triangle 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Left:
                    break;
                case Keys.Right:
                    break;
                case Keys.PageUp:
                    break;
                case Keys.PageDown:
                    break;
                default:
                    break;
            }
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
