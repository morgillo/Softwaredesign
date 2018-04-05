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
                Console.WriteLine(subjects[randomSub(r0)] + " " + verbs[randomVerb(r1)] + " " + objects[randomObj(r2)]);
            }
        }
        
          static int randomSub()
            {
                 Random r0 = new Random ();
                return r0.Next(0, subjects.Length);
            }

            static int randomVerb()
            {
                Random r1 = new Random ();
                return r1.Next(0, verbs.Length);
            }

            static int randomObj()
            {
                Random r2 = new Random ();

                return r2.Next(0, objects.Length);
            }
    }
}