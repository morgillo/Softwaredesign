using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class Field
    {
        public static char[] gameData = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static void PrintGameData()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameData[0], gameData[1], gameData[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameData[3], gameData[4], gameData[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameData[6], gameData[7], gameData[8]);
            Console.WriteLine("     |     |      ");
        }
    }
}