using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrbitalCalculatorApp
{
    internal static class Program
    {
        /*
         * @author Jakub Zieliński K05 12K3 2024
         */
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
