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
using System.Threading;
using System.Diagnostics;

namespace OrbitalCalculatorApp
{
    public partial class Main : Form
    {

        private Thread calculationThread;
        private Thread imageRenderingThread;

        private double satRadiusAnim;
        private double bodRadiusAnim;

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            init();           
            webBrowser.Invoke((MethodInvoker)(() => { webBrowser.DocumentCompleted += webBrowser_DocumentCompleted; }));
            lbConstantG.Text = "Stała grawitacyjna przyjęta jako " + Model.G.ToString();
            manageInputLocker(isCustom.Checked);
        }

        private void init()
        {
            defaultBodies.Items.Clear();
            string[] planetNames = controller.GetPlanetNames();
            defaultBodies.Items.AddRange(planetNames);

            Random rand = new Random();

            if (defaultBodies.Items.Count > 0)
            {
                int selectedIndex = rand.Next(defaultBodies.Items.Count - 1);
                defaultBodies.SelectedIndex = selectedIndex;
            }            
        }

        private void defaultBodies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Body selectedBody = model.DefaultPlanets[defaultBodies.SelectedIndex];
            customM.Text = selectedBody.M.ToString();
            customR.Text = selectedBody.R.ToString();

            imageRenderingThread = new Thread(() =>
            {               
                if (!string.IsNullOrEmpty(selectedBody.Url))
                {
                    webBrowser.Invoke((MethodInvoker)(() => webBrowser.Navigate(selectedBody.Url)));                    
                }
                else
                {
                    MessageBox.Show($"No information available for {selectedBody.Name}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            imageRenderingThread.IsBackground = true;
            imageRenderingThread.Start();           
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
            if (calculationThread != null && calculationThread.IsAlive)
            {
                MessageBox.Show("Proszę czekać na zakończenie wątku obliczeń.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            orbitTimer.Start();

            progressBar.Value = 0;
            progressBar.Maximum = 100;

            calculationThread = new Thread(() => simulate());
            calculationThread.IsBackground = true;
            calculationThread.Start();

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
            try
            {
                if (!setAllVariables()) return;

                satRadiusAnim = model.r;
                bodRadiusAnim = model.R;

                Invoke((MethodInvoker)(() =>
                {
                    console.Text = "";
                    progressBar.Value = 0;
                }));

                double height = model.r - model.R;
                const int points = 100; // dyskretyzacja obszaru obliczeń, domyślnie ustawione 100 punktów                               

                double orbitalVelocity = model.calcOrbitalVelocity();
                double escapeVelocity = model.calcEscapeVelocity();
                double gravitationalForce = model.calcGravitationalForce();
                double orbitalEnergy = model.calcOrbitalEnergy();
                double orbitalPeriod = model.calcOrbitalPeriod();

                Invoke((MethodInvoker)(() =>
                {
                    console.Text = $"Prędkość orbitalna: {orbitalVelocity} m/s\r\n" +
                                   $"Prędkość ucieczki: {escapeVelocity} m/s\r\n" +
                                   $"Siła grawitacyjna: {gravitationalForce} N\r\n" +
                                   $"Energia orbitalna: {orbitalEnergy} J\r\n" +
                                   $"Okres orbitalny: {orbitalPeriod} s\r\n";

                    DrawOrbit(satRadiusAnim, bodRadiusAnim);

                }));

                orbitTimer.Start();
                PlotChart(height, points);

            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show($"Wystąpił błąd podczas obliczeń: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private void PlotChart(double height, int points)
        {

            svrChart.Invoke((MethodInvoker)(() => svrChart.Series.Clear()));

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

                svrChart.Invoke((MethodInvoker)(() =>
                {
                    orbitalVelocitySeries.Points.AddXY(currentHeight, orbitalVelocity);
                    escapeVelocitySeries.Points.AddXY(currentHeight, escapeVelocity);
                }));

                minValue = Math.Min(minValue, Math.Min(orbitalVelocity, escapeVelocity));
                maxValue = Math.Max(maxValue, Math.Max(orbitalVelocity, escapeVelocity));

                int progress = (int)((double)i / points * 100);
                Invoke((MethodInvoker)(() => progressBar.Value = progress));

                Thread.Sleep(2);
            }

            svrChart.Invoke((MethodInvoker)(() =>
            {

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

            }));

            addVerticalLineToChart(height, "Wysokość satelity", Color.Orange);
            Invoke((MethodInvoker)(() => progressBar.Value = 100));

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (calculationThread != null && calculationThread.IsAlive)
            {
                MessageBox.Show("Proszę czekać na zakończenie wątku obliczeń.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            svrChart.Invoke((MethodInvoker)(() => svrChart.Series.Add(lineSeries)));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Zapisz dane satelity",
                Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*",
                DefaultExt = "csv",
                AddExtension = true,
                FileName = "satellite_data.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                tbSatSave.Text = filePath;

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Parametr;Wartość");
                        sw.WriteLine($"customM;{customM.Text}");
                        sw.WriteLine($"customR;{customR.Text}");
                        sw.WriteLine($"satM;{satM.Text}");
                        sw.WriteLine($"satH;{satH.Text}");
                    }
                    MessageBox.Show("Dane zostały zapisane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas zapisywania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Wczytaj dane satelity",
                Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*",
                DefaultExt = "csv",
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string filePath = openFileDialog.FileName;
                tbSatLoad.Text = filePath;

                try
                {
                    using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                    {
                        sr.ReadLine();

                        while (!sr.EndOfStream)
                        {
                            string[] csv = sr.ReadLine().Split(';');

                            if (csv.Length == 2)
                            {
                                switch (csv[0])
                                {
                                    case "customM":
                                        customM.Text = csv[1];
                                        break;
                                    case "customR":
                                        customR.Text = csv[1];
                                        break;
                                    case "satM":
                                        satM.Text = csv[1];
                                        break;
                                    case "satH":
                                        satH.Text = csv[1];
                                        break;
                                }
                            }
                        }
                    }
                    MessageBox.Show("Dane zostały wczytane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas wczytywania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.Document != null)
            {
                webBrowser.Document.Body.Style = "zoom: 30%;";
            }
        }

        private double currentAngle = 0; 

        private void DrawOrbit(double orbitalRadius, double planetRadius)
        {
            int width = orbitPictureBox.Width;
            int height = orbitPictureBox.Height;

            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Black);

                int centerX = width / 2;
                int centerY = height / 2;
                
                double scale = planetRadius > 1E4 ? 0.001 : 0.01;
                if (planetRadius > 3E4) scale = 0.0003;
                                
                Brush planetBrush = Brushes.Blue;
                int planetDiameter = (int)(planetRadius * scale);
                int planetX = centerX - planetDiameter / 2;
                int planetY = centerY - planetDiameter / 2;
                g.FillEllipse(planetBrush, planetX, planetY, planetDiameter, planetDiameter);
                
                Pen orbitPen = new Pen(Color.Gray, 2);
                int orbitDiameter = (int)(orbitalRadius * scale);
                int orbitX = centerX - orbitDiameter / 2;
                int orbitY = centerY - orbitDiameter / 2;
                g.DrawEllipse(orbitPen, orbitX, orbitY, orbitDiameter, orbitDiameter);
                
                Brush satelliteBrush = Brushes.Red;
                int satelliteDiameter = 10;

                // wyswietl w radianach
                double angleRadians = currentAngle * Math.PI / 180;
                
                double satelliteX = centerX + orbitDiameter / 2 * Math.Cos(angleRadians) - satelliteDiameter / 2;
                double satelliteY = centerY + orbitDiameter / 2 * Math.Sin(angleRadians) - satelliteDiameter / 2;
                g.FillEllipse(satelliteBrush, (float)satelliteX, (float)satelliteY, satelliteDiameter, satelliteDiameter);
            }

            orbitPictureBox.Image = bitmap;
        }


        private void orbitTimer_Tick(object sender, EventArgs e)
        {            
            currentAngle += 5;
            if (currentAngle >= 360) currentAngle -= 360;

            DrawOrbit(satRadiusAnim, bodRadiusAnim);

            Console.WriteLine("dziala");
        }

    }
}
