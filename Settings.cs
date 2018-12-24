using System;

namespace DeploymentToolkit.Blocker
{

    [Serializable()]
    public partial class Settings
    {
        public string ForegroundColor { get; set; }

        public string BackgroundColor { get; set; }
    }
}
