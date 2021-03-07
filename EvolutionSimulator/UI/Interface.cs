using EvolutionSimulator.Analysis;
using EvolutionSimulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EvolutionSimulator
{
    public partial class Interface : Form
    {
        BackgroundWorker backgroundWorker;
        public Interface()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void WorldGenButton_Click(object sender, EventArgs e)
        {
            GenerateWorld();
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                if (GlobalVariables.world.pixels.Count == 0)
                {
                    //Tried to run before creating a world. Generate a fresh one...
                    statusLabel.Invoke((MethodInvoker)delegate { statusLabel.Text = "Generating world"; });
                    GenerateWorld();
                }
                if(GlobalVariables.livingOrganisms.Count == 0 || GlobalVariables.firstDay)
                {
                    //Either it is a new run or everything is dead...either way, start fresh
                    //Set first day variables here...
                    statusLabel.Invoke((MethodInvoker)delegate { statusLabel.Text = "Spawning life"; });
                    GlobalVariables.livingOrganisms = GlobalVariables.world.SpawnLife(248);
                    GlobalVariables.firstDay = false;
                }
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            DayCycleHandler dayCycleHandler = new DayCycleHandler();

            Thread.Sleep(100);

            while (!worker.CancellationPending && GlobalVariables.livingOrganisms.Count > 0)
            {
                //Run a day...if it takes too long, have it only run a segment of time.
                dayCycleHandler.RunDay();
                statusLabel.Invoke((MethodInvoker)delegate { statusLabel.Text = string.Concat(GlobalVariables.livingOrganisms.Count, " organisms are alive.    Day ", GlobalVariables.day); });
            }

            if(GlobalVariables.livingOrganisms.Count == 0)
            {
                statusLabel.Invoke((MethodInvoker)delegate { statusLabel.Text = string.Concat("Nothing but death and decay remains. The last organism died on day ", GlobalVariables.day); });
            }
        }

        private void GenerateWorld()
        {
            GlobalVariables.world = new World.Map();
            Size mapSize = mapPictureBox.Size;
            GlobalVariables.world.GenerateWorld(mapSize.Width, mapSize.Height, 100);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EvolutionSim";
            ImportExport.SavePNG(path);

            LoadMapImage(path + "\\map.png");
        }

        private void LoadMapImage(string path)
        {
            using (var sourceImage = Image.FromFile(path))
            {
                var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                  PixelFormat.Format32bppArgb);
                using (var canvas = Graphics.FromImage(targetImage))
                {
                    canvas.DrawImageUnscaled(sourceImage, 0, 0);
                }
                mapPictureBox.Image = targetImage;
            }
        }
    }
}