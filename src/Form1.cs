using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using _3D2048.Util;
using _3D2048.Rendering;
using _3D2048.Logic;

using SharpGL;
using _3D2048.Properties;
using System.Collections.Generic;

namespace _3D2048
{
    public partial class Form1 : Form
    {
        const float MOTION_SENSITIVITY = 0.5f;

        private _3D2048.Logic.GameLogic gameLogic;

        private Renderer renderer;
        private SettingsForm settings;
        private bool mouseIsMoving;
        private Vector3D lastMousePosition;
        private Camera gameCamera;
        private KinectInput kinect;
        private List<Button> pauseMenuButtons;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new Logic.GameLogic();
            gameCamera = new Camera();

            kinect = new KinectInput(gameLogic, gameCamera);

            mouseIsMoving = false;
            lastMousePosition = new Vector3D(0, 0, 0);

            pauseMenuButtons = new List<Button>();

            //showSplash("3D 2048", "Start");
            settings = new SettingsForm(this);
            settings.Show();
            initOpenGL();

            generateMenuButtons();
        }

        private void initOpenGL()
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            Textures textures = new Textures(gl, Settings.Default.texturePath);
            renderer = new Renderer(gl, textures);
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

        public void showPause()
        {
            pausePanel.Visible = true;
        }

        public void hidePause()
        {
            pausePanel.Visible = false;
        }

        public void hideSplash()
        {
            splashButton.Visible = false;
            splashLabel.Visible = false;
        }

        public void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            if (gameLogic.gameModel.lost)
                showSplash("Game Over!", "Restart");
            if (gameLogic.gameModel.won)
                showSplash("Well Done!", "Restart");
            if (gameLogic.gameModel.pause){
                showPause(); 
                pauseLabel.Text = "Pause";
            }
            else if (!gameLogic.gameModel.started)
            {
                showPause();
                pauseLabel.Text = "Start";
            }
            else
            {
                hidePause();
            }
            if (gameLogic.gameModel.pauseNextButton)
            {
                nextMenuButton();
                gameLogic.gameModel.pauseNextButton = false;
            }
            if (gameLogic.gameModel.pausePressButton)
            {
                pressMenuButton();
                gameLogic.gameModel.pausePressButton = false;
            }
            renderer.draw(gameCamera,gameLogic.gameModel);
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
                case Keys.Space:
                    gameCamera.resetCamera();
                    break;
                case Keys.Pause:
                    if ((gameLogic.gameModel.pause)||(!gameLogic.gameModel.started))
                    {
                        gameLogic.resume();
                        gameLogic.gameModel.started = true;
                    }
                    else
                    {
                        gameLogic.pause();
                    }
                    break;
                case Keys.A:
                    nextMenuButton();
                    break;
                case Keys.B:
                    pressMenuButton();
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

        public void updateSize()
        {
            gameLogic.reset();
        }

        public void updateTextures()
        {
            Textures textures = new Textures(openGLControl1.OpenGL, Settings.Default.texturePath);
            renderer.textures = textures;
        }

        private void generateMenuButtons()
        {
            Button btnRestart = new Button();
            btnRestart.Text = "Restart";
            btnRestart.Dock = DockStyle.Bottom;
            btnRestart.Height = 50;
            btnRestart.Font = new System.Drawing.Font("Tahoma", 18, FontStyle.Regular);
            btnRestart.Click += btnRestart_Click;
            pauseMenuButtons.Add(btnRestart);
            pausePanel.Controls.Add(btnRestart);

            Button btnResume = new Button();
            btnResume.Text = "Resume";
            btnResume.Dock = DockStyle.Bottom;
            btnResume.Height = 50;
            btnResume.Font = new System.Drawing.Font("Tahoma", 18, FontStyle.Regular);
            btnResume.Click += btnResume_Click;
            pauseMenuButtons.Add(btnResume);
            pausePanel.Controls.Add(btnResume);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            gameLogic.reset();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            gameLogic.resume();
            gameLogic.gameModel.started = true;
        }

        private void nextMenuButton()
        {
            int currBtn = 0;
            foreach (Button btn in pauseMenuButtons)
            {
                btn.BackColor = System.Drawing.SystemColors.Control;
            }
            foreach (Button btn in pauseMenuButtons)
            {
                if ((btn.Tag != null)&&(btn.Tag.ToString() == "curr"))
                {
                    btn.Tag = "";

                    break;
                }
                currBtn++;
            }
            currBtn++;
            if (currBtn > pauseMenuButtons.Count - 1)
            {
                currBtn = 0;
            }
            pauseMenuButtons[currBtn].Tag = "curr";
            pauseMenuButtons[currBtn].BackColor = System.Drawing.Color.CornflowerBlue;
        }

        private void pressMenuButton()
        {
            foreach (Button btn in pauseMenuButtons)
            {
                if ((btn.Tag != null) && (btn.Tag.ToString() == "curr"))
                {
                    btn.PerformClick();
                }
            }
        }
    }
}
