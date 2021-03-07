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

            foreach(PropertyInfo property in child.DNA.GetType().GetProperties())
            {
                try
                {
                    //50-50 chance genes come from each parent.
                    parentWeight = random.Next(0, 2);

                    PropertyInfo pi = child.DNA.GetType().GetProperty(property.Name);
                    if (parentWeight >= 1)
                    {
                        pi.SetValue(child.DNA, dad.DNA.GetType().GetProperty(property.Name).GetValue(dad.DNA));
                    }
                    else
                    {
                        pi.SetValue(child.DNA, mom.DNA.GetType().GetProperty(property.Name).GetValue(mom.DNA));
                    }
                }
                catch
                {

                }
            }

            //The following attributes are determined by how healthy the parents are
            child.Stats.StoredEnergy = (mom.Stats.StoredEnergy + dad.Stats.StoredEnergy) / 2;
            child.Stats.MovementBoost = (mom.Stats.MovementBoost + dad.Stats.MovementBoost) / 2;


            child.Stats.Health = child.DNA.MaxHealth;
            return child;
        }
    }
}