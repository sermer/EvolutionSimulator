using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class DayCycleHandler
    {
        public List<Organism> RunDay(List<Organism> aliveOrgs)
        {
            int timeOfDay = 0;
            double season = EvolutionSimulator.GlobalVariables.season;
            int day = EvolutionSimulator.GlobalVariables.day;
            bool seasonWaxing = EvolutionSimulator.GlobalVariables.seasonWaxing;
            string[] timeWindow = new[] { "Dawn", "Day", "Dusk", "Night" };

            for (var i = 0; i <= 12; i++)
            {
                //Begin Day, 12 "hours", day night cycle determined by season
                

                /*if (i < 9 - season)
                {
                    //daytime
                    foreach(Organism org in aliveOrgs)
                    {
                        Brain.Move(org);
                    }
                }
                else
                {
                    //nighttime
                    foreach (Organism org in aliveOrgs)
                    {
                        Brain.Move(org);
                    }
                }*/
                timeOfDay++;
            }
            //Day is over
            timeOfDay = 0;
            day++;

            foreach (Organism org in aliveOrgs)
            {
                //Brain.Mutate(org);
                
               //Console.WriteLine(day + " " + org.dna.MaxHealth);
                
            }
            DayPassed();
            return aliveOrgs;
        }

        private void DayPassed()
        {
            if (GlobalVariables.seasonWaxing)
            {
                //Actually waning but whatever...
                GlobalVariables.season += 0.1;
                if (GlobalVariables.season >= 2.4)
                {
                    GlobalVariables.seasonWaxing = false;
                }
            }
            else
            {
                GlobalVariables.season -= 0.1;
                if (GlobalVariables.season <= -2.4)
                {
                    GlobalVariables.seasonWaxing = true;
                }
            }
        }
    }
}
