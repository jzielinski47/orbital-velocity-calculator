using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrbitalCalculatorApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           
            Model model = new Model();     
            Controller controller = new Controller(model);            
            Main main = new Main
            {
                model = model,
                controller = controller
            };

            Application.Run(main);
        }
    }
}
