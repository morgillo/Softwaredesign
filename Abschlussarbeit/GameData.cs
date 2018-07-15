using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    public class GameData
    {
        public static List<string> commands = new List<string>
        {
            "help(i), look(l), inventory(i),",

            "take(t) <item>, drop(d), <item> arm(a), <item> use(u), <item>," ,

            "north(n), east(e), south(s,) west(w)",

            "and quit(q)"
        };
        //public static string userInput = Console.ReadLine().ToLower();

        public static Dictionary<string, Room> rooms;
        public static Dictionary<string, Character> characters;
        public static Dictionary<string, Item> items =new Dictionary<string, Item>();

        public class Room
        {
            public string _name;
            public string _information;
            public Room north;
            public Room east;
            public Room south;
            public Room west;
            public List<Item> _roomInv = new List<Item>();

            public Room(string name, string information)
            {
                this._name = name;
                this._information = information;
            }
        }

        public static void CreateRoom()
        {
            Room Bedroom = new Room
            (
                "Bedroom",
                "You just entered your father's old studyroom. It's old and dusty."
            );

            Room Forest = new Room
            (
                "Forest",
                "You just entered the Forest. The weather was very muggy and sticky."
            );
            Health Berry = new Health
            (
                "Berry", "Health", "info", 0.3F, false
            );
            Forest._roomInv.Add(Berry);

            Room Bazaar = new Room
            (
               "Bazaar",
                "You arrived at the Bazaar"
            );

            Room Valley = new Room
            (
                "Valley",
                "You are at the Valley"
            );
            Gear Arrow = new Gear
            (
                "Arrow", "Gear", "info", 0.3F, false
            );
            Valley._roomInv.Add(Arrow);

            Room GoylsCave = new Room
            (
                "Goyls Cave",
                "You entered the Goyls Cave"
            );


            Room Dungeon = new Room
            (
                "Dungeon",
                "You are in Dugeon"

            );

            //Room neighbours 
            Bedroom.west = Forest;

            Forest.north = Bazaar;
            Forest.east = Bedroom;

            Bazaar.east = Valley;
            Bazaar.south = Forest;
            Bazaar.west = GoylsCave;

            Valley.west = Bazaar;

            GoylsCave.north = Dungeon;
            GoylsCave.east = Bazaar;

            Dungeon.south = GoylsCave;

            //Add rooms to Dictionary
            rooms = new Dictionary<string, Room>();
            rooms["Bedroom"] = Bedroom;
            rooms["Forest"] = Forest;
            rooms["Bazaar"] = Bazaar;
            rooms["Goyls Cave"] = GoylsCave;
            rooms["Valley"] = Valley;

            items["Arrow"] = Arrow;
            items["Berry"] = Berry;
        }

        //Character
        public class Character
        {
            public string _name;
            public float _lifepoints;
            public float _hitpoints;
            public string _information;
            public Room _currentLocation;
            public List<Item> _characterInventory = new List <Item>();
        }

        public class Enemy : Character
        {
            public Enemy(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this._name = name;
                this._lifepoints = lifepoints;
                this._hitpoints = hitpoints;
                this._information = information;
                this._currentLocation = currentLocation;
            }
        }

        public class Avatar : Character
        {
            public Avatar(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this._name = name;
                this._lifepoints = lifepoints;
                this._hitpoints = hitpoints;
                this._information = information;
                this._currentLocation = currentLocation;
            }
        }

        public class Helper : Character
        {
            public Helper(string name, float lifepoints, float hitpoints, string information, Room currentLocation)
            {
                this._name = name;
                this._lifepoints = lifepoints;
                this._hitpoints = hitpoints;
                this._information = information;
                this._currentLocation = currentLocation;
            }
        }

        public class Item
        {
            public string _name;
            public string _type;
            public string _information;
            public float Points;
            public bool IsArmed;
           
        }


        public class Health : Item
        {
            public Health(string name, string type, string information, float lifepoints, bool isarmed)
            {
                this._name = name;
                this._type = type;
                this._information = information;
                this.Points = lifepoints;
                this.IsArmed = isarmed;
            }
        }
        public class Gear : Item
        {
            public Gear(string name, string type, string information, float hitpoints, bool isArmed)
            {
                this._name = name;
                this._type = type;
                this._information = information;
                this.Points = hitpoints;
                this.IsArmed = isArmed;
            }
        }

        public static void CreateCharater()
        {

            //Avatar
            Avatar Reckless = new Avatar
            (
            "Reckless", 1F, 0.2F, "I am J. Reckless", rooms["Bedroom"]
            );

            //Enemy1
            Enemy Goyl = new Enemy
            (
            "Goyl", 1F, 0.1F, "Goyl is your enemy", rooms["Forest"]
            );
             Gear Bow = new Gear
            (
                "Bow", "Gear", "info", 0.1F, false
            );
            Goyl._characterInventory.Add(Bow);

            //Enemy2
            Enemy Kamien = new Enemy
            (
            "Kamien", 1F, 0.3F, "Kamien is your biggest enemy", rooms["Goyls Cave"]
            );

            //Helper
            Helper Fox = new Helper
            (
            "Fox", 1F, 0F, "Fox is your friend.", rooms["Forest"]
            );

            items["Bow"] = Bow;
            


            characters = new Dictionary<string, Character>();
            characters["Reckless"] = Reckless;
            characters["Goyl"] = Goyl;
            characters["Kamien"] = Kamien;
            characters["Fox"] = Fox;

        }

    }

}