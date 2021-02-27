using EvolutionSimulator.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvolutionSimulator
{
    public partial class Interface : Form
    {
        List<Organism> OrganismList = new List<Organism>();
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public Interface()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.firstDay)
            {
                //create first, generic creatures
                int x = 0;
                while (x < 100)
                {
                    //All organisms basically start as primordial soup...
                    OrganismList.Insert(x, Organism.createLife());
                    x++;
                }
                GlobalVariables.firstDay = false;
            }
            int i = 0;

            DayCycleHandler dayCycleHandler = new DayCycleHandler();
            while (i < 100)
            {
                
                OrganismList = dayCycleHandler.RunDay(OrganismList);
                i++;
            }
            Organism mom = Organism.createLife();            
            Organism dad = Organism.createLife();
            dad.dna.MaxHealth = 20;
            Organism child = ChildCalculations.BabyTime(mom, dad);

            AncestryAnalysis.CompareChildToParents(child, mom, dad);
        }

        private void worldGenButton_Click(object sender, EventArgs e)
        {
            GlobalVariables.world = new World.Map();
            GlobalVariables.world.GenerateWorld(201, 201, 100);
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
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

            while (!worker.CancellationPending)
            {
                //Run time...
            }
        }
    }
}