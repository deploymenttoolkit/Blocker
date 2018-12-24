using System;
using System.Collections.Generic;
using System.IO;
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

        private static List<Blocker> _blockers = new List<Blocker>();

        [STAThread]
        static void Main(string[] args)
        {
            ReadSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var screens = Screen.AllScreens;
            foreach(var screen in screens)
            {
                var blocker = new Blocker
                {
                    Size = screen.WorkingArea.Size
                };
                SetWindowPos(blocker.Handle, IntPtr.Zero, screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height, 0);
                _blockers.Add(blocker);
            }

            Application.Run(new FormContext(_blockers.ToArray()));
        }

        private static void ReadSettings()
        {
            try
            {
                if (!File.Exists("Settings.xml"))
                    return;

                var xml = File.ReadAllText("Settings.xml");
                var serializer = new XmlSerializer(typeof(Settings));
                using (var stringReader = new StringReader(xml))
                {
                    Settings = (Settings)serializer.Deserialize(stringReader);
                }
            }
            catch (Exception) { }
        }
    }
}
