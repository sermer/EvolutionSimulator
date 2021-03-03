using EvolutionSimulator.Analysis;
using EvolutionSimulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EvolutionSimulator
{
    public partial class Interface : Form
    {
        List<Organism> OrganismList = new List<Organism>();
        BackgroundWorker backgroundWorker;
        public Interface()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void worldGenButton_Click(object sender, EventArgs e)
        {
            GlobalVariables.world = new World.Map();
            //XYZ should be either user customizable or determined by the UI dimensions
            GlobalVariables.world.GenerateWorld(201, 201, 100);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EvolutionSim";
            ImportExport.SavePNG(path);
            pictureBox1.Image = Image.FromFile(path + "\\map.png");
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                if (GlobalVariables.world.pixels.Count == 0)
                {
                    //Tried to run before creating a world. Generate a fresh one...
                    GlobalVariables.world.GenerateWorld(201, 201, 100);
                }
                if(GlobalVariables.livingOrganisms.Count == 0 || GlobalVariables.firstDay)
                {
                    //Either it is a new run or everything is dead...either way, start fresh
                    //Set first day variables here...
                    GlobalVariables.livingOrganisms = GlobalVariables.world.SpawnLife(100);
                    GlobalVariables.firstDay = false;
                }
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            DayCycleHandler dayCycleHandler = new DayCycleHandler();

            while (!worker.CancellationPending)
            {
                //Run a day...if it takes too long, have it only run a segment of time.
                dayCycleHandler.RunDay();
                Thread.Sleep(250);
                Console.WriteLine("Running");

            }
        }
    }
}