using EvolutionSimulator.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class GlobalVariables
    {
        public static int day;
        public static double season;
        public static string timeOfDay;
        public static bool firstDay = true;
        public static bool seasonWaning = true;

        public static MapPixel firstVentLocation;

        public static List<Organism> livingOrganisms = new List<Organism>();

        public static World.Map world = new World.Map();
    }
}
