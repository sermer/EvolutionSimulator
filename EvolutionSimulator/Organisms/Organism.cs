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
        public Stats stats = new Stats();

        private int moveOrder;
        private int xCoordinate;
        private int yCoordinate;
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
            org.stats.Health = 1;
            return org;
        }
    }
}