using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3D2048.Logic;

namespace _3D2048
{
    public partial class Settings : Form
    {
        private Form1 parent;
        public String texturePath
        {
            set;
            get;
        }


        public Settings(Form1 form)
        {
            this.parent = form;
            InitializeComponent();
        }

        private void selTexture_Click(object sender, EventArgs e)
        {
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                texturePath = openFile.FileName;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            GameState.size = (int) selSize.Value;
            parent.applySettings();
        }





        /*




        private void button2_Click(object sender, EventArgs e)
        {
            gameLogic.reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                renderer.textures.texturePath = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameState.size = (int)numericUpDown1.Value;
            gameLogic.reset();
        }

        */



    }
}
