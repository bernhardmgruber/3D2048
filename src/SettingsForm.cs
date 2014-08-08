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
using _3D2048.Properties;

namespace _3D2048
{
    public partial class SettingsForm : Form
    {
        private Form1 parent;
        private bool updateTextures = false;

        public SettingsForm(Form1 form)
        {
            this.parent = form;
            InitializeComponent();
            this.texturePreview.ImageLocation = Settings.Default.texturePath;
            this.selSize.Value = Settings.Default.gameSize;
        }

        private void selTexture_Click(object sender, EventArgs e)
        {
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFile.FileName != Settings.Default.texturePath)
                {
                    Settings.Default.texturePath = openFile.FileName;
                    texturePreview.ImageLocation = Settings.Default.texturePath;
                    updateTextures = true;
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (selSize.Value != Settings.Default.gameSize)
            {
                Settings.Default.gameSize = (int)selSize.Value;
                parent.updateSize();
            }
            if (updateTextures)
            {
                parent.updateTextures();
                updateTextures = false;
            }
            Properties.Settings.Default.Save();
        }

        private void selSize_ValueChanged(object sender, EventArgs e)
        {
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
            Settings.gameSize = (int)numericUpDown1.Value;
            gameLogic.reset();
        }

        */



    }
}
