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
            MapPixel pixel = AccessPixel(101, 101);
            pixel.Type = "O";

            for(int y = 0; y < maxY -1; y++)
            {
                string line = "";
                for (int x = 0; x < maxX - 1; x++)
                {
                    line+=AccessPixel(x, y).Type;
                }
                Console.WriteLine(line);
            }
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
            MapPixel pixel = pixels[x + (y * maxX)];

            return pixel;
        }

        public void GenerateLake(MapPixel centerPixel, Map map)
        {

        }

        public void GenerateVent(MapPixel centerPixel, Map map)
        {

        }
        public void GenerateCliff(MapPixel centerPixel, Map map)
        {

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
