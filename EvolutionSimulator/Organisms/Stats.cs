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
        private float health;
        private float size;
        private float storedEnergy;
        private float age;

        //based off lifelong overall health
        private float attractiveness; //High stats make it more attractive
        private float movementModifier; //Low stats = slow

        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public float StoredEnergy
        {
            get { return storedEnergy; }
            set { storedEnergy = value; }
        }

        public float Age
        {
            get { return age; }
            set { age = value; }
        }

        //based off lifelong overall health
        public float Attractiveness
        {
            get { return attractiveness; }
            set { attractiveness = value; }
        }

        public float MovementBoost
        {
            get { return movementModifier; }
            set { movementModifier = value; }
        }
    }
}
