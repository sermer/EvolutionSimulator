using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator
{
    class DayCycleHandler
    {
        public static List<OrganismStats> RunDay(List<OrganismStats> aliveOrgs)
        {
            int timeOfDay = 0;
            double season = EvolutionSimulator.IntitializeVariables.season;
            int day = EvolutionSimulator.IntitializeVariables.day;
            bool seasonWaxing = EvolutionSimulator.IntitializeVariables.seasonWaxing;

            for (var i = 0; i <= 12; i++)
            {
                //Begin Day, 12 "hours", day night cycle determined by season
                if (i < 9 - season)
                {
                    //daytime
                    foreach(OrganismStats org in aliveOrgs)
                    {
                        Brain.Move(org);
                    }
                }
                else
                {
                    //nighttime
                    foreach (OrganismStats org in aliveOrgs)
                    {
                        Brain.Move(org);
                    }
                }
                timeOfDay++;
            }
            //Day is over
            timeOfDay = 0;
            day++;

            foreach (OrganismStats org in aliveOrgs)
            {
                Brain.Mutate(org);
                
                
                Console.WriteLine(day + " " + org.MaxHealth);
                
            }

            if (seasonWaxing)
            {
                //Actually waning but whatever...
                season += 0.1;
                if(season >= 2.4)
                {
                    seasonWaxing = false;
                }
            }
            else
            {
                season -= 0.1;
                if (season <= -2.4)
                {
                    seasonWaxing = true;
                }
            }
            EvolutionSimulator.IntitializeVariables.seasonWaxing = seasonWaxing;
            EvolutionSimulator.IntitializeVariables.day = day;
            EvolutionSimulator.IntitializeVariables.season = season;
            return aliveOrgs;
        }
    }
}
