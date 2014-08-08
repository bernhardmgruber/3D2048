namespace _3D2048
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selSize = new System.Windows.Forms.NumericUpDown();
            this.cube = new System.Windows.Forms.Label();
            this.selTexture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.texturePreview = new System.Windows.Forms.PictureBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.selSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texturePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // selSize
            // 
            this.selSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selSize.Location = new System.Drawing.Point(77, 7);
            this.selSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.selSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.selSize.Name = "selSize";
            this.selSize.Size = new System.Drawing.Size(100, 20);
            this.selSize.TabIndex = 10;
            this.selSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.selSize.ValueChanged += new System.EventHandler(this.selSize_ValueChanged);
            // 
            // cube
            // 
            this.cube.AutoSize = true;
            this.cube.Location = new System.Drawing.Point(12, 9);
            this.cube.Name = "cube";
            this.cube.Size = new System.Drawing.Size(38, 13);
            this.cube.TabIndex = 11;
            this.cube.Text = "Cube ³";
            // 
            // selTexture
            // 
            this.selTexture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selTexture.Location = new System.Drawing.Point(77, 144);
            this.selTexture.Name = "selTexture";
            this.selTexture.Size = new System.Drawing.Size(100, 23);
            this.selTexture.TabIndex = 12;
            this.selTexture.Text = "Select...";
            this.selTexture.UseVisualStyleBackColor = true;
            this.selTexture.Click += new System.EventHandler(this.selTexture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Texture";
            // 
            // texturePreview
            // 
            this.texturePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.texturePreview.Location = new System.Drawing.Point(77, 38);
            this.texturePreview.Name = "texturePreview";
            this.texturePreview.Size = new System.Drawing.Size(100, 100);
            this.texturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.texturePreview.TabIndex = 14;
            this.texturePreview.TabStop = false;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(102, 184);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 16;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "bmp Images|*.bmp";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 220);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.texturePreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selTexture);
            this.Controls.Add(this.cube);
            this.Controls.Add(this.selSize);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.selSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown selSize;
        private System.Windows.Forms.Label cube;
        private System.Windows.Forms.Button selTexture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox texturePreview;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}