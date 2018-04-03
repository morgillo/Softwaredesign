using System;

namespace Aufgabe1._1
{
 
    class Program
    {
    static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
    static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
    static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };

        static void Main(string[] args)
        {
        sentence("");
        Console.ReadLine();
        }

        static void sentence(string randomSentence)
        {
            for ( int i = 0; i <= 4; i++)
            {
                Console.WriteLine(subjects[randomSub()] + " " + verbs[randomVerb()] + " " + objects[randomObj()])
            }

        }

        static int randomSub()
        {
            Random s = new Random();
            int r = s.Next(0, subjects.Length);
            return r;
        }

           static int randomVerb()
        {
            Random v = new Random();
            int r = s.Next(0, verbs.Length);
            return r;
        }

           static int randomObj()
        {
            Random o = new Random();
            int r = s.Next(0, objects.Length);
            return r;
        }


    }
}