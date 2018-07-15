using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    public class GameData
    {
        public static Dictionary<string, Room> Rooms;
        public static Dictionary<string, Character> Characters;
        public static Dictionary<string, Item> Items = new Dictionary<string, Item>();

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

        public static void CreateRoom()
        {
            //Room 1
            Room Bedroom = new Room
            (
                "Bedroom",
                "You just entered your father's old studyroom. It's old and dusty."
            );

            //Room 2
            Room Forest = new Room
            (
                "Forest",
                "You just entered the Forest. The weather was very muggy and sticky."
            );
            Health Berry = new Health
            (
                "Berry", "Health", "info", 0.3F, false
            );
            Forest.RoomInv.Add(Berry);

            //Room 3
            Room Bazaar = new Room
            (
               "Bazaar",
                "You arrived at the Bazaar"
            );

            //Room 4
            Room Valley = new Room
            (
                "Valley",
                "You are at the Valley"
            );
            Gear Arrow = new Gear
            (
                "Arrow", "Gear", "info", 0.3F, false
            );
            Valley.RoomInv.Add(Arrow);

            //Room 5
            Room GoylsCave = new Room
            (
                "Goyls Cave",
                "You entered the Goyls Cave"
            );

            //Room6
            Room Dungeon = new Room
            (
                "Dungeon",
                "You are in Dugeon"

            );

            //Room neighbours 
            Bedroom.West = Forest;

            Forest.North = Bazaar;
            Forest.East = Bedroom;

            Bazaar.East = Valley;
            Bazaar.South = Forest;
            Bazaar.West = GoylsCave;

            Valley.West = Bazaar;

            GoylsCave.North = Dungeon;
            GoylsCave.East = Bazaar;

            Dungeon.South = GoylsCave;

            //Add Rooms to Dictionary
            Rooms = new Dictionary<string, Room>();
            Rooms["Bedroom"] = Bedroom;
            Rooms["Forest"] = Forest;
            Rooms["Bazaar"] = Bazaar;
            Rooms["Goyls Cave"] = GoylsCave;
            Rooms["Valley"] = Valley;

            Items["Arrow"] = Arrow;
            Items["Berry"] = Berry;
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
        }
        public class Item
        {
            public string Name;
            public string Type;
            public string Information;
            public float Points;
            public bool IsArmed;
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
        }

        public static void CreateCharater()
        {

            //Avatar
            Avatar Reckless = new Avatar
            (
            "Reckless", 1F, 0.2F, "I am J. Reckless", Rooms["Bedroom"]
            );

            //Enemy1
            Enemy Goyl = new Enemy
            (
            "Goyl", 1F, 0.1F, "Goyl is your enemy", Rooms["Forest"]
            );
            Gear Bow = new Gear
           (
               "Bow", "Gear", "info", 0.1F, false
           );
            Goyl.CharacterInventory.Add(Bow);

            //Enemy2
            Enemy Kamien = new Enemy
            (
            "Kamien", 1F, 0.3F, "Kamien is your biggest enemy", Rooms["Goyls Cave"]
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