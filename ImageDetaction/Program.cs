using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDetaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Template image path");
            string img1 = Console.ReadLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            while (true)
            {
                Console.WriteLine("Enter image path to compare");
                string img2 = Console.ReadLine();
                Console.WriteLine(
                    Compare(img1,img2)
                    );
                Console.WriteLine("----------------");
            }
           

        }
        static bool Compare(string img1,string img2)
        {
            Image<Bgr, byte> Image1 = new Image<Bgr, byte>(img2); //Your first image
            Image<Bgr, byte> Image2 = new Image<Bgr, byte>(img1); //Your second image

            double Threshold = 0.8; //set it to a decimal value between 0 and 1.00, 1.00 meaning that the images must be identical

            Image<Gray, float> Matches = Image1.MatchTemplate(Image2, TemplateMatchingType.CcoeffNormed);

            for (int y = 0; y < Matches.Data.GetLength(0); y++)
            {
                for (int x = 0; x < Matches.Data.GetLength(1); x++)
                {
                    if (Matches.Data[y, x, 0] >= Threshold) //Check if its a valid match
                    {
                        //Image2 found within Image1
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
