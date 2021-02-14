using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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

        public static OrganismStats BabyTime(OrganismStats mom, OrganismStats dad)
        {
            OrganismStats child = OrganismStats.createLife();
            float parentWeight;
            Random random = new Random();

            //I will likely change this to a more compact loop that just iterates through the different attributes later but this works for now.

            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.LifeExpectancy = mom.LifeExpectancy;
            }
            else
            {
                child.LifeExpectancy = dad.LifeExpectancy;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.MaxEnergy = mom.MaxEnergy;
            }
            else
            {
                child.MaxEnergy = dad.MaxEnergy;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.MaxSize = mom.MaxSize;
            }
            else
            {
                child.MaxSize = dad.MaxSize;
            }
            parentWeight = random.Next(0, 1);
            if(parentWeight >= .5)
            {
                child.MaxHealth = mom.MaxHealth;
            }
            else
            {
                child.MaxHealth = dad.MaxHealth;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Defense = mom.Defense;
            }
            else
            {
                child.Defense = dad.Defense;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Attack = mom.Attack;
            }
            else
            {
                child.Attack = dad.Attack;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.MoveStat = mom.MoveStat;
            }
            else
            {
                child.MoveStat = dad.MoveStat;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.AverageChildren = mom.AverageChildren;
            }
            else
            {
                child.AverageChildren = dad.AverageChildren;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Intelligence = mom.Intelligence;
            }
            else
            {
                child.Intelligence = dad.Intelligence;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.ChemicalAbsorption = mom.ChemicalAbsorption;
            }
            else
            {
                child.ChemicalAbsorption = dad.ChemicalAbsorption;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.Photosynthesis = mom.Photosynthesis;
            }
            else
            {
                child.Photosynthesis = dad.Photosynthesis;
            }
            parentWeight = random.Next(0, 1);
            if (parentWeight >= .5)
            {
                child.DigestiveAbility = mom.DigestiveAbility;
            }
            else
            {
                child.DigestiveAbility = dad.DigestiveAbility;
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
            child.Health = child.MaxHealth;
            return child;
        }
    }
}