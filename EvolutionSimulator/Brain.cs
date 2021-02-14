using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class Brain
    {
        //Handle decision making here
        public static OrganismStats Move(OrganismStats org)
        {
            return org;
        } 
        public static OrganismStats Mutate(OrganismStats org)
        {
            Random random = new Random();
            float chance = random.Next(0, 480);
            //~75% chance of no change, equal chance of other changes. 50% up, 50% down
            //
            if (chance < 10)
            {
                if(chance < 5)
                {
                    org.MaxHealth += 1;
                }
                else
                {
                    org.MaxHealth -= 1;
                }
            }
            else if(chance < 20)
            {
                if (chance < 15)
                {
                    org.LifeExpectancy += 1;
                }
                else
                {
                    org.LifeExpectancy -= 1;
                }
            }
            else if (chance < 30)
            {
                if (chance < 25)
                {
                    org.MaxSize += 1;
                }
                else
                {
                    org.MaxSize -= 1;
                }
            }
            else if (chance < 40)
            {
                if (chance < 35)
                {
                    org.MaxEnergy += 1;
                }
                else
                {
                    org.MaxEnergy -= 1;
                }
            }
            else if (chance < 50)
            {
                if (chance < 45)
                {
                    org.Defense += 1;
                }
                else
                {
                    org.Defense -= 1;
                }
            }
            else if (chance < 60)
            {
                if (chance < 55)
                {
                    org.Attack += 1;
                }
                else
                {
                    org.Attack -= 1;
                }
            }
            else if (chance < 70)
            {
                if (chance < 65)
                {
                    org.MoveStat += 1;
                }
                else
                {
                    org.MoveStat -= 1;
                }
            }
            else if (chance < 80)
            {
                if (chance < 75)
                {
                    org.AverageChildren += 1;
                }
                else
                {
                    org.AverageChildren -= 1;
                }
            }
            else if (chance < 90)
            {
                if (chance < 85)
                {
                    org.Intelligence += 1;
                }
                else
                {
                    org.Intelligence -= 1;
                }
            }
            else if (chance < 100)
            {
                if (chance < 95)
                {
                    org.ChemicalAbsorption += 1;
                }
                else
                {
                    org.ChemicalAbsorption -= 1;
                }
            }
            else if (chance < 110)
            {
                if (chance < 105)
                {
                    org.Photosynthesis += 1;
                }
                else
                {
                    org.Photosynthesis -= 1;
                }
            }
            else if (chance < 120)
            {
                if (chance < 115)
                {
                    org.DigestiveAbility += 1;
                }
                else
                {
                    org.DigestiveAbility -= 1;
                }
            }

            return org;
        }
    }
}
