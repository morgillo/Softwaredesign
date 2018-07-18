using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    public class GameData
    {
        public static Dictionary<string, Room> Rooms;
        public static Dictionary<string, Character> Characters;
        public static Dictionary<string, Item> Items = new Dictionary<string, Item>();
        public static int CharacterNumber;

        public class Room
        {
            public string Name;
            public string Information;
            public Room North;
            public Room East;
            public Room South;
            public Room West;
            public List<Item> RoomInv = new List<Item>();

            public Room(string name, string information)
            {
                this.Name = name;
                this.Information = information;
            }
        }

        public static void CreateRooms()
        {
            //Room 1
            Room Studyroom = new Room
            (
                "Studyroom",
                "You are in your father's old studyroom. It's dusty."
            );

            //Room 2
            Room Forest = new Room
            (
                "Forest",
                "You just entered the Forest. The weather is very muggy and sticky. Your friend is waiting for you."
            );
            Health Grape = new Health
            (
                "Grape", "Health", "Gives you lifepoints if used", 0.5F, false
            );
            Forest.RoomInv.Add(Grape);

            //Room 3
            Room Bazaar = new Room
            (
               "Bazaar",
                "You arrived at the Bazaar. It's loud and chaotic."
            );

            //Room 4
            Room Valley = new Room
            (
                "Valley",
                "You arrived at the Valley."
            );
            Gear Arrow = new Gear
            (
                "Arrow", "Gear", "Adds hitpoints if used/armed", 0.3F, false
            );
            Valley.RoomInv.Add(Arrow);

            //Room 5
            Room GoylsCave = new Room
            (
                "Goyls Cave",
                "You entered the Goyls Cave. It's cold and dark."
            );
            Health Chocolate = new Health
            (
                "Chocolate", "Health", "Gives you lifepoints if used", 0.5F, false
            );
            GoylsCave.RoomInv.Add(Chocolate);

            //Room6
            Room Dungeon = new Room
            (
                "Dungeon",
                "You entered the Dungeon. There is your brother."
            );

            //Room neighbours 
            Studyroom.West = Forest;

            Forest.North = Bazaar;
            Forest.East = Studyroom;

            Bazaar.East = Valley;
            Bazaar.South = Forest;
            Bazaar.West = GoylsCave;

            Valley.West = Bazaar;

            GoylsCave.North = Dungeon;
            GoylsCave.East = Bazaar;

            Dungeon.South = GoylsCave;

            //Add Rooms to Dictionary
            Rooms = new Dictionary<string, Room>();
            Rooms["Studyroom"] = Studyroom;
            Rooms["Forest"] = Forest;
            Rooms["Bazaar"] = Bazaar;
            Rooms["Goyls Cave"] = GoylsCave;
            Rooms["Valley"] = Valley;
            Rooms["Dungeon"] = Dungeon;

            Items["Arrow"] = Arrow;
            Items["Grape"] = Grape;
            Items["Chocolate"] = Chocolate;
        }

        public class Character
        {
            public string Name;
            public float Lifepoints;
            public float Hitpoints;
            public string Information;
            public Room CurrentLocation;
            public List<Item> CharacterInventory = new List<Item>();
        }

        public class Enemy : Character
        {
            public Enemy(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this.Name = name;
                this.Lifepoints = lifepoints;
                this.Hitpoints = hitpoints;
                this.Information = information;
                this.CurrentLocation = currentLocation;
            }


            public static void EnemyChangeRoom()
            {
                MethodStore.InteractionCounter = 0;

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


        }

        public class Avatar : Character
        {
            public Avatar(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this.Name = name;
                this.Lifepoints = lifepoints;
                this.Hitpoints = hitpoints;
                this.Information = information;
                this.CurrentLocation = currentLocation;
            }

            public static void Fight(GameData.Character enemy, string[] input)
            {
                Character myCharacter = MethodStore.MyCharacter;
                enemy = MethodStore.Enemy;
                input = MethodStore.SeparatedInput;


                switch (input[0])
                {
                    case "f":
                    case "fight":
                        //hitting the enemy
                        enemy.Lifepoints = (float)(Math.Round((enemy.Lifepoints - myCharacter.Hitpoints), 2));
                        if (enemy.Lifepoints > 0F)
                        {
                            Console.WriteLine("{0}: 'Outch!' ", enemy.Name);
                            Console.WriteLine("The Enemy is still alive. {0} Lifepoints: {1}", enemy.Name, enemy.Lifepoints);
                            // beeing hitted
                            myCharacter.Lifepoints = (float)(Math.Round((myCharacter.Lifepoints - enemy.Hitpoints), 2));

                            if (myCharacter.Lifepoints > 0F)
                            {
                                Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", myCharacter.Lifepoints);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You are dead!");
                                MethodStore.QuitGame();
                            }
                            //MethodStore.InputPrompt();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You defeated the {0}! Great!", enemy.Name);
                            Console.ResetColor();
                            if (enemy.CharacterInventory.Count != 0)
                            {
                                myCharacter.CharacterInventory.Add(enemy.CharacterInventory[0]);
                                enemy.CharacterInventory.Remove(enemy.CharacterInventory[0]);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Awesome! You snatched his inventory");
                                Console.ResetColor();
                            }
                            MethodStore.IsFighting = false;
                            enemy.Lifepoints = 1F;
                        }
                        MethodStore.InputPrompt();
                        break;

                    default:
                        Console.WriteLine("That's not possible. You were too slow.");

                        myCharacter.Lifepoints = (float)(Math.Round((myCharacter.Lifepoints - enemy.Hitpoints), 2));
                        if (myCharacter.Lifepoints > 0F)
                        {
                            Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", myCharacter.Lifepoints);
                            Console.WriteLine("Try again. Valid inputs are: arm(a) <item>, use(u) <item>, inventory(i), fight(f), quit(q)");
                            MethodStore.InputPrompt();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are dead!");
                            Console.ResetColor();
                            MethodStore.QuitGame();
                        }

                        break;
                }
                

            }

        }

        public class Helper : Character
        {
            public Helper(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this.Name = name;
                this.Lifepoints = lifepoints;
                this.Hitpoints = hitpoints;
                this.Information = information;
                this.CurrentLocation = currentLocation;
            }

            public static void Talk()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}: 'Your brother needs help. To defeat the Goyls King you better equipe. Did you already equipe?", GameData.Characters["Fox"].Name);
                Console.ResetColor();
                TalkCases();
            }
            public static void TalkCases()
            {
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                    case "yes":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}: 'Perfect. Go ahead and good Luck!'", GameData.Characters["Fox"].Name);
                        Console.ResetColor();
                        break;

                    case "n":
                    case "no":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}:'Go to the valley first. I left something there for you.' ", GameData.Characters["Fox"].Name);
                        Console.ResetColor();
                        break;
                    case "q":
                    case "quit":
                        MethodStore.QuitGame();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}:'I didn't understand. What did you say? Yes(y) or no(n)?' ", GameData.Characters["Fox"].Name);
                        Console.ResetColor();
                        TalkCases();
                        break;
                }
            }

        }
        public class Item
        {
            public string Name;
            public string Type;
            public string Information;
            public float Points;
            public bool IsArmed;


            public static void Use(string input)
            {

                Character myCharacter = MethodStore.MyCharacter;
                Character enemy = MethodStore.Enemy;
                input = MethodStore.SeparatedInput[1];

                GameData.Item foundItem = myCharacter.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
                if (foundItem != null)
                {
                    switch (foundItem.Type)
                    {
                        case "Gear":
                            if (foundItem.IsArmed == false)
                            {
                                if (MethodStore.IsFighting == true && enemy.Lifepoints > 0 && myCharacter.Lifepoints > 0)
                                {
                                    //use Item 
                                    myCharacter.Hitpoints = (float)(Math.Round((myCharacter.Hitpoints + foundItem.Points), 2));
                                    Console.WriteLine("You got temporarily stronger with the help of the " + foundItem.Name + ".");

                                    enemy.Lifepoints = (float)(Math.Round((enemy.Lifepoints - myCharacter.Hitpoints), 2));
                                    Console.WriteLine("{0}:'Ouch!!!'  Goyl's lifepoints: {1}", enemy.Name, enemy.Lifepoints);

                                    myCharacter.Hitpoints = (float)(Math.Round((myCharacter.Hitpoints - foundItem.Points), 2));
                                    myCharacter.Lifepoints = (float)(Math.Round((myCharacter.Lifepoints - enemy.Hitpoints), 2));
                                    Console.WriteLine("You have been hit! - Your Lifepoints: {0} ", myCharacter.Lifepoints);
                                }
                                else
                                    Console.WriteLine("There's no enemy to fight! Try another time.");
                            }
                            else
                                Console.WriteLine("You're already equipped with " + foundItem.Name);
                            break;

                        case "Health":
                            myCharacter.Lifepoints = (float)(Math.Round((myCharacter.Lifepoints + foundItem.Points), 2));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You used the healing item, new lifepoints: " + myCharacter.Lifepoints);
                            Console.ResetColor();
                            myCharacter.CharacterInventory.Remove(foundItem);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item!");
                }
            }
        }
        public class Health : Item
        {
            public Health(string name, string type, string information, float lifepoints, bool isarmed)
            {
                this.Name = name;
                this.Type = type;
                this.Information = information;
                this.Points = lifepoints;
                this.IsArmed = isarmed;
            }
        }
        public class Gear : Item
        {
            public Gear(string name, string type, string information, float hitpoints, bool isArmed)
            {
                this.Name = name;
                this.Type = type;
                this.Information = information;
                this.Points = hitpoints;
                this.IsArmed = isArmed;
            }

            public static void Arm(string input)
            {
                Character myCharacter = MethodStore.MyCharacter;
                input = MethodStore.SeparatedInput[1];

                GameData.Item foundItem = myCharacter.CharacterInventory.Find(x => x.Name.ToLower().Contains(input));
                if (foundItem != null)
                {
                    switch (foundItem.Type)
                    {
                        case "Gear":
                            if (foundItem.IsArmed == false)
                            {
                                myCharacter.Hitpoints = (float)(Math.Round((myCharacter.Hitpoints + foundItem.Points), 2));
                                foundItem.IsArmed = true;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You successfully equipped the " + foundItem.Name + ", new hitpoints: " + myCharacter.Hitpoints);
                                Console.ResetColor();
                            }
                            else
                                Console.WriteLine("You're already equipped with " + foundItem.Name);
                            break;

                        case "Health":
                            Console.WriteLine("Health Item! You can not equip this stuff! Try to use");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item!");
                }
            }


        }

        public static void CreateCharaters()
        {

            //Avatar
            Avatar Reckless = new Avatar
            (
            "Reckless", 1F, 0.2F, "I am J. Reckless", Rooms["Studyroom"]
            );

            //Enemy1
            Enemy Goyl = new Enemy
            (
            "Goyl", 1F, 0.1F, "Goyl is your enemy", Rooms["Forest"]
            );
            Gear Bow = new Gear
           (
               "Bow", "Gear", "Adds hitspoint if used/armed", 0.1F, false
           );
            Goyl.CharacterInventory.Add(Bow);

            //Enemy2
            Enemy Kamien = new Enemy
            (
            "Kamien", 1F, 0.3F, "Kamien is your biggest enemy", Rooms["Dungeon"]
            );

            //Helper
            Helper Fox = new Helper
            (
            "Fox", 1F, 0F, "Fox is your friend.", Rooms["Forest"]
            );

            Items["Bow"] = Bow;

            Characters = new Dictionary<string, Character>();
            Characters["Reckless"] = Reckless;
            Characters["Goyl"] = Goyl;
            Characters["Kamien"] = Kamien;
            Characters["Fox"] = Fox;

        }
    }
}