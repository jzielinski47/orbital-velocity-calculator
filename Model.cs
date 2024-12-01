using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCalculatorApp
{
    public class Model
    {
        public Body[] DefaultPlanets { get; private set; }
        public bool isCustomChecked { get; set; }

        public const double G = 6.6743015E-20;
        public double M { get; set; }

        public double R { get; set; }
        public double m { get; set; }
        public double r { get; set; }

        public Model()
        {

            DefaultPlanets = new Body[]
            {
                new Body("Słońce", 696340, 1.989E30),
                new Body("Ziemia", 6378, 5.972E24),
                new Body("Mars", 3389.5, 6.417E23),
                new Body("Jowisz", 69911, 1.898E27),
                new Body("Wenus", 6051.8, 4.867E24),
                new Body("Merkury", 2439.7, 3.285E23),
                new Body("Saturn", 58232, 5.683E26),
                new Body("Uran", 25362, 8.681E25),
                new Body("Neptun", 24622, 1.024E26),
            };

        }

        public bool tryParseBodyMass(string local)
        {
            try
            {
                this.M = Convert.ToDouble(local);
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool tryParseBodyRadius(string local)
        {
            try
            {
                this.R = Convert.ToDouble(local);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool tryParseSatMass(string local)
        {
            try
            {
                this.m = Convert.ToDouble(local);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool tryParseSatHeight(string local)
        {
            try
            {
                this.r = Convert.ToDouble(local) + this.R;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public double calcOrbitalVelocity()
        {
            return Math.Sqrt(Model.G * this.M / this.r);
        }

        public double calcEscapeVelocity()
        {
            return Math.Sqrt(2 * Model.G * this.M / this.r);
        }

        public double calcOrbitalPeriod()
        {
            return 2 * Math.PI * Math.Sqrt(Math.Pow(this.r, 3) / Model.G * this.M);
        }

        public double calcGravitationalForce()
        {
            return (Model.G * this.M * this.m) / Math.Pow(this.r, 2);
        }

        public double calcOrbitalEnergy()
        {
            return -(Model.G * this.M * this.m / 2 * this.r);
        }

    }
}