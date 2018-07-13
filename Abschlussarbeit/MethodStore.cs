using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    public class MethodStore
    {
        public static string[] separatedInput;
        public static bool isFightCase = false;
        public static GameData.Character _enemy;

        public static void GameIntro()
        {
            Console.WriteLine("You wake up in your father's old study. It's dark and dusty. The last thing you can remember is ...");
            GameData.CreateRoom();
            GameData.createCharater();
        }
        public static void Talk()
        {
            Console.WriteLine("{0}: 'Youre brother needs help. To defeat the Goyls King you better equipe. Did you already equipe?", GameData.characters["Fox"]._name);
            MethodStore.talkCases();
        }
        public static void talkCases()
        {
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                case "yes":
                    Console.WriteLine("{0}: 'Perfect. Go ahead and good Luck!'");
                    break;

                case "n":
                case "no":
                    Console.WriteLine("{0}:'You better equipe before entering.' ");
                    break;

                default:
                    Console.WriteLine("{0}:'I didn't understand. What did you say? ' ");
                    talkCases();
                    break;

            }
        }

        public static void Help()
        {
            foreach (var command in GameData.commands)
                Console.WriteLine(command);
        }

        public static void CheckCases()// bool 
        {   
           // MethodStore.CheckEnemy();
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine().ToLower();
            SplitInput(input);
            CheckFightCases(separatedInput);
        }

        public static Array SplitInput(string input) // input wird in der anderen Methode eingelesen und zum splitten übergeben
        {
            //string input = Console.ReadLine().ToLower();

            char[] splitter = { ' ' };
            separatedInput = input.Split(splitter);

            /* var method = separatedInput[0];
            var parameter = separatedInput[1]; 
             for (int i = 0; i < separatedInput.Length; i++)
            Console.WriteLine(separatedInput[i]); */
            return separatedInput;
        }

        public static void CheckFightCases(string[] input)
        {
            separatedInput = input;

            switch (separatedInput[0])
            {
                case "u":
                case "use":
                    //Use(string [] input);
                    break;

                case "a":
                case "arm":
                    //Arm(string [] input);
                    break;

                case "i":
                case "inventory":
                    //DisplayInventory();
                    break;

                case "q":
                case "quit":
                    //QuitGame();
                    break;

                //if enemy im Raum 
                /* default:
                    Console.WriteLine("This is not possible. Try again. Valid inputs are: arm(a) <item>, use(u) <item>, inventory(i), quit(q)");
                    break;
                     else*/

                default:
                    if (isFightCase == true)
                    {
                        Fight(_enemy, separatedInput);
                    }
                    else
                        CheckNonFightCases(separatedInput);
                    break;
            }
        }


        public static void CheckNonFightCases(string[] input)
        {
            separatedInput = input;

            switch (separatedInput[0])
            {
                case "h":
                case "help":
                    //Use(string [separatedInput[1]] input);
                    break;

                case "l":
                case "look":
                    Console.WriteLine("in loook");
                    //Arm(string [separatedInput[1]] input);
                    break;

                case "t":
                case "take":
                    //DisplayInventory();
                    break;

                case "d":
                case "drop":
                    //Drop();
                    break;

                case "n":
                case "north":
                    if (GameData.characters["Reckless"]._currentLocation.north != null)
                    {

                        GameData.characters["Reckless"]._currentLocation = GameData.characters["Reckless"]._currentLocation.north;
                        GameData.Room.RoomDescription(GameData.characters["Reckless"]._currentLocation);

                    }
                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "e":
                case "east":
                    if (GameData.characters["Reckless"]._currentLocation.east != null)
                    {
                        GameData.characters["Reckless"]._currentLocation = GameData.characters["Reckless"]._currentLocation.east;
                        GameData.Room.RoomDescription(GameData.characters["Reckless"]._currentLocation);
                    }
                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "s":
                case "south":
                    if (GameData.characters["Reckless"]._currentLocation.south != null)
                    {
                        GameData.characters["Reckless"]._currentLocation = GameData.characters["Reckless"]._currentLocation.south;
                        GameData.Room.RoomDescription(GameData.characters["Reckless"]._currentLocation);
                    }

                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "w":
                case "west":
                    if (GameData.characters["Reckless"]._currentLocation.west != null)
                    {
                        GameData.characters["Reckless"]._currentLocation = GameData.characters["Reckless"]._currentLocation.west;
                        GameData.Room.RoomDescription(GameData.characters["Reckless"]._currentLocation.west);
                    }

                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                default:
                    Console.WriteLine("This is not possible. Try again.");
                    break;
            }
        }
        public static void CheckEnemy()
        {
            foreach (var charackter in GameData.characters.Values)
            {
                if (charackter._currentLocation == GameData.characters["Reckless"]._currentLocation)
                {
                    string name = charackter._name;
                    switch (name)
                    {
                        case "Goyl":
                            _enemy = charackter;
                            isFightCase = true;
                            Console.WriteLine("There is an angry Goyl. He's coming toward you. Fight him!");
                            CheckCases();
                            break;

                        case "Kamien":
                            _enemy = charackter;
                            isFightCase = true;
                            Console.WriteLine("There is an angry Goyl. He's coming toward you. Fight him!");
                            CheckCases();
                            break;

                        case "Fox":
                            Talk();
                            CheckCases();
                            break;

                        default:
                            CheckCases();
                            break;
                    }
                }
            }
        }
        public static void Fight(GameData.Character enemy, string[] input)
        {
            enemy = _enemy;
            switch(input[0])

            enemy._lifepoints = enemy._lifepoints - GameData.characters["Reckless"]._hitpoints;
            Console.WriteLine("Test:"+ enemy + ": " + _enemy._lifepoints);
        }
    }


}

