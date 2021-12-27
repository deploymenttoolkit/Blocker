namespace DeploymentToolkit.Blocker
{
    partial class Blocker
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
            this.LabelInstallation = new System.Windows.Forms.Label();
            this.PictureLogo = new System.Windows.Forms.PictureBox();
            this.PictureBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelInstallation
            // 
            this.LabelInstallation.BackColor = System.Drawing.Color.Transparent;
            this.LabelInstallation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInstallation.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelInstallation.Location = new System.Drawing.Point(0, 0);
            this.LabelInstallation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelInstallation.Name = "LabelInstallation";
            this.LabelInstallation.Size = new System.Drawing.Size(933, 532);
            this.LabelInstallation.TabIndex = 0;
            this.LabelInstallation.Text = "Installation running\n";
            this.LabelInstallation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelInstallation.UseWaitCursor = true;
            // 
            // PictureLogo
            // 
            this.PictureLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureLogo.Location = new System.Drawing.Point(0, 0);
            this.PictureLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PictureLogo.Name = "PictureLogo";
            this.PictureLogo.Size = new System.Drawing.Size(933, 115);
            this.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureLogo.TabIndex = 1;
            this.PictureLogo.TabStop = false;
            this.PictureLogo.UseWaitCursor = true;
            // 
            // PictureBackground
            // 
            this.PictureBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBackground.BackColor = System.Drawing.Color.Transparent;
            this.PictureBackground.Location = new System.Drawing.Point(0, 0);
            this.PictureBackground.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PictureBackground.Name = "PictureBackground";
            this.PictureBackground.Size = new System.Drawing.Size(933, 532);
            this.PictureBackground.TabIndex = 2;
            this.PictureBackground.TabStop = false;
            this.PictureBackground.UseWaitCursor = true;
            // 
            // Blocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 532);
            this.ControlBox = false;
            this.Controls.Add(this.PictureLogo);
            this.Controls.Add(this.LabelInstallation);
            this.Controls.Add(this.PictureBackground);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Blocker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Blocker";
            this.TopMost = true;
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelInstallation;
        private System.Windows.Forms.PictureBox PictureLogo;
        private System.Windows.Forms.PictureBox PictureBackground;
    }
}