using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    public class MethodStore
    {
        public static GameData.Room MyCurrentRoom = GameData.characters["Reckless"]._currentLocation;
        public static string[] separatedInput;
        public static bool isFightCase = false;
        public static GameData.Character _enemy;
        public static int characterNumber;
        public static int InteractionCounter = 0;


        public static void GameIntro()
        {
            Console.WriteLine("You wake up in your father's old study. It's dark and dusty. The last thing you can remember is your brother beeing kidnapped by the Goyls. Save him!");
            GameData.CreateRoom();
            GameData.CreateCharater();
            Look(MyCurrentRoom);
        }

        public static void Look(GameData.Room room)
        {
            room = MyCurrentRoom;

            Console.WriteLine(room._information + Environment.NewLine);
            try
            {
                if (room._roomInv.Count != 0)
                {
                    Console.WriteLine("You see..");
                    foreach (var item in room._roomInv)
                    {
                        Console.WriteLine("a/an " + item._name);
                    }
                }
                else
                    Console.WriteLine("There is no item in this place.");
            }
            catch
            {
                Console.WriteLine("Exception Handle");
            }
        }

        public static void Take(string input)
        {
            input = separatedInput[1];

            GameData.Item foundItem = MyCurrentRoom._roomInv.Find(x => x._name.ToLower().Contains(input));
            if (foundItem != null)
            {
                Console.WriteLine("You added {0} in your inventory.", foundItem._name);
                GameData.characters["Reckless"]._characterInventory.Add(foundItem);
                MyCurrentRoom._roomInv.Remove(foundItem);
            }
            else
            {
                Console.WriteLine("Can't take!");
            }
        }

        public static void Drop(string input)
        {
            input = separatedInput[1];

            GameData.Item foundItem = GameData.characters["Reckless"]._characterInventory.Find(x => x._name.ToLower().Contains(input));
            if (foundItem != null)
            {
                Console.WriteLine("You removed {0} from your inventory.", foundItem._name);
                MyCurrentRoom._roomInv.Add(foundItem);
                GameData.characters["Reckless"]._characterInventory.Remove(foundItem);
            }
            else
            {
                Console.WriteLine("Can't drop!");
            }
        }

        public static void DisplayInventory()
        {
            Console.WriteLine("Take a look at your inventory:");
            if (GameData.characters["Reckless"]._characterInventory.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", "Name", "Type", "Information", "Armed?", "Hit/Heal"));
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                foreach (var item in GameData.characters["Reckless"]._characterInventory)
                {
                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  |  {3,-10}  |  {4,-10}  ", item._name, item._type, item._information, 1, 1));
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Woops! Your inventory is empty...");
            }

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
                    DisplayInventory();
                    break;

                case "q":
                case "quit":
                    QuitGame();
                    break;

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
                    Help();
                    break;

                case "l":
                case "look":
                    Look(MyCurrentRoom);
                    break;

                case "t":
                case "take":
                    Take(separatedInput[1]);
                    break;

                case "d":
                case "drop":
                    Drop(separatedInput[1]);
                    break;

                case "n":
                case "north":
                    if (MyCurrentRoom.north != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.north;
                        EnemyChangeRoom();
                        Look(MyCurrentRoom);
                    }
                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "e":
                case "east":
                    if (MyCurrentRoom.east != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.east;
                        EnemyChangeRoom();
                        Look(MyCurrentRoom);
                    }
                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "s":
                case "south":
                    if (MyCurrentRoom.south != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.south;
                        EnemyChangeRoom();
                        Look(MyCurrentRoom);
                    }

                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "w":
                case "west":
                    if (MyCurrentRoom.west != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.west;
                        EnemyChangeRoom();
                        Look(MyCurrentRoom.west);
                    }

                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                default:
                    Console.WriteLine("This is not possible. Try again.");
                    break;
            }
        }

        public static void EnemyChangeRoom()
        {
            InteractionCounter = 0;

            List<GameData.Room> allRooms = new List<GameData.Room>(GameData.rooms.Values);
            try
            {
                Random rand = new Random();
                int randomIndex = rand.Next(allRooms.Count);
                GameData.characters["Goyl"]._currentLocation = allRooms[randomIndex];
                CountCharacterNumber();
            }
            catch
            {
                Console.WriteLine("Exeption handle.");
            }


        }

        public static bool isInList(string s)
        {
            if (s == GameData.characters["Goyl"]._currentLocation._name)
                return true;
            else
                return false;
        }
        public static void CountCharacterNumber()
        {
            List<string> currentRooms = new List<string>();

            foreach (var character in GameData.characters)
            {
                currentRooms.Add(character.Value._currentLocation._name);
            }

            List<string> sublist = currentRooms.FindAll(isInList);
            characterNumber = sublist.Count;

            if (characterNumber >= 2)
            {
                EnemyChangeRoom();
            }

        }


        public static void CheckEnemy()
        {
            foreach (var character in GameData.characters.Values)
            {
                if (character._currentLocation == MyCurrentRoom)
                {
                    string name = character._name;
                    switch (name)
                    {
                        case "Goyl":
                            if (InteractionCounter == 0)
                            {
                                _enemy = character;
                                isFightCase = true;
                                Console.WriteLine("There is an angry Goyl. He's coming toward you. Defeat him!");
                                CheckCases();
                                InteractionCounter++;
                            }
                            CheckCases();
                            break;

                        case "Kamien":

                            _enemy = character;
                            isFightCase = true;
                            Console.WriteLine("Kamien the King of the Goyls wants to kill you. Fight him!");
                            CheckCases();
                            QuitGame();
                            break;

                        case "Fox":
                            if (InteractionCounter == 0)
                            {
                                Talk();
                                InteractionCounter++;
                            }

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

            input = separatedInput;
            enemy = _enemy;
            switch (input[0])
            {
                case "f":
                case "fight":
                    //hitting the enemy
                    enemy._lifepoints = (float)(Math.Round((enemy._lifepoints - GameData.characters["Reckless"]._hitpoints), 2));
                    if (enemy._lifepoints > 0F)
                    {
                        Console.WriteLine("{0}: 'Outch!' ", enemy._name);
                        Console.WriteLine("The Enemy is still alive. {0} Lifepoints: {1}", _enemy._name, _enemy._lifepoints);
                        // beeing hitted
                        GameData.characters["Reckless"]._lifepoints = (float)(Math.Round((GameData.characters["Reckless"]._lifepoints - _enemy._hitpoints), 2));

                        if (GameData.characters["Reckless"]._lifepoints > 0F)
                        {
                            Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", GameData.characters["Reckless"]._lifepoints);
                        }
                        else
                        {
                            Console.WriteLine("You are dead!");
                            QuitGame();
                        }

                    }
                    else
                    {
                        Console.WriteLine("You defeated the {0}! Great!", enemy._name);
                        if (enemy._characterInventory.Count != 0)
                        {
                            GameData.characters["Reckless"]._characterInventory.Add(enemy._characterInventory[0]);
                            enemy._characterInventory.Remove(enemy._characterInventory[0]);
                            Console.WriteLine("Awesome! You snatched the {0}",enemy._characterInventory[0]);
                        }
                        isFightCase = false;
                        enemy._lifepoints = 1F;
                    }
                    CheckCases();
                    break;

                default:
                    Console.WriteLine("That's not possible. You were too slow.");
                    GameData.characters["Reckless"]._lifepoints = (float)(Math.Round((GameData.characters["Reckless"]._lifepoints - _enemy._hitpoints), 2));
                    if (GameData.characters["Reckless"]._lifepoints > 0F)
                    {
                        Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", GameData.characters["Reckless"]._lifepoints);
                        Console.WriteLine("Try again. Valid inputs are: arm(a) <item>, use(u) <item>, inventory(i), fight(f), quit(q)");
                        CheckCases();
                    }
                    else
                    {
                        Console.WriteLine("You are dead!");
                        QuitGame();
                    }

                    break;
            }

        }

        public static void QuitGame()
        {
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }

    }
}

