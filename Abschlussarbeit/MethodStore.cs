using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    public class MethodStore
    {
        public static GameData.Character MyCharacter = GameData.Characters["Reckless"];
        public static GameData.Room MyCurrentRoom = MyCharacter.CurrentLocation;
        public static GameData.Character Enemy;
        public static string[] SeparatedInput;
        public static bool IsFighting = false;
        public static int InteractionCounter = 0;

        public static void LoadGameDAta()
        {
            GameData.CreateRooms();
            GameData.CreateCharaters();
            GameIntro();
        }

        public static void GameIntro()
        {
            Console.WriteLine("You wake up in your father's old study. It's dark and dusty. The scream of your brother is the last thing you can remeber. He has been kidnapped by the Goyls.");
            Look(MyCurrentRoom);
        }
        public static void Look(GameData.Room room)
        {
            room = MyCurrentRoom;

            Console.WriteLine(room.Information);

            if (room.RoomInv.Count != 0)
            {
                Console.WriteLine("You see..");
                foreach (var item in room.RoomInv)
                {
                    Console.WriteLine("a/an " + item.Name);
                }
            }
            else
                Console.WriteLine("There is no item in this place.");
        }


        public static void CheckCharactersInRoom()
        {

            foreach (var character in GameData.Characters.Values)
            {
                if (character.CurrentLocation == MyCurrentRoom)
                {
                    string name = character.Name;
                    switch (name)
                    {
                        case "Goyl":
                            if (InteractionCounter == 0)
                            {
                                Enemy = character;
                                IsFighting = true;
                                Console.WriteLine("There is an angry Goyl. He's coming toward you. Defeat him!");
                                InputPrompt();
                                InteractionCounter++;
                            }
                            InputPrompt();
                            break;

                        case "Kamien":
                            Enemy = character;
                            IsFighting = true;
                            Console.WriteLine("Kamien the King of the Goyls wants to kill you. Fight him!");
                            InputPrompt();
                            QuitGame();
                            break;

                        case "Fox":
                            if (InteractionCounter == 0)
                            {
                                GameData.Helper.Talk();
                                InteractionCounter++;
                            }
                            InputPrompt();
                            break;
                        default:
                            InputPrompt();
                            break;
                    }
                }
            }
        }

        public static void InputPrompt()
        {
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine().ToLower();
            SplitInput(input);
            CheckFightCases(SeparatedInput);
        }

        public static Array SplitInput(string input)
        {
            char[] splitter = { ' ' };
            SeparatedInput = input.Split(splitter);

            return SeparatedInput;
        }

        public static void CheckFightCases(string[] input)
        {
            SeparatedInput = input;

            switch (SeparatedInput[0])
            {
                case "u":
                case "use":
                    try
                    {
                        GameData.Item.Use(SeparatedInput[1]);
                    }
                    catch
                    {
                        Console.WriteLine("You should choose an item to use.");
                    }
                    break;

                case "a":
                case "arm":
                    try
                    {
                        GameData.Gear.Arm(SeparatedInput[1]);
                    }
                    catch
                    {
                        Console.WriteLine("You should choose an item to arm.");
                    }
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

                    if (IsFighting == true)
                    {
                        GameData.Avatar.Fight(Enemy, SeparatedInput);
                    }
                    else
                        CheckNonFightCases(SeparatedInput);
                    break;
            }
        }

        public static void DisplayInventory()
        {

            Console.WriteLine("Take a look at your inventory:");
            if (MyCharacter.CharacterInventory.Count > 0)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-10}  |  {3,-10}  |  {4,-10}  ", "Name", "Type", "Healing", "Armed?", "Information"));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                foreach (var item in MyCharacter.CharacterInventory)
                {
                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-10}  |  {3,-10}  |  {4,-10}  ", item.Name, item.Type, item.Points, item.IsArmed, item.Information));
                }
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Woops! Your inventory is empty...");
            }

        }

        public static void QuitGame()
        {
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }

        public static void CheckNonFightCases(string[] input)
        {
            SeparatedInput = input;

            switch (SeparatedInput[0])
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
                    try
                    {
                        Take(SeparatedInput[1]);
                    }
                    catch
                    {
                        Console.WriteLine("You should choose an item to take it.");
                    }
                    break;

                case "d":
                case "drop":
                    try
                    {
                        Drop(SeparatedInput[1]);
                    }
                    catch
                    {
                        Console.WriteLine("Please choose an item to drop it.");
                    }

                    break;

                case "n":
                case "north":
                    if (MyCurrentRoom.North != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.North;
                        GameData.Enemy.EnemyChangeRoom();
                        Look(MyCurrentRoom);
                    }
                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "e":
                case "east":
                    if (MyCurrentRoom.East != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.East;
                        GameData.Enemy.EnemyChangeRoom();
                        Look(MyCurrentRoom);
                    }
                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "s":
                case "south":
                    if (MyCurrentRoom.South != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.South;
                        GameData.Enemy.EnemyChangeRoom();
                        Look(MyCurrentRoom);
                    }

                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                case "w":
                case "west":
                    if (MyCurrentRoom.West != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.West;
                        GameData.Enemy.EnemyChangeRoom();
                        Look(MyCurrentRoom.West);
                    }

                    else
                        Console.WriteLine("There is no exit in this direction.");
                    break;

                default:
                    Console.WriteLine("This is not possible. Try again.");
                    break;
            }
        }

        public static void Help()
        {
            List<string> commands = new List<string>()
            {
            "help(i), look(l), inventory(i),",
            "take(t) <item>, drop(d), <item> arm(a), <item> use(u), <item>," ,
            "north(n), east(e), south(s,) west(w)",
            "fight(f) and quit(q)"
            };

            foreach (var command in commands)
                Console.WriteLine(command);
        }

        public static void Take(string input)
        {
            input = SeparatedInput[1];

            GameData.Item foundItem = MyCurrentRoom.RoomInv.Find(x => x.Name.ToLower().Contains(input));
            if (foundItem != null)
            {
                Console.WriteLine("You added {0} in your inventory.", foundItem.Name);
                MyCharacter.CharacterInventory.Add(foundItem);
                MyCurrentRoom.RoomInv.Remove(foundItem);
            }
            else
            {
                Console.WriteLine("Can't take!");
            }
        }
        public static void Drop(string input)
        {
            input = SeparatedInput[1];

            GameData.Item foundItem = MyCharacter.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
            if (foundItem != null)
            {
                Console.WriteLine("You removed {0} from your inventory.", foundItem.Name);
                MyCurrentRoom.RoomInv.Add(foundItem);
                MyCharacter.CharacterInventory.Remove(foundItem);
            }
            else
            {
                Console.WriteLine("Can't drop!");
            }
        }

    }
}

