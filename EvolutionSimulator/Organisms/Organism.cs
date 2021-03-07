using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EvolutionSimulator.Organisms;
using EvolutionSimulator.World;
using System.Security.AccessControl;
using System.Reflection;

namespace EvolutionSimulator
{
    public class Organism 
    {
        public DNA DNA = new DNA();
        public Stats Stats = new Stats();

        //public Brain Brain = new Brain();
        public MapPixel Location { get; set; }

        public bool isAlive = true;

        public static Organism CreateLife()
        {
            Organism org = new Organism();
            org.DNA.ChemicalAbsorption = 50;
            org.Stats.Health = 100;
            org.Stats.StoredEnergy = 50;
            org.Location = GlobalVariables.firstVentLocation;
            org.CalculateBMR();
            return org;
        }
        public void InteractWithEnvironment()
        {
            ProcessPassiveEnergy();
            ProcessBMR();
        }

        public void Mutate()
        {
            Random rand = new Random();
            //Chance for DNA to change
            foreach (PropertyInfo property in DNA.GetType().GetProperties())
            {
                if(rand.Next(0,8) < 1)
                {
                    int dnaValue = Convert.ToInt32(DNA.GetType().GetProperty(property.Name).GetValue(DNA));

                    if(rand.Next(0,2) == 0 && dnaValue > 0)
                    {
                        dnaValue--;
                    }
                    else if(dnaValue < 100)
                    {
                        dnaValue++;
                    }
                    else
                    {
                        dnaValue--;
                    }

                    DNA.GetType().GetProperty(property.Name).SetValue(DNA, dnaValue);
                }
            }

            CalculateBMR();
        }

        private void ProcessPassiveEnergy()
        {
            if(DNA.ChemicalAbsorption > 0 && Location.Type == "v")
            {
                Stats.StoredEnergy += (DNA.ChemicalAbsorption + Location.TypeStrength) / 2;
            }
            if(DNA.Photosynthesis > 0)
            {
                //Photosynthesis is more efficient but isn't always available.

                string tod = GlobalVariables.timeOfDay;
                if (tod == "Dawn" || tod == "Dusk")
                {
                    //half efficiency
                    Stats.StoredEnergy += DNA.Photosynthesis;
                }
                if(tod == "Day")
                {
                    Stats.StoredEnergy += DNA.Photosynthesis * 2;
                }
            }

            if(Stats.StoredEnergy > Stats.BMR * 30)
            {
                //Can only store a month of extra energy
                Stats.StoredEnergy = Stats.BMR * 30;
            }
        }

        private void ProcessBMR()
        {
            Stats.StoredEnergy -= Stats.BMR;
            if(Stats.StoredEnergy < 0)
            {
                //F
                Die();
            }
        }

        private void Move()
        {
            //Need to set up the map in which the organisms can move in

        }

        private void Attack()
        {

        }

        private void Hide()
        {

        }

        private void Mate()
        {
            //Find target. Needs to be within moveable space and also looking to mate.
        }

        private void Die()
        {
            GlobalVariables.livingOrganisms.Remove(this);
            isAlive = false;
        }

        private void CalculateBMR()
        {
            int dnaCount = DNA.GetType().GetProperties().Count();
            int totalDNAPoints = 0;
            foreach (PropertyInfo property in DNA.GetType().GetProperties())
            {
                totalDNAPoints += Convert.ToInt32(DNA.GetType().GetProperty(property.Name).GetValue(DNA));
            }

            Stats.BMR = Convert.ToInt32(totalDNAPoints / (dnaCount / 2));
        }
    }
}