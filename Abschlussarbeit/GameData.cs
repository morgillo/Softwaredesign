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

        public class Room
        {
            public string _name;
            public string _information;
            public Room north;
            public Room east;
            public Room south;
            public Room west;

            public Room(string name, string information)
            {
                this._name = name;
                this._information = information;
            }

            public static void RoomDescription(Room room)
            {
                room = GameData.characters["Reckless"]._currentLocation;
                //Console.Write(room._name);
                Console.WriteLine(room._information);
            }
        }

        public static void CreateRoom()
        {
            Room Bedroom = new Room
            (
                "Bedroom",
                "You just entered your father's old studyroom. It's ..."


            );

            Room Forest = new Room
            (
                "Forest",
                "You just entered the Forest. It's "

            );

            Room Bazaar = new Room
            (
               "Bazaar",
                "You arrived... "
            );

            Room Valley = new Room
            (
                "Valley",
                "..."
            );

            Room GoylsCave = new Room
            (
                "Goyls Cave",
                "..."
            );


            Room Dungeon = new Room
            (
                "Dungeon",
                "..."

            );

            //Room neighbours 
            Bedroom.west = Forest;

            Forest.north = Bazaar;
            Forest.east = Bedroom;

            Bazaar.east = Valley;
            Bazaar.south = Forest;
            Bazaar.west = GoylsCave;

            GoylsCave.north = Dungeon;
            GoylsCave.east = Bazaar;

            Dungeon.south = GoylsCave;

            //Add rooms to Dictionary
            rooms = new Dictionary<string, Room>();
            rooms["Bedroom"] = Bedroom;
            rooms["Forest"] = Forest;
            rooms["Bazaar"] = Bazaar;
            rooms["Goyls Cave"] = GoylsCave;
            rooms["Valley"]= Valley;

        }

        //Character
        public class Character
        {
            public string _name;
            public float _lifepoints;
            public float _hitpoints;
            public string _information;
            public Room _currentLocation;
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
        public static Dictionary<string, Character> characters;
        public static void createCharater()
        {

            //Avatar
            Avatar Reckless = new Avatar
            (
            "Reckless", 1F, 0.2F, "I am J. Reckless", rooms["Bedroom"]
            //Console.WriteLine("Character stats {0} - LP%: {1}, HP%: {2}, Info: {3}", Avatar.name, Avatar.lifepoints, Avatar.hitpoints, Avatar.information),
            );

            //Enemy1
            Enemy Goyl = new Enemy
            (
            "Goyl", 1F, 0.1F, "Goyl is your enemy", rooms["Valley"]
            //Console.WriteLine("Character stats {0} - LP%: {1}, HP%: {2}, Info: {3}", Avatar.name, Avatar.lifepoints, Avatar.hitpoints, Avatar.information),
            );

            //Enemy2
            Enemy Kamien = new Enemy
            (
            "Kamien", 1F, 0.3F, "Kamien is your biggest enemy", rooms["Goyls Cave"]
            //Console.WriteLine("Character stats {0} - LP%: {1}, HP%: {2}, Info: {3}", Avatar.name, Avatar.lifepoints, Avatar.hitpoints, Avatar.information),
            );

            //Helper
            Helper Fox = new Helper
            (
            "Fox", 1F, 0F, "Fox is your friend.", rooms["Forest"]
            //Console.WriteLine("Character stats {0} - LP%: {1}, HP%: {2}, Info: {3}", Avatar.name, Avatar.lifepoints, Avatar.hitpoints, Avatar.information),
            );

            //statt Liste
            characters = new Dictionary<string, Character>();
            characters["Reckless"] = Reckless;
            characters["Goyl"] = Goyl;
            characters["Kamien"] = Kamien;
            characters["Fox"] = Fox;


        }

        /* public static void checkCharacters()
        {
            foreach(var item in GameData.characters.Values)
            {
                characters["Goyl"]._hitpoints++;
                Console.WriteLine(item._hitpoints);
            }
        } */
    }

}