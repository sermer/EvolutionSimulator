using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class DayCycleHandler
    {
        public void RunDay()
        {
            int timeOfDay = 0;

            Random rand = new Random();

            for (var i = 0; i <= 12; i++)
            {
                if (i < 2)
                {
                    GlobalVariables.timeOfDay = "Dawn";
                }
                else if (i + GlobalVariables.season < 8)
                {
                    GlobalVariables.timeOfDay = "Day";
                }
                else if (i + GlobalVariables.season < 10)
                {
                    GlobalVariables.timeOfDay = "Dusk";
                }
                else
                {
                    GlobalVariables.timeOfDay = "Night";
                }

                foreach (Organism org in GlobalVariables.livingOrganisms.ToList())
                {
                    if (!org.isAlive)
                    {
                        continue;
                    }

                    org.InteractWithEnvironment();

                    if (rand.Next(0, 100) < 1)
                    {
                        //small chance of DNA mutating each time period
                        org.Mutate();
                    }
                }

                //Begin Day, 12 "hours", day night cycle determined by season
                timeOfDay++;
            }
            //Day is over
            timeOfDay = 0;
            GlobalVariables.day++;
            DayPassed();
        }

        private void DayPassed()
        {
            if (GlobalVariables.seasonWaning)
            {
                GlobalVariables.season += 0.1;
                if (GlobalVariables.season >= 2.4)
                {
                    GlobalVariables.seasonWaning = false;
                }
            }
            else
            {
                GlobalVariables.season -= 0.1;
                if (GlobalVariables.season <= -2.4)
                {
                    GlobalVariables.seasonWaning = true;
                }
            }
        }
    }
}
