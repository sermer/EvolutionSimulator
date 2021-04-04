using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.World
{
    public class Streams
    {
        /*          Logic
         *      Streams can start from any existing water source or from the edges. Lakes should have a random chance to spawn one...
         *      If z is being used, they can only flow from higher z levels to equal or lower z levels. Could also determine the width(steep = narrow, flat = wide)
         *      
         *      Streams can be broken down into segments. A segment will either be straight, turn 90 degrees clockwise, or turn 90 degrees counter-clockwise
         *      Each turn has a variable radius and the stream can only turn in the same direction twice in a row.
         *      
         *      Once a river meets another body of water, stop the stream. Same for the edge of the map.
         */

        public void StartStream(MapPixel startingPixel)
        {
            Stream stream = new Stream(startingPixel);
            GlobalVariables.world.SetMapPixel(startingPixel, "s");


        }
        /// <summary>
        /// Calculates the next segment of the stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>false = end of stream, true = able to continue</returns>
        private bool CalculateSegment(Stream stream)
        {
            Random rand = new Random();
            int turnType = rand.Next(0, 4); //1 = clockwise, 2 = counter-clockwise, else = straight
            while (!stream.IsTurnPossible(turnType))
            {
                turnType = rand.Next(0, 4);
            }

            int turnRadius = rand.Next(2, 5);




            return true;
        }

        private class Stream
        {

            public MapPixel StartingPixel { get; }

            public MapPixel CurrentPixel { get; set; }

            public int ClockwiseTurns { get; set; }

            public Stream(MapPixel startingPixel)
            {
                StartingPixel = startingPixel;
                CurrentPixel = startingPixel;
                ClockwiseTurns = 0;
            }

            public bool IsTurnPossible(int turnType)
            {
                switch (turnType)
                {
                    case 1:
                        if (ClockwiseTurns < 2)
                        {
                            ClockwiseTurns++;
                            return true;
                        }
                        return false;
                    case 2:
                        if (ClockwiseTurns > -2)
                        {
                            ClockwiseTurns--;
                            return true;
                        }
                        break;
                    default:
                        return true;
                }
                return true;
            }
        }
    }
}
