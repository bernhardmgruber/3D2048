using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D2048
{
    public partial class Form1 : Form
    {
        private _3D2048.Logic.GameLogic gameLogic;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new Logic.GameLogic();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    gameLogic.Move();
                    break;
                case Keys.Down:
                    gameLogic.Move();
                    break;
                case Keys.Left:
                    gameLogic.Move();
                    break;
                case Keys.Right:
                    gameLogic.Move();
                    break;
                case Keys.PageUp:
                    gameLogic.Move();
                    break;
                case Keys.PageDown:
                    gameLogic.Move();
                    break;
            }
        }
    }
}
