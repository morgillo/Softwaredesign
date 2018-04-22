<<<<<<< HEAD
﻿using System;
using static System.Console;

public class SimplePerson
{
   public string FirstName;
   public string LastName;
   public DateTime DateOfBirth;
}

namespace Aufgabe2
{
class Program
    {
        static void Main(string[] args)
        {

            Person root = Familytree.BuildTree();
          
            Person found = Familytree.Find(root);

            WriteLine(found);
        }
    }
=======
﻿using System;
using static System.Console;

public class SimplePerson
{
   public string FirstName;
   public string LastName;
   public DateTime DateOfBirth;
}

namespace Aufgabe2
{
class Program
    {
        static void Main(string[] args)
        {

            Person root = Familytree.BuildTree();
          
            Person found = Familytree.Find(root);

            WriteLine(found);
        }
    }
>>>>>>> bfd13c0f8269f40f744230b12e78454322be1952
}