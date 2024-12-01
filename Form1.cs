﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace OrbitalCalculatorApp
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }
          
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            populatePlanetComboBox();
            lbConstantG.Text = "Stała grawitacyjna przyjęta jako " + Model.G.ToString();
            manageInputLocker(isCustom.Checked);
        }

        private void populatePlanetComboBox()
        {
            defaultBodies.Items.Clear();
            string[] planetNames = controller.GetPlanetNames();
            defaultBodies.Items.AddRange(planetNames);

            Random rand = new Random();

            if (defaultBodies.Items.Count > 0)
            {
                defaultBodies.SelectedIndex = rand.Next(defaultBodies.Items.Count-1);
            }           
        }

        private void defaultBodies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Body selectedBody = model.DefaultPlanets[defaultBodies.SelectedIndex];
            customM.Text = selectedBody.M.ToString();
            customR.Text = selectedBody.R.ToString();
        }

        private void isCustom_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
                manageInputLocker(checkBox.Checked);
            }
        }

        private void manageInputLocker(bool cond)
        {
            if (cond)
            {
                customSettings.Enabled = true;
                lbPlanet.Enabled = false;
                defaultBodies.Enabled = false;

            }
            else
            {
                customSettings.Enabled = false;
                lbPlanet.Enabled = true;
                defaultBodies.Enabled = true;
            }
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            simulate();
        }

        private bool setAllVariables()
        {
            if (!model.tryParseBodyMass(customM.Text))
            {
                MessageBox.Show("Niewłaściwa wartość masy ciała."); return false;
            }

            if (!model.tryParseBodyRadius(customR.Text))
            {
                MessageBox.Show("Niewłaściwa wartość średniego promienia równikowego."); return false;
            }


            if (!model.tryParseSatMass(satM.Text))
            {
                MessageBox.Show("Niewłaściwa wartość masy satelity."); return false;
            }

            if (!model.tryParseSatHeight(satH.Text))
            {
                MessageBox.Show("Niewłaściwa wartość wysokości satelity."); return false;
            }

            return true;

        }

        private void simulate()
        {
            

            if (setAllVariables())
            {                

                console.Text = "";
                console.Text += "Prędkość orbitalna: " + model.calcOrbitalVelocity().ToString() + $" m/s\r\n";
                console.Text += "Prędkość ucieczki: " + model.calcEscapeVelocity().ToString() + $" m/s\r\n";
                console.Text += "Siła grawitacyjna: " + model.calcGravitationalForce().ToString() + " N\r\n";
                console.Text += "Energia orbitalna: " + model.calcOrbitalEnergy().ToString() + " J\r\n";
                console.Text += "Okres orbitalny: " + model.calcOrbitalPeriod().ToString() + " s\r\n";

                double height = model.r - model.R;
                PlotChart(height, 100);

            };
        }

        private void PlotChart(double height, int points)
        {
            svrChart.Series.Clear();

            Series orbitalVelocitySeries = new Series("Prędkość orbitalna")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.Blue
            };

            Series escapeVelocitySeries = new Series("Prędkość ucieczki")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.Red
            };

            double min = 0.00001;
            double max = model.R + height;
            double step = (max - min) / (points - 1);

            double minValue = double.MaxValue;
            double maxValue = double.MinValue;

            for (int i = 0; i < points; i++)
            {
                double currentHeight = min + i * step;
                double currentRadius = model.R + currentHeight;

                model.r = currentRadius;

                double orbitalVelocity = model.calcOrbitalVelocity();
                double escapeVelocity = model.calcEscapeVelocity();

                orbitalVelocitySeries.Points.AddXY(currentHeight, orbitalVelocity);
                escapeVelocitySeries.Points.AddXY(currentHeight, escapeVelocity);

                minValue = Math.Min(minValue, Math.Min(orbitalVelocity, escapeVelocity));
                maxValue = Math.Max(maxValue, Math.Max(orbitalVelocity, escapeVelocity));
            }

            svrChart.Series.Add(orbitalVelocitySeries);
            svrChart.Series.Add(escapeVelocitySeries);

            svrChart.ChartAreas[0].AxisX.Minimum = 0;
            svrChart.ChartAreas[0].AxisX.Maximum = max;

            svrChart.ChartAreas[0].AxisY.Minimum = Math.Max(0, minValue * 0.9);
            svrChart.ChartAreas[0].AxisY.Maximum = maxValue * 1.1;

            svrChart.ChartAreas[0].AxisX.Title = "Wysokość orbity (km)";
            svrChart.ChartAreas[0].AxisY.Title = "Prędkość (km/s)";

            svrChart.Width = 1000;
            svrChart.Height = 400;

            svrChart.Titles.Clear();
            svrChart.Titles.Add("Zależność prędkości od wysokości orbity");

            addVerticalLineToChart(height, "Wysokość satelity", Color.Orange);            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void addVerticalLineToChart(double position, string label, Color color)
        {
            Series lineSeries = new Series(label)
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = color
            };
            
            lineSeries.Points.AddXY(position, svrChart.ChartAreas[0].AxisY.Minimum);
            lineSeries.Points.AddXY(position, svrChart.ChartAreas[0].AxisY.Maximum);

            svrChart.Series.Add(lineSeries);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // ad tbSatSave
            /*
             * Domyślnie planowalem zeby dane były zapisywane w pliku csv, a nie txt
             * zeby pozniej wygodnie bylo skalowac ta aplikacje
             */
            string filePath = tbSatSave.Text;
            try
            {
                StreamWriter sw = new StreamWriter(filePath);                
                sw.WriteLine($"customM,{customM.Text}");
                sw.WriteLine($"customR,{customR.Text}");
                sw.WriteLine($"satM,{satM.Text}");
                sw.WriteLine($"satH,{satH.Text}");

                MessageBox.Show("Dane zostały zapisane do pliku CSV pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"Błąd podczas zapisywania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // ad tbSatLoad
        }
    }
}
