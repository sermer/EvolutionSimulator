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
        //Any single DNA attribute can range in value from 0 to 100
        private int maxHealth = 0;
        private int maxSize = 0;
        private int maxEnergy = 0;
        private int defense = 0;
        private int attack = 0;
        private int moveStat = 0;
        private int averageChildren = 0;
        private int intelligence = 0;
        private int attractiveness = 0;

        //energy collection(how does it eat?)
        private int chemicalAbsorption = 0;
        private int photosynthesis = 0;
        private int digestiveAbility = 0;

        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public int MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        public int MaxEnergy
        {
            get { return maxEnergy; }
            set { maxEnergy = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int MoveStat
        {
            get { return moveStat; }
            set { moveStat = value; }
        }

        public int AverageChildren
        {
            get { return averageChildren; }
            set { averageChildren = value; }
        }

        public int Attractiveness
        {
            get { return attractiveness; }
            set { attractiveness = value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }

        //energy collection
        public int ChemicalAbsorption
        {
            get { return chemicalAbsorption; }
            set { chemicalAbsorption = value; }
        }

        public int Photosynthesis
        {
            get { return photosynthesis; }
            set { photosynthesis = value; }
        }

        public int DigestiveAbility
        {
            get { return digestiveAbility; }
            set { digestiveAbility = value; }
        }
    }
}
