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
        private string[] SupportedPixelTypes = { "r", "l", "v", "s" };
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

            int pixelCount = maxX * maxY;

            int featureCount = rand.Next(Convert.ToInt32(Math.Pow(pixelCount, .25)), Convert.ToInt32(Math.Pow(pixelCount, .33)));
            for(int i = 0; i < featureCount - 1; i++)
            {
                //Generate lakes
                int x = rand.Next(maxX);
                int y = rand.Next(maxY);

                int lakeRadius = rand.Next(rand.Next(Convert.ToInt32(Math.Pow(pixelCount, .1)), Convert.ToInt32(Math.Pow(pixelCount, .33))));
                MapPixel lakeCenter = AccessPixel(x, y);
                GenerateLake(lakeCenter, lakeRadius);
            }

            GlobalVariables.firstVentLocation = null; //resets each world generation
            featureCount = rand.Next(Convert.ToInt32(Math.Pow(pixelCount, .3)), Convert.ToInt32(Math.Pow(pixelCount, .4)));
            for (int i = 0; i < featureCount - 1; i++)
            {
                //Generate thermal vents
                int x = rand.Next(maxX);
                int y = rand.Next(maxY);

                int ventRadius = rand.Next(2, 5);
                MapPixel ventCenter = AccessPixel(x, y);
                if(GlobalVariables.firstVentLocation == null)
                {
                    //Set spawn location and guarentee a larger vent
                    GlobalVariables.firstVentLocation = ventCenter;
                    ventRadius = 5;
                }
                GenerateVent(ventCenter, ventRadius);
            }
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

        public bool SetMapPixel(int x, int y, string type)
        {
            if (!SupportedPixelTypes.Contains(type))
            {
                return false;
            }
            AccessPixel(x, y).Type = type;
            return true;
        }

        public bool SetMapPixel(MapPixel pixel, string type)
        {
            if (!SupportedPixelTypes.Contains(type))
            {
                return false;
            }
            pixel.Type = type;
            return true;
        }

        private List<string> DrawCircle(int x, int y, int r)
        {
            //Creates a empty circle with a center at x, y with a radius of r
            double pi = Math.PI;

            //Each item is "x_y"
            List<string> pixelList = new List<string>();

            for (double i = 0; i < 360; i += 0.1)
            {
                double angle = i;
                double x1 = r * Math.Cos(angle * pi / 180);
                double y1 = r * Math.Sin(angle * pi / 180);
                string newPixel = string.Concat(Convert.ToInt32(x + x1), "_", Convert.ToInt32(y + y1));
                if (!pixelList.Contains(newPixel))
                {
                    pixelList.Add(newPixel);
                }
            }

            return pixelList;
        }

        private void GenerateLake(MapPixel centerPixel, int lakeRadius)
        {
            List<string> pixelList = DrawCircle(centerPixel.X, centerPixel.Y, lakeRadius);

            Dictionary<int, CircleBounds> circleBoundsDict = new Dictionary<int, CircleBounds>();

            foreach (string pixel in pixelList)
            {
                string[] xy = pixel.Split('_');
                int x = Convert.ToInt32(xy[0]);
                int y = Convert.ToInt32(xy[1]);

                if (!circleBoundsDict.ContainsKey(y))
                {
                    circleBoundsDict[y] = new CircleBounds(x);
                }
                else
                {
                    CircleBounds cb = circleBoundsDict[y];
                    if (x < cb.MinX)
                    {
                        cb.MinX = x;
                    }
                    else if(x > cb.MaxX)
                    {
                        cb.MaxX = x;
                    }
                }

                if (x < 0 || x >= maxX)
                {
                    //Outside of map
                    continue;
                }
                if (y < 0 || y >= maxY)
                {
                    //Outside of map
                    continue;
                }
                AccessPixel(x, y).Type = "l";
            }

            for (int x = centerPixel.X - lakeRadius; x < lakeRadius + centerPixel.X; x++)
            {
                if (x < 0 || x >= maxX)
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

                    if(x > circleBoundsDict[y].MinX && x < circleBoundsDict[y].MaxX) 
                    {
                        AccessPixel(x, y).Type = "l";
                    }
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
            List<Organism> primordialSoup = new List<Organism>();
            for(int i = 0; i < spawnCount; i++)
            {
                primordialSoup.Add(Organism.CreateLife());
            }
            return primordialSoup;
        }
    }

    public class MapPixel
    {
        public int X { get;}
        public int Y { get;}
        public int Z { get;}
        public string Type { get; set; }
        public int TypeStrength { get; set; } //from 0-100. Used for things like Vents

        public List<Organism> PixelContents = new List<Organism>(); //Should orgs in a pixel be tracked here? Would make interactions easier...

        public MapPixel(int x, int y, int z = 0, string type = "r", int typeStrength = 100)
        {
            X = x;
            Y = y;
            Z = z;
            Type = type;
            TypeStrength = typeStrength;
        }
    }

    public class CircleBounds
    {
        //The bounds of each line(y) of the drawn circle
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public CircleBounds(int x)
        {
            MinX = x;
            MaxX = x;
        }
    }

}
