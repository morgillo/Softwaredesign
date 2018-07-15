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
        public static bool IsFightCase = false;
        public static int CharacterNumber;
        public static int InteractionCounter = 0;

        public static void GameIntro()
        {
            Console.WriteLine("You wake up in your father's old study. It's dark and dusty. The scream of your brother is the last thing you can remeber. He has been kidnapped by the Goyls.");
            GameData.CreateRoom();
            GameData.CreateCharater();
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
        public static void Take(string input)
        {
            input = SeparatedInput[1];

            GameData.Item _foundItem = MyCurrentRoom.RoomInv.Find(x => x.Name.ToLower().Contains(input));
            if (_foundItem != null)
            {
                Console.WriteLine("You added {0} in your inventory.", _foundItem.Name);
                MyCharacter.CharacterInventory.Add(_foundItem);
                MyCurrentRoom.RoomInv.Remove(_foundItem);
            }
            else
            {
                Console.WriteLine("Can't take!");
            }
        }
        public static void Drop(string input)
        {
            input = SeparatedInput[1];

            GameData.Item _foundItem = MyCharacter.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
            if (_foundItem != null)
            {
                Console.WriteLine("You removed {0} from your inventory.", _foundItem.Name);
                MyCurrentRoom.RoomInv.Add(_foundItem);
                MyCharacter.CharacterInventory.Remove(_foundItem);
            }
            else
            {
                Console.WriteLine("Can't drop!");
            }
        }

        public static void DisplayInventory()
        {

            Console.WriteLine("Take a look at your inventory:");
            if (MyCharacter.CharacterInventory.Count > 0)
            {
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  ", "Name", "Type", "Information"));
                Console.WriteLine("---------------------------------------------------------------------------------");

                foreach (var item in MyCharacter.CharacterInventory)
                {

                    Console.WriteLine(String.Format("  {0,-10}  |  {1,-10}  |  {2,-30}  ", item.Name, item.Type, item.Information));

                }
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Woops! Your inventory is empty...");
            }

        }
        public static void Talk()
        {
            Console.WriteLine("{0}: 'Youre brother needs help. To defeat the Goyls King you better equipe. Did you already equipe?", GameData.Characters["Fox"].Name);
            MethodStore.TalkCases();
        }
        public static void TalkCases()
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
                    TalkCases();
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
            "and quit(q)"
            };

            foreach (var command in commands)
                Console.WriteLine(command);
        }

        public static void CheckCases()
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
                    Use(SeparatedInput[1]);
                    break;

                case "a":
                case "arm":
                    Arm(SeparatedInput[1]);
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
                    if (IsFightCase == true)
                    {
                        Fight(Enemy, SeparatedInput);
                    }
                    else
                        CheckNonFightCases(SeparatedInput);
                    break;
            }
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
                    Take(SeparatedInput[1]);
                    break;

                case "d":
                case "drop":
                    Drop(SeparatedInput[1]);
                    break;

                case "n":
                case "north":
                    if (MyCurrentRoom.North != null)
                    {
                        MyCurrentRoom = MyCurrentRoom.North;
                        EnemyChangeRoom();
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
                        EnemyChangeRoom();
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
                        EnemyChangeRoom();
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
                        EnemyChangeRoom();
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

        public static void EnemyChangeRoom()
        {
            InteractionCounter = 0;

            List<GameData.Room> allRooms = new List<GameData.Room>(GameData.Rooms.Values);

            Random rand = new Random();
            int randomIndex = rand.Next(allRooms.Count);
            GameData.Characters["Goyl"].CurrentLocation = allRooms[randomIndex];
            CountCharacterNumber();
        }

        public static bool isInList(string s)
        {
            if (s == GameData.Characters["Goyl"].CurrentLocation.Name)
                return true;
            else
                return false;
        }
        public static void CountCharacterNumber()
        {
            List<string> currentRooms = new List<string>();

            foreach (var character in GameData.Characters)
            {
                currentRooms.Add(character.Value.CurrentLocation.Name);
            }

            List<string> sublist = currentRooms.FindAll(isInList);
            CharacterNumber = sublist.Count;

            if (CharacterNumber >= 2)
            {
                EnemyChangeRoom();
            }

        }
        public static void CheckEnemy()
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
                                    IsFightCase = true;
                                    Console.WriteLine("There is an angry Goyl. He's coming toward you. Defeat him!");
                                    CheckCases();
                                    InteractionCounter++;
                                }
                                CheckCases();
                                break;

                            case "Kamien":
                                Enemy = character;
                                IsFightCase = true;
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
                        }      
                }
                CheckCases();
            }
            //CheckCases();
        }
        public static void Fight(GameData.Character enemy, string[] input)
        {
            input = SeparatedInput;
            enemy = Enemy;
            switch (input[0])
            {
                case "f":
                case "fight":
                    //hitting the enemy
                    enemy.Lifepoints = (float)(Math.Round((enemy.Lifepoints - MyCharacter.Hitpoints), 2));
                    if (enemy.Lifepoints > 0F)
                    {
                        Console.WriteLine("{0}: 'Outch!' ", enemy.Name);
                        Console.WriteLine("The Enemy is still alive. {0} Lifepoints: {1}", Enemy.Name, Enemy.Lifepoints);
                        // beeing hitted
                        MyCharacter.Lifepoints = (float)(Math.Round((MyCharacter.Lifepoints - Enemy.Hitpoints), 2));

                        if (MyCharacter.Lifepoints > 0F)
                        {
                            Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", MyCharacter.Lifepoints);
                        }
                        else
                        {
                            Console.WriteLine("You are dead!");
                            QuitGame();
                        }

                    }
                    else
                    {
                        Console.WriteLine("You defeated the {0}! Great!", enemy.Name);
                        if (enemy.CharacterInventory.Count != 0)
                        {
                            MyCharacter.CharacterInventory.Add(enemy.CharacterInventory[0]);
                            enemy.CharacterInventory.Remove(enemy.CharacterInventory[0]);
                            Console.WriteLine("Awesome! You snatched his inventory");
                        }
                        IsFightCase = false;
                        enemy.Lifepoints = 1F;
                    }
                    CheckCases();
                    break;

                default:
                    Console.WriteLine("That's not possible. You were too slow.");
                    
                    MyCharacter.Lifepoints = (float)(Math.Round((MyCharacter.Lifepoints - Enemy.Hitpoints), 2));
                    if (MyCharacter.Lifepoints > 0F && Enemy.Lifepoints > 0F)
                    {
                        Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", MyCharacter.Lifepoints);
                        Console.WriteLine("Try again. Valid inputs are: arm(a) <item>, use(u) <item>, inventory(i), fight(f), quit(q)");
                        CheckCases();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are dead!");
                        Console.ResetColor();
                        QuitGame();
                    }

                    break;
            }

        }

        public static void Arm(string input)

        {
            input = SeparatedInput[1];
            GameData.Item _foundItem = MyCharacter.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
            if (_foundItem != null)
            {
                switch (_foundItem.Type)
                {
                    case "gear":
                        if (_foundItem.IsArmed == false)
                        {
                            MyCharacter.Hitpoints = (float)(Math.Round((MyCharacter.Hitpoints + _foundItem.Points), 2));
                            _foundItem.IsArmed = true;
                            Console.WriteLine("You successfully equipped the " + _foundItem.Name + ", new hitpoints: " + MyCharacter.Hitpoints);
                        }
                        else
                            Console.WriteLine("You're already equipped with " + _foundItem.Name);
                        break;

                    case "health":
                        Console.WriteLine("Health! You can not equip this stuff... Try to use it damnit!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid item!");
            }
        }

        public static void Use(string input)
        {
            input = SeparatedInput[1];
            GameData.Item _foundItem = MyCharacter.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
            if (_foundItem != null)
            {
                switch (_foundItem.Type)
                {
                    case "Gear":
                        if (_foundItem.IsArmed == false)
                        {
                            if (IsFightCase == true && Enemy.Lifepoints > 0 && MyCharacter.Lifepoints > 0)
                            {
                                //use Item 
                                MyCharacter.Hitpoints = (float)(Math.Round((MyCharacter.Hitpoints + _foundItem.Points), 2));
                                Console.WriteLine("You got temporarily stronger with the help of the " + _foundItem.Name + ".");

                                Enemy.Lifepoints = (float)(Math.Round((Enemy.Lifepoints - MyCharacter.Hitpoints), 2));
                                Console.WriteLine("{0}:'Ouch!!!'  Goyl's lifepoints: {1}", Enemy.Name, Enemy.Lifepoints);

                                MyCharacter.Hitpoints = (float)(Math.Round((MyCharacter.Hitpoints - _foundItem.Points), 2));
                                MyCharacter.Lifepoints = (float)(Math.Round((MyCharacter.Lifepoints - Enemy.Hitpoints), 2));
                                Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", MyCharacter.Lifepoints);
                            }
                            else
                                Console.WriteLine("There's no enemy to fight! Try another time.");
                        }
                        else
                            Console.WriteLine("You're already equipped with " + _foundItem.Name);
                        break;

                    case "Health":
                        MyCharacter.Lifepoints = (float)(Math.Round((MyCharacter.Lifepoints + _foundItem.Points), 2));
                        Console.WriteLine("You used the healing item, new lifepoints: " + MyCharacter.Lifepoints);
                        MyCharacter.CharacterInventory.Remove(_foundItem);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid item!");
            }
        }
        public static void QuitGame()
        {
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }
    }
}

