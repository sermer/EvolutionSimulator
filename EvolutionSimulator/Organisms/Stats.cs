using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Organisms
{
    public class Stats
    {
        //changeable via actions(individual life)
        private double health;
        private double size;
        private double storedEnergy;
        private double age;
        private double bmr;

        //based off lifelong overall health
        private double attractiveness; //High stats make it more attractive
        private double movementModifier; //Low stats = slow

        public double Health
        {
            get { return health; }
            set { health = value; }
        }

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public double StoredEnergy
        {
            get { return storedEnergy; }
            set { storedEnergy = value; }
        }

        public double BMR
        {
            get { return bmr; }
            set { bmr = value; }
        }

        public double Age
        {
            get { return age; }
            set { age = value; }
        }

        //based off lifelong overall health
        public double Attractiveness
        {
            get { return attractiveness; }
            set { attractiveness = value; }
        }

        public double MovementBoost
        {
            get { return movementModifier; }
            set { movementModifier = value; }
        }
    }
}
