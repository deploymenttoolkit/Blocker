using NLog;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DeploymentToolkit.Blocker
{
    public partial class Blocker : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private bool _allowClose = false;

        private byte _step;
        private Timer _timer;

        public Blocker()
        {
            _logger.Trace("Blocker initializing...");

            InitializeComponent();

            _logger.Trace("Setting blocker settings...");

            this.FormBorderStyle = FormBorderStyle.None;

            this.KeyDown += Blocker_KeyDown;
            this.FormClosing += Blocker_Closing;

            // Needed for transparency to work
            _logger.Trace("Switching parents...");
            this.PictureLogo.Parent = this.PictureBackground;
            this.LabelInstallation.Parent = this.PictureBackground;

            if (File.Exists("Logo.png"))
            {
                _logger.Trace("Custom logo found. Creating logo...");
                try
                {
                    this.PictureLogo.Image = Image.FromFile("Logo.png");
                    this.PictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Failed to create logo");
                }
            }

            if(File.Exists("Background.png"))
            {
                _logger.Trace("Custom background found. Creating background...");
                try
                {
                    this.PictureBackground.Image = Image.FromFile("Background.png");
                    this.PictureBackground.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch(Exception ex)
                {
                    _logger.Error(ex, "Failed to create background image");
                }
            }
            else if(!string.IsNullOrEmpty(Program.Settings.BackgroundColor))
            {
                _logger.Info("Custom background color specified in Settings.xml. Setting colors...");
                var color = GetColor(Program.Settings.BackgroundColor);
                if (color != default(Color))
                    this.PictureBackground.BackColor = color;
                else
                    _logger.Warn($"Unknown color specified ({Program.Settings.BackgroundColor})");
            }

            if(!string.IsNullOrEmpty(Program.Settings.ForegroundColor))
            {
                _logger.Info("Custom foreground color specified in Settings.xml. Setting colors...");
                var color = GetColor(Program.Settings.ForegroundColor);
                if (color != default(Color))
                    this.LabelInstallation.ForeColor = color;
                else
                    _logger.Warn($"Unknown color specified ({Program.Settings.BackgroundColor})");
            }

            _logger.Info("Creating and starting timer...");
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Tick;
            _timer.Start();

            _logger.Info("Blocker successfully initialized");
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
                _logger.Warn("Closing allowed because of DEBUG build");
                _allowClose = true;
                this.Close();
            }
#endif
        }

        private void Blocker_Closing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                _logger.Trace("User tried to close application. Preventing...");
                e.Cancel = true;
            }
        }

        private Color GetColor(string color)
        {
            var result = default(Color);
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
            catch (Exception ex)
            {
                _logger.Error(ex, $"Failed to parse color ({color})");
            }
            return result;
        }
    }
}
