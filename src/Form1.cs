using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3D2048.Util;
using _3D2048.Rendering;

using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace _3D2048
{
    public partial class Form1 : Form
    {
        private _3D2048.Logic.GameLogic gameLogic;

        private Renderer renderer;

        private bool mouseIsMoving;
        private Vector3D lastMousePosition;
        private Camera gameCamera;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new Logic.GameLogic();
            mouseIsMoving = false;
            lastMousePosition = new Vector3D(0, 0, 0);
            gameCamera = new Camera();


            initOpenGL();
    
        }

        private void initOpenGL()
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            //texture.Create(gl, "texture_2.");#

            renderer = new Renderer(gl);
        }

        public void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            renderer.draw(gameCamera);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsMoving = true;
            lastMousePosition = new Vector3D(e.X, e.Y, 0);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Vector3D deltaMove = new Vector3D(lastMousePosition.x - e.X, lastMousePosition.y - e.Y, 0);
            gameCamera.cubeRotation += deltaMove;
            lastMousePosition = new Vector3D(e.X, e.Y, 0);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsMoving = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
