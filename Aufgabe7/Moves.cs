using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class Moves
    {
        static char turn;
        public static int count = 0;
        

        public static char Turn(int count)
        {
            if (count % 2 == 0)
                turn = 'x';
            else
                turn = 'o';
            return turn;
        }

        public static void GiveInput()
        {
            
            Console.WriteLine("Player " + Turn(count) + ", please choose fieldnumber."); Turn wird hier versteckt, nicht gut

            try
            {
                if (count <= 9)
                {
                    Checking.input = Convert.ToInt32(Console.ReadLine());
                    Checking.CheckInput();
                }
                else
                {
                    Console.WriteLine("Draw! Game over.");
                    Console.WriteLine("----------------");
                    Field.PrintGameData();
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.WriteLine("Invalid type. Enter a number.");
                GiveInput();
            }

            switch (Checking.inputChecked)  inputChecked ist etwas "versteckt", besser wäre int checked = Checking.CheckInput()
            {
                case 1:     -> 1,0,-1 sind etwas "magische Zahlen", ich muss Code lesen um herauszufinden, was sie bedeuten
                    Field.gameData[Checking.input - 1] = turn;
                    count++;
                    turn++; ?????

                    do
                    {
                        Checking.CheckWin();
                        Console.Clear();
                        Field.PrintGameData();
                        GiveInput();  <- Rekursion für diese Aufgabe eher irreführend
                    }
                    while (count < 9);
                    break;

                case 0:
                    Console.WriteLine("Already taken. Try again!");
                    GiveInput(); <- Dopplung
                    break;

                case -1:
                    Console.WriteLine("Out of Range. Try again!");
                    GiveInput(); <- Dopplung
                    break;
            }
        }
    }
}
