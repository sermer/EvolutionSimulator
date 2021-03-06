using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.World
{
    public class Map
    {
        public int maxX;
        public int maxY;
        public int maxZ;
        public List<MapPixel> pixels = new List<MapPixel>();

        public void GenerateWorld(int xDimension, int yDimension, int zDimension)
        {
            /*
         * The "world" will be a pixel grid which generates a PNG that will then get displayed in the main form.
         * The size of the world will be determined either a couple textboxes or by using the screen dimensions.
         * At the end of each time window, a PNG representation of the world will be saved + displayed in the interface.
         * 
         * Each pixel will contain info about geography(color), amount of life in that pixel(hue), etc.
         * 
         * The user will be able to interact with the world by doing things with the form. 
         *       If the user shakes it, cause an earthquake(tsunamis?, changing vent locations?)
         *       If the user clicks it, throw down an astroid there. Kills orgs and leaves a crater?
         * */
            maxX = xDimension;
            maxY = yDimension;
            maxZ = zDimension;

            pixels = GenerateEmptyMap();
            Random rand = new Random();

            //Should probably scale features with map dimensions...
            int featureCount = rand.Next(2, 10);
            for(int i = 0; i < featureCount - 1; i++)
            {
                //Generate lakes
                int x = rand.Next(maxX);
                int y = rand.Next(maxY);

                int lakeRadius = rand.Next(2, 10);
                MapPixel lakeCenter = AccessPixel(x, y);
                GenerateLake(lakeCenter, lakeRadius);
            }

            featureCount = rand.Next(4, 8);
            for (int i = 0; i < featureCount - 1; i++)
            {
                //Generate thermal vents
                int x = rand.Next(maxX);
                int y = rand.Next(maxY);

                int ventRadius = rand.Next(2, 4);
                MapPixel ventCenter = AccessPixel(x, y);
                GenerateVent(ventCenter, ventRadius);
            }


            //"Draws" the map in the console
            /*for (int y = 0; y < maxY -1; y++)
            {
                string line = "";
                for (int x = 0; x < maxX - 1; x++)
                {
                    line+=AccessPixel(x, y).Type;
                }
                Console.WriteLine(line);
            }*/
            //GenerateVent()
        }

        public List<MapPixel> GenerateEmptyMap()
        {
            Map emptyMap = new Map();
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    emptyMap.pixels.Add(new MapPixel(x, y));
                    //Console.WriteLine("X:" + x + " Y:" + y + "      emptyMap.X:" + emptyMap.pixels.Last().X + " emptyMap.Y:" + emptyMap.pixels.Last().Y + "         #" + emptyMap.pixels.Count);
                }
            }
            return emptyMap.pixels;
        }

        public MapPixel AccessPixel(int x, int y)
        {
            if(x < 0 || x >= maxX || y < 0 || y >= maxY)
            {
                return null;
            }

            return pixels[x + (y * maxX)];
        }

        private void DrawCircle(int x, int y, int r)
        {
            double pi = Math.PI;
            double i, angle, x1, y1;

            for (i = 0; i < 360; i += 0.1)
            {
                angle = i;
                x1 = r * Math.Cos(angle * pi / 180);
                y1 = r * Math.Sin(angle * pi / 180);
                //putpixel(x + x1, y + y1);
            }
        }

        private void GenerateLake(MapPixel centerPixel, int lakeRadius)
        {
            //Just a square for now...
            for(int x = centerPixel.X - lakeRadius; x < lakeRadius + centerPixel.X; x++)
            {
                if(x < 0 || x >= maxX)
                {
                    //Outside of map
                    continue;
                }
                for (int y = centerPixel.Y - lakeRadius; y < lakeRadius + centerPixel.Y; y++)
                {
                    if (y < 0 || y >= maxY)
                    {
                        //Outside of map
                        continue;
                    }
                    AccessPixel(x, y).Type = "l";
                }
            }
        }

        private void GenerateVent(MapPixel centerPixel, int ventRadius)
        {
            //Just a square for now...
            for (int x = centerPixel.X - ventRadius; x < ventRadius + centerPixel.X; x++)
            {
                if (x < 0 || x >= maxX)
                {
                    //Outside of map
                    continue;
                }
                for (int y = centerPixel.Y - ventRadius; y < ventRadius + centerPixel.Y; y++)
                {
                    if (y < 0 || y >= maxY)
                    {
                        //Outside of map
                        continue;
                    }
                    AccessPixel(x, y).Type = "v";
                }
            }
        }

        private void GenerateStream()
        {
            //Streams should have a chance to spawn from the edge of a lake and follow a winding path until reaching another stream, another lake, or the edge of the map.
            //They will need to be generated chunk by chunk and will have a random chance to go straight, turn clockwise, or turn counter-clockwise.
            //All turns will need to be tracked so that it doesn't look around and connect with itself(>2 turns in any given direction).

            //Will there be a flow? If so, z values would determine overall direction and turns would be limited to 1 against the z direction(no flowing uphill).
            //Should the stream width be variable? Starting with a default width of 1 or 2 might make this easier...

            //Interactions:
            //Cliffs - Depending on what I want to do with z values this could have different interactions. If no z values or if the z jumps, the stream would need to immediately turn as to not jump the cliff. 
            //          if z values are in play, a lower z value on the other side could cause a waterfall.
            //Vents - Streams should not replace vents but rather go around. Either have the stream go around one side or if the stream width is >=2 it could potentially split and create 2 streams.


        }

        public void GenerateCliff(MapPixel centerPixel)
        {

        }

        public List<Organism> SpawnLife(int spawnCount)
        {
            //Create the initial primordial soup.
            //Should be spawned at a vent and each organism should be able to feed off vents.
            //Starting amount needs to be enough that life always gets a foothold...


            return new List<Organism>();
        }
    }

    public class MapPixel
    {
        public int X { get;}
        public int Y { get;}
        public int Z { get;}
        public string Type { get; set; }
        public int TypeStrength { get; set; } //from 0-100. Used for things like Vents

        public MapPixel(int x, int y, int z = 0, string type = "r", int typeStrength = 100)
        {
            X = x;
            Y = y;
            Z = z;
            Type = type;
            TypeStrength = typeStrength;
        }
    }
}
