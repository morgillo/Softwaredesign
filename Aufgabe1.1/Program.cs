using System;

namespace Aufgabe1._1
{
 
    class Program
    {
        double pi = 3.14;
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte w, k oder o eingeben:"); 
            string buchstabe = Console.ReadLine();
            Console.WriteLine("Gebe nun eine Zahl ein:");
            string zahl = Console.ReadLine();

            double d = double.Parse(zahl);

            string cube = "w";
            string sphere = "k";
            string oktaeder = "o";

            if (buchstabe == cube)
            {
                Console.WriteLine("Der Würfel hat eine Oberfläche von " + getCubeSurface(d));
                Console.WriteLine("Der Würfel hat ein Volumen von " + getCubeVolume(d));
                Console.ReadLine();
            }

            if (buchstabe == "sphere")
            {
                Console.WriteLine("Die Kugel hat eine Oberfläche von " + getSphereSurface(d));
                Console.WriteLine("Der Kugel hat ein Volumen von " + getSphereVolume(d));
                Console.ReadLine();
            }

             if (buchstabe == "oktaeder")
            {
                Console.WriteLine("Das Oktaeder hat eine Oberfläche von " + getOktaederSurface(d));
                Console.WriteLine("Der Oktaeder hat ein Volumen von " + getOktaederVolume(d));
                Console.ReadLine();
            }


        
        }

        static double getCubeSurface (double d)
        {
            double surface = d * d * 6;
            return(surface);
        }
        static double getSphereSurface (double d)
        {
            double pi = 3.14;
            double surface = pi * d * d;
            return(surface);
        }

         static double getOktaederSurface (double d)
        {
            double surface = 2 * Math.Sqrt(3) * d * d;
            return(surface);
        }
  
          static double getCubeVolume (double d)
        {
            double volume = d * d * d;
            return(volume);
        }

             static double getSphereVolume (double d)
        {
            double pi = 3.14;
            double volume = (pi * d * d * d) / 6;
            return(volume);
        }

             static double getOktaederVolume (double d)
        {
            double volume = (Math.Sqrt(2) * d * d * d) / 3;
            return(volume);
        }



    }
}
