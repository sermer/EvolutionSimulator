using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EvolutionSimulator.Organisms;

namespace EvolutionSimulator
{
    public class Organism
    {
        public DNA dna = new DNA();

        //changeable via actions(individual life)
        private float health;
        private float size;
        private float storedEnergy;
        private float age;

        //based off lifelong overall health
        private float attractiveness; //High stats make it more attractive
        private float movementModifier; //Low stats = slow

        //for map
        private int xCoordinate;
        private int yCoordinate;
        private int moveOrder;


        //fixed variable

        // public Tuple<ID,ID> Parents
        // {
        //     get { return uniqueID; }
        //     set { uniqueID = value; }
        // }

        //changeable via actions(individual life)
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

        //for map
        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        public int MoveOrder
        {
            get { return moveOrder; }
            set { moveOrder = value; }
        }

        public static Organism createLife()
        {
            Organism org = new Organism();
            org.dna.ChemicalAbsorption = 1;
            org.dna.MoveStat = 1;
            org.health = 1;
            return org;
        }
    }
}