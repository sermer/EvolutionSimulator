using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EvolutionSimulator.Organisms;
using System.Reflection;

namespace EvolutionSimulator
{
    public class ChildCalculations
    {
        public static Organism BabyTime(Organism mom, Organism dad)
        {
            Organism child = new Organism();
            float parentWeight;
            Random random = new Random();

            foreach(PropertyInfo property in child.dna.GetType().GetProperties())
            {
                try
                {
                    //50-50 chance genes come from each parent.
                    parentWeight = random.Next(0, 2);

                    PropertyInfo pi = child.dna.GetType().GetProperty(property.Name);
                    if (parentWeight >= 1)
                    {
                        pi.SetValue(child.dna, dad.dna.GetType().GetProperty(property.Name).GetValue(dad.dna));
                    }
                    else
                    {
                        pi.SetValue(child.dna, mom.dna.GetType().GetProperty(property.Name).GetValue(mom.dna));
                    }
                }
                catch
                {

                }
            }

            //The following attributes are determined by how healthy the parents are
            child.StoredEnergy = (mom.StoredEnergy + dad.StoredEnergy) / 2;
            child.MovementBoost = (mom.MovementBoost + dad.MovementBoost) / 2;


            child.Health = child.dna.MaxHealth;
            return child;
        }
    }
}