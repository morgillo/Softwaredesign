using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class Checking
    {
        public static int input;
        public static int inputChecked;
        public static void CheckInput()
        {
        List<int> _takenPositions = new List<int>() { };

            if (_takenPositions.Contains(input))
                inputChecked = 0;
            if (input <= 9 && input >= 1)
            {
                _takenPositions.Add(input);
                inputChecked = 1;
            }
            else
                inputChecked = -1;
        }

        public static void CheckWin()
        {
            bool _win = false;

            int[][] winCases =
            {
                new int[] {0, 1, 2},
                new int[] {3, 4, 5},
                new int[] {6, 7, 8},

                new int[] {0, 3, 6},
                new int[] {1, 4, 7},
                new int[] {2, 5, 8},

                new int[] {0, 4, 8},
                new int[] {2, 4, 6}
            };

            if (Moves.count >= 4)
            {
                for (int i = 0; i <= winCases.Length - 1; i++)
                {
                    if (Field.gameData[winCases[i][0]] == Moves.Turn(Moves.count) && Field.gameData[winCases[i][1]] == Moves.Turn(Moves.count) && Field.gameData[winCases[i][2]] == Moves.Turn(Moves.count))
                    {
                        _win = true;
                    }
                }
            }

            if (_win == true)
            {
                Console.WriteLine("Player "+ Moves.Turn(Moves.count)+ " has won!");
                Console.WriteLine("----------------");
                Field.PrintGameData();
                Environment.Exit(0);
            }
        }
    }
}