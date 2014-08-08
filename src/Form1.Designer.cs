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
            this.splashLabel = new System.Windows.Forms.Label();
            this.splashButton = new System.Windows.Forms.Button();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.pausePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.pausePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 28;
            this.openGLControl1.Location = new System.Drawing.Point(0, 0);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.NativeWindow;
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
            // pauseLabel
            // 
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pauseLabel.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.Location = new System.Drawing.Point(0, 0);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(384, 54);
            this.pauseLabel.TabIndex = 4;
            this.pauseLabel.Text = "Pause";
            this.pauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pausePanel
            // 
            this.pausePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pausePanel.Controls.Add(this.label1);
            this.pausePanel.Controls.Add(this.pauseLabel);
            this.pausePanel.Location = new System.Drawing.Point(191, 62);
            this.pausePanel.Name = "pausePanel";
            this.pausePanel.Size = new System.Drawing.Size(384, 316);
            this.pausePanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 129);
            this.label1.TabIndex = 5;
            this.label1.Text = "Raise right hand over your head\r\nor Press Pause to continue\r\nSelect menu with rig" +
    "ht hand up\r\nand trigger with left hand push";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 486);
            this.Controls.Add(this.pausePanel);
            this.Controls.Add(this.splashButton);
            this.Controls.Add(this.splashLabel);
            this.Controls.Add(this.openGLControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "3D2048";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.pausePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private SharpGL.OpenGLControl openGLControl1;

        #endregion
        private System.Windows.Forms.Label splashLabel;
        private System.Windows.Forms.Button splashButton;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Panel pausePanel;
        private System.Windows.Forms.Label label1;
    }
}

