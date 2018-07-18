using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodStore.LoadGameDAta();

            for (; ; )
            MethodStore.CheckCharactersInRoom();   
            
        }
    }
}
