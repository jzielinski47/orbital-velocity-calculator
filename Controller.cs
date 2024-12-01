using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCalculatorApp
{
    public class Controller
    {
        private Model model;

        public Controller(Model model)
        {
            this.model = model;
        }

        public string[] GetPlanetNames()
        {
            return model.DefaultPlanets.Select(p => p.Name).ToArray();
        }        

    }
}
