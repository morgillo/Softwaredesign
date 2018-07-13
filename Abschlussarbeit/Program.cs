using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    class Program
    {
        static void Main(string[] args)
        {

            /*    ItemSetup.createItem();

               foreach(var item in ItemSetup.gear)
               {
                   Console.WriteLine(Item.name + Item.type + Item.infomation + Item.hitpoints)
               }
               foreach(var item in ItemSetup.health){
                   Console.WriteLine(Item.name + Item.type + Item.infomation + Item.lifepoints)
               } */

            /* Helper.Talk(); */

            /* MethodStore.SplitInput("hallo katha"); */
            /* RoomSetup.CreateRoom();
            Console.WriteLine(RoomSetup.rooms["Cave"]._information); */
          
            MethodStore.GameIntro();
            //MethodStore.Fight();
            for (;;)
            {
                MethodStore.CheckEnemy();
                
            }

         
            



           // MethodStore.Move();

        }

    }

}
