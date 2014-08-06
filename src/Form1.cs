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
using _3D2048.Logic;


using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace _3D2048
{
    public partial class Form1 : Form
    {
        const float MOTION_SENSITIVITY = 0.5f;

        private _3D2048.Logic.GameLogic gameLogic;

        private Renderer renderer;

        private bool mouseIsMoving;
        private Vector3D lastMousePosition;
        private Camera gameCamera;
        private KinectInput kinect;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new Logic.GameLogic();
            gameCamera = new Camera();

            kinect = new KinectInput(gameLogic, gameCamera);

            mouseIsMoving = false;
            lastMousePosition = new Vector3D(0, 0, 0);


            initOpenGL();
    
        }

        private void initOpenGL()
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            renderer = new Renderer(gl);
        }

        public void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            renderer.draw(gameCamera,gameLogic.gameModel);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsMoving = true;
            lastMousePosition = new Vector3D(e.X, e.Y, 0);
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsMoving)
            {
                float dy = (e.Y - lastMousePosition.y) * MOTION_SENSITIVITY;
                float dx = (e.X - lastMousePosition.x) * MOTION_SENSITIVITY;
                Vector3D deltaMove = new Vector3D(dy, dx, 0);
                gameCamera.cubeRotation += deltaMove;
                lastMousePosition = new Vector3D(e.X, e.Y, 0);
            }
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsMoving = false;
        }

        private void openGLControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            gameCamera.zoom += e.Delta > 0 ? 1 : -1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Up, gameCamera));
                    break;
                case Keys.Down:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Down, gameCamera));
                    break;
                case Keys.Left:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Left, gameCamera));
                    break;
                case Keys.Right:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Right, gameCamera));
                    break;
                case Keys.PageUp:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Forward, gameCamera));
                    break;
                case Keys.PageDown:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Back, gameCamera));
                    break;
                case Keys.Home:
                case Keys.Space:
                    gameCamera.resetCamera();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
