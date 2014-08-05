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
        private _3D2048.Logic.GameLogic gameLogic;
        private Renderer.Renderer renderer;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new Logic.GameLogic();


            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            //texture.Create(gl, "texture_2.");#

            renderer = new Renderer.Renderer(gl);
    
        }

        public void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            renderer.draw(camera);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    gameLogic.Move(_3D2048.Logic.Direction.Up);
                    break;
                case Keys.Down:
                    gameLogic.Move(_3D2048.Logic.Direction.Down);
                    break;
                case Keys.Left:
                    gameLogic.Move(_3D2048.Logic.Direction.Left);
                    break;
                case Keys.Right:
                    gameLogic.Move(_3D2048.Logic.Direction.Right);
                    break;
                case Keys.PageUp:
                    gameLogic.Move(_3D2048.Logic.Direction.Forward);
                    break;
                case Keys.PageDown:
                    gameLogic.Move(_3D2048.Logic.Direction.Back);
                    break;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
