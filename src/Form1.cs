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
            this.scoreLablel.Parent = openGLControl1;

            //showSplash("3D 2048", "Start");
            initOpenGL();
    
        }

        private void initOpenGL()
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            renderer = new Renderer(gl);
        }

        public void showSplash(String label, String button)
        {
            splashLabel.Parent = openGLControl1;
            splashLabel.BackColor = System.Drawing.Color.Transparent;
            splashLabel.Text = label;
            splashLabel.Location = new Point((this.Width-splashLabel.Width) / 2, (this.Height-splashLabel.Width) / 2);
            splashButton.Parent = openGLControl1;
            splashButton.BackColor = System.Drawing.Color.Transparent;
            splashButton.Text = button;
            splashButton.Location = new Point((this.Width - splashButton.Width) / 2, (this.Height - splashButton.Height) / 2);
            splashButton.Visible = true;
            splashLabel.Visible = true;
        }

        public void hideSplash()
        {
            splashButton.Visible = false;
            splashLabel.Visible = false;
        }

        public void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            if (gameLogic.gameModel.lost) showSplash("Game Over!", "Restart");
            if (gameLogic.gameModel.won) showSplash("Well Done!", "Restart");
            scoreLablel.Text = "Score: " + gameLogic.gameModel.score;
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
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Back, gameCamera));
                    break;
                case Keys.PageDown:
                    gameLogic.Move(gameLogic.getMoveDependentDirection(Direction.Forward, gameCamera));
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

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            splashLabel.Location = new Point((this.Width - splashLabel.Width) / 2, (this.Height - splashLabel.Width) / 2);
            splashButton.Location = new Point((this.Width - splashButton.Width) / 2, (this.Height - splashButton.Height) / 2);

            OpenGL gl = this.openGLControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            double w = (double)openGLControl1.Width;
            double h = (double)openGLControl1.Height;
            if (h == 0) 
            {
                h = 1;
            }
            
            gl.Perspective(Camera.fieldOfView, w/h, 1, 100);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void splashButton_Click(object sender, EventArgs e)
        {
            gameLogic.reset();
            hideSplash();
        }
    }
}
