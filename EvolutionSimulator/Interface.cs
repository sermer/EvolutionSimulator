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
        List<OrganismStats> OrganismList = new List<OrganismStats>();
        public Interface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EvolutionSimulator.IntitializeVariables.firstDay)
            {
                //create first, generic creatures
                int x = 0;
                while (x < 100)
                {
                    OrganismList.Insert(x, OrganismStats.createLife());
                    x++;
                }
                EvolutionSimulator.IntitializeVariables.firstDay = false;
            }
            int i = 0;
        
            while (i < 100)
            {
                OrganismList = DayCycleHandler.RunDay(OrganismList);
                i++;
            }
            OrganismStats mom = OrganismStats.createLife();            
            OrganismStats dad = OrganismStats.createLife();
            dad.MaxHealth = 20;
            OrganismStats child = ChildCalculations.BabyTime(mom, dad);
        }
    }
}
