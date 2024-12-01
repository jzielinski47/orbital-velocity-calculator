using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCalculatorApp
{
    public class Body
    {
        public string Name { get; }
        public double R { get; }  // Promień w km
        public double M { get; }  // Masa w kg

        public string Url { get; set; }

        public Body(string name, double r, double m, string url = null)
        {
            Name = name;
            R = r;
            M = m;           
            Url = url;
        }

    }
}
