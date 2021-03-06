using EvolutionSimulator.World;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.UI
{
    class ImportExport
    {
        public static void SavePNG(string saveDirectory)
        {
            Map map = GlobalVariables.world;
            using (Bitmap b = new Bitmap(map.maxX, map.maxY))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    SolidBrush rockBrush = new SolidBrush(Color.Gray);
                    SolidBrush waterBrush = new SolidBrush(Color.Blue);
                    SolidBrush ventBrush = new SolidBrush(Color.Black);
                    //g.Clear(Color.Green);
                    for (int y = 0; y < map.maxY - 1; y++)
                    {
                        string line = "";
                        for (int x = 0; x < map.maxX - 1; x++)
                        {
                            string pixelType = map.AccessPixel(x, y).Type;

                            switch (pixelType)
                            {
                                case "r":
                                    g.FillRectangle(rockBrush, x, y, 1, 1);
                                    break;
                                case "l":
                                    g.FillRectangle(waterBrush, x, y, 1, 1);
                                    break;
                                case "v":
                                    g.FillRectangle(ventBrush, x, y, 1, 1);
                                    break;
                            }
                                
                                    
                        }
                        Console.WriteLine(line);
                    }


                }

                Directory.CreateDirectory(saveDirectory);

                //Need to change map to use run parameters
                string filename = saveDirectory + "\\map.png";
                b.Save(filename, ImageFormat.Png);
            }
        }

        public static void LoadPNG(string saveDirectory)
        {
            
        }

        public static void SaveRunInfo()
        {

        }
        public static void LoadRunInfo()
        {

        }
        public static void SaveWorldInfo()
        {

        }
        public static void LoadWorldInfo()
        {

        }
    }
}
