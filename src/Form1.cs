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
            if (mouseIsMoving)
            {
                float dy = (e.Y - lastMousePosition.y) * MOTION_SENSITIVITY;
                float dx = (e.X - lastMousePosition.x) * MOTION_SENSITIVITY;
                Vector3D deltaMove = new Vector3D(dy, dx, 0);
                gameCamera.cubeRotation += deltaMove;
                lastMousePosition = new Vector3D(e.X, e.Y, 0);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsMoving = false;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            gameCamera.zoom += e.Delta > 0 ? 1 : -1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    gameLogic.Move(getMoveDependentDirection(Direction.Up));
                    break;
                case Keys.Down:
                    gameLogic.Move(getMoveDependentDirection(Direction.Down));
                    break;
                case Keys.Left:
                    gameLogic.Move(getMoveDependentDirection(Direction.Left));
                    break;
                case Keys.Right:
                    gameLogic.Move(getMoveDependentDirection(Direction.Right));
                    break;
                case Keys.PageUp:
                    gameLogic.Move(getMoveDependentDirection(Direction.Forward));
                    break;
                case Keys.PageDown:
                    gameLogic.Move(getMoveDependentDirection(Direction.Back));
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Direction getMoveDependentDirection(Direction direction)
        {
            Direction outputDirection = direction;

            switch (gameCamera.getFrontFace())
            {
                case CubeFace.FRONT:
                    // Directions don't need to be changed
                    outputDirection = direction;
                    break;
                case CubeFace.LEFT:
                    if (direction == Direction.Forward)
                    {
                        outputDirection = Direction.Left;
                    }
                    else if (direction == Direction.Back)
                    {
                        outputDirection = Direction.Right;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Forward;
                    }
                    else if (direction == Direction.Left)
                    {
                        outputDirection = Direction.Back;
                    }
                    else
                    {
                        outputDirection = direction; //Up/Down: No change
                    }
                    break;
                case CubeFace.BACK:
                    if (direction == Direction.Forward)
                    {
                        outputDirection = Direction.Back;
                    }
                    else if (direction == Direction.Back)
                    {
                        outputDirection = Direction.Forward;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Left;
                    }
                    else if (direction == Direction.Left)
                    {
                        outputDirection = Direction.Right;
                    }
                    else
                    {
                        outputDirection = direction; //Up/Down: No change
                    }
                    break;
                case CubeFace.RIGHT:
                    if (direction == Direction.Forward)
                    {
                        outputDirection = Direction.Right;
                    }
                    else if (direction == Direction.Back)
                    {
                        outputDirection = Direction.Left;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Back;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Forward;
                    }
                    else
                    {
                        outputDirection = direction; //Up/Down: No change
                    }
                    break;
                default:
                    outputDirection = direction;
                    break;
            }

            return outputDirection;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
