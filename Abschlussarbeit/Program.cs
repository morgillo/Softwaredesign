using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodStore.GameIntro();
            
            for (;;)
            {
                MethodStore.CheckEnemy();   
            } 
            
            //MethodStore.DisplayInventory();
            //Console.WriteLine(GameData.characters["Goyl"]._characterInventory);
        }
    }
}
