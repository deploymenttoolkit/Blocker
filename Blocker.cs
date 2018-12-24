using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DeploymentToolkit.Blocker
{
    public partial class Blocker : Form
    {
        private bool _allowClose = false;

        private byte _step;
        private Timer _timer;

        public Blocker()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            this.KeyDown += Blocker_KeyDown;
            this.FormClosing += Blocker_Closing;

            // Needed for transparency to work
            this.PictureLogo.Parent = this.PictureBackground;
            this.LabelInstallation.Parent = this.PictureBackground;

            if (File.Exists("Logo.png"))
            {
                this.PictureLogo.Image = Image.FromFile("Logo.png");
                this.PictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if(File.Exists("Background.png"))
            {
                this.PictureBackground.Image = Image.FromFile("Background.png");
                this.PictureBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if(!string.IsNullOrEmpty(Program.Settings.BackgroundColor))
            {
                var color = GetColor(Program.Settings.BackgroundColor);
                if (color != default(Color))
                    this.PictureBackground.BackColor = color;
            }

            if(!string.IsNullOrEmpty(Program.Settings.ForegroundColor))
            {
                var color = GetColor(Program.Settings.ForegroundColor);
                if (color != default(Color))
                    this.LabelInstallation.ForeColor = color;
            }

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Tick;
            _timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            var text = new StringBuilder("Installation running");
            for (var i = 0; i < _step; i++)
            {
                text.Append(".");
            }

            this.LabelInstallation.Text = text.ToString();

            if (++_step > 3)
                _step = 0;
        }

        private void Blocker_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG
            //Closing over key should only be possible in debug mode
            if (e.KeyCode == Keys.Q)
            {
                _allowClose = true;
                this.Close();
            }
#endif
        }

        private void Blocker_Closing(object sender, FormClosingEventArgs e)
        {
            if(!_allowClose)
                e.Cancel = true;
        }

        private Color GetColor(string color)
        {
            Color result = default(Color);
            try
            {
                if (color.StartsWith("#"))
                {
                    result = ColorTranslator.FromHtml(color);
                }
                else
                {
                    result = Color.FromName(color);
                }
            }
            catch (Exception) { }
            return result;
        }
    }
}
