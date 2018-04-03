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
            Random r0 = new Random ();
            Random r1 = new Random ();
            Random r2 = new Random ();

            for ( int i = 0; i <= 4; i++)
            {
                Console.WriteLine(subjects[randomSub()] + " " + verbs[randomVerb()] + " " + objects[randomObj()]);
                if 
            }
            
            static randomSub()
            {
                return r0.Next(0, subjects.Length);
            }

            static randomVerb()
            {
                return r1.Next(0, verbs.Length);
            }

            static randomObj()
            {
                return r2.Next(0, objects.Lenght);
            }

        }
    }
}