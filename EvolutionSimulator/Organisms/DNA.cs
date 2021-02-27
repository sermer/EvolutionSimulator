using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Organisms
{
    public class DNA
    {
        //DNA is determined by the parents and impacts the organisms abilities
        private float maxHealth = 0;
        private float lifeExpectancy = 0;
        private float maxSize = 0;
        private float maxEnergy = 0;
        private float defense = 0;
        private float attack = 0;
        private float moveStat = 0;
        private float averageChildren = 0;
        private float intelligence;

        //energy collection(how does it eat?)
        private float chemicalAbsorption = 0;
        private float photosynthesis = 0;
        private float digestiveAbility = 0;
        private float attractiveness = 0;
        /*public DNA()
        {
            MaxHealth = 0;
            LifeExpectancy = 0;
            MaxSize = 0;
            MaxEnergy = 0;
            Defense = 0;
            Attack = 0;
            MoveStat = 0;
            AverageChildren = 0;
            Intelligence = 0;
            ChemicalAbsorption = 0;
            Photosynthesis = 0;
            DigestiveAbility = 0;
        }*/

        public float MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        public float LifeExpectancy
        {
            get { return lifeExpectancy; }
            set { lifeExpectancy = value; }
        }

        public float MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        public float MaxEnergy
        {
            get { return maxEnergy; }
            set { maxEnergy = value; }
        }

        public float Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public float Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public float MoveStat
        {
            get { return moveStat; }
            set { moveStat = value; }
        }

        public float AverageChildren
        {
            get { return averageChildren; }
            set { averageChildren = value; }
        }
        public float Attractiveness
        {
            get { return attractiveness; }
            set { attractiveness = value; }
        }

        public float Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }

        //energy collection
        public float ChemicalAbsorption
        {
            get { return chemicalAbsorption; }
            set { chemicalAbsorption = value; }
        }

        public float Photosynthesis
        {
            get { return photosynthesis; }
            set { photosynthesis = value; }
        }

        public float DigestiveAbility
        {
            get { return digestiveAbility; }
            set { digestiveAbility = value; }
        }

        private void Mutate(Organism org)
        {
            //Should mutations be allowed to happen at random or only during breeding?

            Random random = new Random();
            float chance = random.Next(0, 480);
            //~75% chance of no change, equal chance of other changes. 50% up, 50% down
            /*if (chance < 10)
            {
                if (chance < 5)
                {
                    org.dna.MaxHealth += 1;
                }
                else
                {
                    org.MaxHealth -= 1;
                }
            }
            else if (chance < 20)
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
            }*/
        }
    }
}
