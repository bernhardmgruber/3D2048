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
        private _3D2048.Logic.GameLogic _gameLogic;

        public Form1()
        {
            InitializeComponent();
            _gameLogic = new Logic.GameLogic();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _gameLogic.Move();
                    break;
                case Keys.Down:
                    _gameLogic.Move();
                    break;
                case Keys.Left:
                    _gameLogic.Move();
                    break;
                case Keys.Right:
                    _gameLogic.Move();
                    break;
                case Keys.PageUp:
                    _gameLogic.Move();
                    break;
                case Keys.PageDown:
                    _gameLogic.Move();
                    break;
            }
        }
    }
}
