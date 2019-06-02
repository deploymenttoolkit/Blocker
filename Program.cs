using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DeploymentToolkit.Blocker
{
    class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        internal static Settings Settings = new Settings();

        private static string _namespace;
        internal static string Namespace
        {
            get
            {
                if (string.IsNullOrEmpty(_namespace))
                    _namespace = typeof(Program).Namespace;
                return _namespace;
            }
        }

        private static Version _version;
        internal static Version Version
        {
            get
            {
                if (_version == null)
                    _version = Assembly.GetExecutingAssembly().GetName().Version;
                return _version;
            }
        }

        private static List<Blocker> _blockers = new List<Blocker>();
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Logging.LogManager.Initialize("Blocker");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to initialize logger");
                Console.WriteLine(ex);
#if DEBUG
                Console.ReadKey();
#endif
                Environment.Exit(-1);
            }

            _logger.Info($"{Namespace} v{Version} initializing...");
#if DEBUG
            _logger.Warn("Debug Build detected. Blockers can be closed!");
#endif


            _logger.Trace("Reading settings from settings file");
            ReadSettings();
            _logger.Trace("Read settings");

            _logger.Trace("Enabling visuals");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var screens = Screen.AllScreens;
            _logger.Trace($"Detected {screens.Length} monitors");
            foreach (var screen in screens)
            {
                _logger.Info($"Creating blocker for {screen.DeviceName} with size {screen.Bounds.Width}x{screen.Bounds.Height}");
                var blocker = new Blocker
                {
                    Size = screen.WorkingArea.Size
                };
                SetWindowPos(blocker.Handle, IntPtr.Zero, screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height, 0);
                _blockers.Add(blocker);
                _logger.Info($"Blocker for {screen.DeviceName} created");
            }

            _logger.Trace("Starting all blockers");
            Application.Run(new FormContext(_blockers.ToArray()));
        }

        private static void ReadSettings()
        {
            try
            {
                if (!File.Exists("Settings.xml"))
                {
                    _logger.Info("No settings.xml found. Using default values");
                    return;
                }

                var xml = File.ReadAllText("Settings.xml");
                var serializer = new XmlSerializer(typeof(Settings));
                using (var stringReader = new StringReader(xml))
                {
                    Settings = (Settings)serializer.Deserialize(stringReader);
                }
                _logger.Info("Successfuly read settings from Settings.xml");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to read settings from settings.xml. Using default values");
            }
        }
    }
}
