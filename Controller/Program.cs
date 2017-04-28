using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller controller = new Controller();
            System.Threading.Thread GameThread = new System.Threading.Thread(controller.RunGame);
            GameThread.Start();
            Application.Run(controller);
        }
    }
}
