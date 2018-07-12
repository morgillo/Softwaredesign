using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{

        //Items
    public class Item
    {
        public string name;
        public string type;
        public string information;
    }


    public class Health : Item
    {
        public float lifepoints;
        public static void use()
        {
            //adds lifepoints
        }
    }
    public class Gear : Item
    {
        public float hitpoints;
        public bool isArmed;
    }


    public class Berries : Health
    {
    }

    public class Knife : Gear
    {
    }


    public class Normal : Item
    {

    }

    public class Key : Normal
    {
        /*   public static use() 
       {
          //opens door
       } */
    }

    public class Coins : Normal
    {
        /*    public static pay() 
        {
           //buys things
        } */
    }


    public class ItemSetup
    {
        public static List<Normal> normal = new List<Normal>();
        public static List<Gear> gear = new List<Gear>();
        public static List<Health> health = new List<Health>();
        public static void createItem()
        {
            
            //Key
            Normal Key = new Normal
            {
            name = "Key",
            type = "type",
            information = "info",
            };
            normal.Add(Key);

            //Coins
            Normal Coins = new Normal
            {
            name = "Coins",
            type = "type",
            information = "info",
            };
            normal.Add(Coins);

            //Gear
            Gear Knife = new Gear
            {
            name = "Knife",
            type = "type",
            information = "info",
            hitpoints = 0.1F,
            isArmed = false,
            };
            gear.Add(Knife);
            //Health
            Health Berries = new Health
            {
            name = "Berries",
            type = "type",
            information = "info",
            lifepoints = 0.1F,
            };
            health.Add(Berries);
            

        }

    }

}