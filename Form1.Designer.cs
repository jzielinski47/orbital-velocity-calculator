﻿namespace OrbitalCalculatorApp
{
    partial class Main
    {
        public Model model { get; set; }
        public Controller controller { get; set; }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbPlanet = new System.Windows.Forms.Label();
            this.isCustom = new System.Windows.Forms.CheckBox();
            this.defaultBodies = new System.Windows.Forms.ComboBox();
            this.lbBodyA = new System.Windows.Forms.Label();
            this.customM = new System.Windows.Forms.TextBox();
            this.satH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.satM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.simulateButton = new System.Windows.Forms.Button();
            this.lbConstantG = new System.Windows.Forms.Label();
            this.customSettings = new System.Windows.Forms.GroupBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.console = new System.Windows.Forms.RichTextBox();
            this.svrChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.closeButton = new System.Windows.Forms.Button();
            this.tbSatSave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSatLoad = new System.Windows.Forms.TextBox();
            this.SaveButtun = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.orbitPictureBox = new System.Windows.Forms.PictureBox();
            this.orbitTimer = new System.Windows.Forms.Timer(this.components);
            this.customSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svrChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orbitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPlanet
            // 
            this.lbPlanet.AutoSize = true;
            this.lbPlanet.Location = new System.Drawing.Point(13, 13);
            this.lbPlanet.Name = "lbPlanet";
            this.lbPlanet.Size = new System.Drawing.Size(79, 13);
            this.lbPlanet.TabIndex = 0;
            this.lbPlanet.Text = "Ciało okrążane";
            // 
            // isCustom
            // 
            this.isCustom.AutoSize = true;
            this.isCustom.Location = new System.Drawing.Point(16, 37);
            this.isCustom.Name = "isCustom";
            this.isCustom.Size = new System.Drawing.Size(103, 17);
            this.isCustom.TabIndex = 1;
            this.isCustom.Text = "Niestandardowe";
            this.isCustom.UseVisualStyleBackColor = true;
            this.isCustom.CheckedChanged += new System.EventHandler(this.isCustom_CheckedChanged);
            // 
            // defaultBodies
            // 
            this.defaultBodies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultBodies.FormattingEnabled = true;
            this.defaultBodies.Location = new System.Drawing.Point(98, 10);
            this.defaultBodies.Name = "defaultBodies";
            this.defaultBodies.Size = new System.Drawing.Size(121, 21);
            this.defaultBodies.TabIndex = 3;
            this.defaultBodies.SelectedIndexChanged += new System.EventHandler(this.defaultBodies_SelectedIndexChanged);
            // 
            // lbBodyA
            // 
            this.lbBodyA.AutoSize = true;
            this.lbBodyA.Location = new System.Drawing.Point(9, 29);
            this.lbBodyA.Name = "lbBodyA";
            this.lbBodyA.Size = new System.Drawing.Size(140, 13);
            this.lbBodyA.TabIndex = 4;
            this.lbBodyA.Text = "Masa ciała okrążanego (kg)";
            // 
            // customM
            // 
            this.customM.Location = new System.Drawing.Point(12, 46);
            this.customM.Name = "customM";
            this.customM.Size = new System.Drawing.Size(149, 20);
            this.customM.TabIndex = 5;
            this.customM.Text = "0";
            // 
            // satH
            // 
            this.satH.Location = new System.Drawing.Point(19, 288);
            this.satH.Name = "satH";
            this.satH.Size = new System.Drawing.Size(149, 20);
            this.satH.TabIndex = 11;
            this.satH.Text = "7000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Wysokość orbity (km)";
            // 
            // satM
            // 
            this.satM.Location = new System.Drawing.Point(19, 242);
            this.satM.Name = "satM";
            this.satM.Size = new System.Drawing.Size(149, 20);
            this.satM.TabIndex = 9;
            this.satM.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Masa ciała krążącego (kg)";
            // 
            // customR
            // 
            this.customR.Location = new System.Drawing.Point(12, 97);
            this.customR.Name = "customR";
            this.customR.Size = new System.Drawing.Size(149, 20);
            this.customR.TabIndex = 13;
            this.customR.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Średni promień równikowy ciała (km)";
            // 
            // simulateButton
            // 
            this.simulateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.simulateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simulateButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.simulateButton.Location = new System.Drawing.Point(19, 329);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(200, 32);
            this.simulateButton.TabIndex = 14;
            this.simulateButton.Text = "Oblicz prędkość orbitalną";
            this.simulateButton.UseVisualStyleBackColor = false;
            this.simulateButton.Click += new System.EventHandler(this.OnCalculateClick);
            // 
            // lbConstantG
            // 
            this.lbConstantG.AutoSize = true;
            this.lbConstantG.Location = new System.Drawing.Point(16, 573);
            this.lbConstantG.Name = "lbConstantG";
            this.lbConstantG.Size = new System.Drawing.Size(98, 13);
            this.lbConstantG.TabIndex = 15;
            this.lbConstantG.Text = "Constans grawitacji";
            // 
            // customSettings
            // 
            this.customSettings.Controls.Add(this.lbBodyA);
            this.customSettings.Controls.Add(this.customM);
            this.customSettings.Controls.Add(this.label4);
            this.customSettings.Controls.Add(this.customR);
            this.customSettings.Location = new System.Drawing.Point(19, 60);
            this.customSettings.Name = "customSettings";
            this.customSettings.Size = new System.Drawing.Size(200, 148);
            this.customSettings.TabIndex = 16;
            this.customSettings.TabStop = false;
            this.customSettings.Text = "Ustawienia niestandardowe";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(274, 18);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(37, 13);
            this.lbResult.TabIndex = 17;
            this.lbResult.Text = "Result";
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.MenuText;
            this.console.Cursor = System.Windows.Forms.Cursors.Help;
            this.console.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ForeColor = System.Drawing.Color.Orange;
            this.console.Location = new System.Drawing.Point(277, 37);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(491, 225);
            this.console.TabIndex = 18;
            this.console.Text = "";
            // 
            // svrChart
            // 
            chartArea5.Name = "ChartArea1";
            this.svrChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.svrChart.Legends.Add(legend5);
            this.svrChart.Location = new System.Drawing.Point(298, 271);
            this.svrChart.Name = "svrChart";
            this.svrChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series5.ChartArea = "ChartArea1";
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.svrChart.Series.Add(series5);
            this.svrChart.Size = new System.Drawing.Size(1032, 408);
            this.svrChart.TabIndex = 19;
            this.svrChart.Text = "chart1";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Tomato;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeButton.Location = new System.Drawing.Point(19, 376);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(200, 32);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Zamknij program";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tbSatSave
            // 
            this.tbSatSave.Location = new System.Drawing.Point(12, 467);
            this.tbSatSave.Name = "tbSatSave";
            this.tbSatSave.Size = new System.Drawing.Size(174, 20);
            this.tbSatSave.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Zapisz parametry do pliku";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 504);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Wczytaj parametry z pliku";
            // 
            // tbSatLoad
            // 
            this.tbSatLoad.Location = new System.Drawing.Point(12, 520);
            this.tbSatLoad.Name = "tbSatLoad";
            this.tbSatLoad.Size = new System.Drawing.Size(174, 20);
            this.tbSatLoad.TabIndex = 23;
            // 
            // SaveButtun
            // 
            this.SaveButtun.Location = new System.Drawing.Point(201, 464);
            this.SaveButtun.Name = "SaveButtun";
            this.SaveButtun.Size = new System.Drawing.Size(75, 23);
            this.SaveButtun.TabIndex = 25;
            this.SaveButtun.Text = "Zapisz";
            this.SaveButtun.UseVisualStyleBackColor = true;
            this.SaveButtun.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(201, 518);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 26;
            this.LoadButton.Text = "Wczytaj";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(816, 37);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(514, 225);
            this.webBrowser.TabIndex = 27;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(298, 717);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1032, 14);
            this.progressBar.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 692);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Status obliczeń:";
            // 
            // orbitPictureBox
            // 
            this.orbitPictureBox.Location = new System.Drawing.Point(12, 611);
            this.orbitPictureBox.Name = "orbitPictureBox";
            this.orbitPictureBox.Size = new System.Drawing.Size(264, 258);
            this.orbitPictureBox.TabIndex = 30;
            this.orbitPictureBox.TabStop = false;
            // 
            // orbitTimer
            // 
            this.orbitTimer.Interval = 500;
            this.orbitTimer.Tick += new System.EventHandler(this.orbitTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1413, 922);
            this.Controls.Add(this.orbitPictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButtun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSatLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSatSave);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.svrChart);
            this.Controls.Add(this.console);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.customSettings);
            this.Controls.Add(this.lbConstantG);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.satH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.satM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.defaultBodies);
            this.Controls.Add(this.isCustom);
            this.Controls.Add(this.lbPlanet);
            this.Name = "Main";
            this.Text = "Kalkulator prędkości orbitalnej";
            this.customSettings.ResumeLayout(false);
            this.customSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svrChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orbitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPlanet;
        private System.Windows.Forms.CheckBox isCustom;
        private System.Windows.Forms.ComboBox defaultBodies;
        private System.Windows.Forms.Label lbBodyA;
        private System.Windows.Forms.TextBox customM;
        private System.Windows.Forms.TextBox satH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox satM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Label lbConstantG;
        private System.Windows.Forms.GroupBox customSettings;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.DataVisualization.Charting.Chart svrChart;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox tbSatSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSatLoad;
        private System.Windows.Forms.Button SaveButtun;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox orbitPictureBox;
        private System.Windows.Forms.Timer orbitTimer;
    }
}

