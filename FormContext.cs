using NLog;
using System.Threading;
using System.Windows.Forms;

namespace DeploymentToolkit.Blocker
{
    // https://stackoverflow.com/questions/15300887/run-two-winform-windows-simultaneously
    internal class FormContext : ApplicationContext
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private int openForms;

        public FormContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach (var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    //When we have closed the last of the "starting" forms, 
                    //end the program.
                    if (Interlocked.Decrement(ref openForms) == 0)
                    {
                        _logger.Info("All blockers closed. Exiting application");
                        ExitThread();
                    }
                };

                form.Show();
            }
        }
    }
}
