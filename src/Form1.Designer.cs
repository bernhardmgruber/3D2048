namespace _3D2048
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splashLabel = new System.Windows.Forms.Label();
            this.splashButton = new System.Windows.Forms.Button();
            this.scoreLablel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 28;
            this.openGLControl1.Location = new System.Drawing.Point(0, 0);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(723, 486);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.Resized += new System.EventHandler(this.openGLControl1_Resized);
            this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseUp);
            this.openGLControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseWheel);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // splashLabel
            // 
            this.splashLabel.AutoSize = true;
            this.splashLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashLabel.ForeColor = System.Drawing.Color.Crimson;
            this.splashLabel.Location = new System.Drawing.Point(212, 175);
            this.splashLabel.Name = "splashLabel";
            this.splashLabel.Size = new System.Drawing.Size(0, 51);
            this.splashLabel.TabIndex = 1;
            this.splashLabel.Visible = false;
            // 
            // splashButton
            // 
            this.splashButton.BackColor = System.Drawing.Color.Transparent;
            this.splashButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.splashButton.FlatAppearance.BorderSize = 2;
            this.splashButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splashButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashButton.ForeColor = System.Drawing.Color.Crimson;
            this.splashButton.Location = new System.Drawing.Point(286, 283);
            this.splashButton.Name = "splashButton";
            this.splashButton.Size = new System.Drawing.Size(139, 52);
            this.splashButton.TabIndex = 2;
            this.splashButton.UseVisualStyleBackColor = false;
            this.splashButton.Visible = false;
            this.splashButton.Click += new System.EventHandler(this.splashButton_Click);
            // 
            // scoreLablel
            // 
            this.scoreLablel.AutoSize = true;
            this.scoreLablel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLablel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLablel.ForeColor = System.Drawing.Color.Crimson;
            this.scoreLablel.Location = new System.Drawing.Point(12, 9);
            this.scoreLablel.Name = "scoreLablel";
            this.scoreLablel.Size = new System.Drawing.Size(45, 17);
            this.scoreLablel.TabIndex = 3;
            this.scoreLablel.Text = "Score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 486);
            this.Controls.Add(this.scoreLablel);
            this.Controls.Add(this.splashButton);
            this.Controls.Add(this.splashLabel);
            this.Controls.Add(this.openGLControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "3D2048";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private SharpGL.OpenGLControl openGLControl1;

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label splashLabel;
        private System.Windows.Forms.Button splashButton;
        private System.Windows.Forms.Label scoreLablel;
    }
}

