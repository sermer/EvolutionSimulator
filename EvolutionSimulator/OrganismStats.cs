using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvolutionSimulator
{
    public class OrganismStats
    {
        //fixed variables
        private string uniqueID;
        //private Tuple<ID, ID> parents;//<Mother,Father>

        //changeable via evolution(long term)
        private float maxHealth;
        private float lifeExpectancy;
        private float maxSize;
        private float maxEnergy;
        private float defense;
        private float attack;
        private float moveStat;
        private float averageChildren;
        private float intelligence;

        //energy collection
        private float chemicalAbsorption;
        private float photosynthesis;
        private float digestiveAbility;

        //changeable via actions(individual life)
        private float health;
        private float size;
        private float storedEnergy;
        private float age;

        //based off lifelong overall health
        private float attractiveness;
        private float movementBoost;

        //for map
        private int xCoordinate;
        private int yCoordinate;
        private int moveOrder;


        //fixed variable
        public string UniqueID
        {
            get { return uniqueID; }
            set { uniqueID = value; }
        }

        // public Tuple<ID,ID> Parents
        // {
        //     get { return uniqueID; }
        //     set { uniqueID = value; }
        // }

        //changeable via evolution(long term)
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
            get { return movementBoost; }
            set { movementBoost = value; }
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

        public static OrganismStats createLife()
        {
            OrganismStats org = new OrganismStats();
            org.chemicalAbsorption = 1;
            org.moveStat = 1;
            org.health = 1;
            return org;
        }
    }
}