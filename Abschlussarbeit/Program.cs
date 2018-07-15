using System;
using System.Collections.Generic;

namespace Abschlussarbeit
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodStore.GameIntro();

            for (; ; )
            {
                MethodStore.CheckEnemy();
            }
        }
    }
}
