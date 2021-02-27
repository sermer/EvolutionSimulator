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
        //strings
        //uniqueID, 

        //floats
        //totalHealth, lifeExpectancy, maxSize, maxEnergy, defense, attack, moveStat, averageChildren, intelligence
        //chemicalAbsorption, photosynthesis, digestiveAbility, health, size, storedEnergy, age, attractiveness, movementBoost

        //ints
        //xCoordinate, yCoordinate, moveOrder

        //tuples 
        //parents

        public static Organism BabyTime(Organism mom, Organism dad)
        {
            Organism child = new Organism();
            float parentWeight;
            Random random = new Random();

            var orgAttributes = new[] { "LifeExpectancy", "MaxEnergy", "MaxSize", "MaxHealth", "Defense", "Attack", "MoveStat", "AverageChildren", "Intelligence", "ChemicalAbsorption", "Photosynthesis", "DigestiveAbility" };

            for(int i = 0; i < orgAttributes.Length - 1; i++)
            {
                try
                {
                    parentWeight = random.Next(0, 1);

                    PropertyInfo pi = child.dna.GetType().GetProperty(orgAttributes[i]);
                    if (parentWeight >= .5)
                    {
                        //Not currently working...
                        //pi.SetValue(child, 1);
                    }
                    else
                    {
                        //pi.SetValue(child, 2);
                    }
                }
                catch
                {
                    Console.WriteLine(orgAttributes[i] + " doesn't seem to be an actual attribute. BabyTime()....");
                }
                
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Size = mom.Size;
            }
            else
            {
                child.Size = dad.Size;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.StoredEnergy = mom.StoredEnergy;
            }
            else
            {
                child.StoredEnergy = dad.StoredEnergy;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Attractiveness = mom.Attractiveness;
            }
            else
            {
                child.Attractiveness = dad.Attractiveness;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Age = mom.Age;
            }
            else
            {
                child.Age = dad.Age;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.MovementBoost = mom.MovementBoost;
            }
            else
            {
                child.MovementBoost = dad.MovementBoost;
            }
            child.Health = child.dna.MaxHealth;
            return child;
        }
    }
}