using System;
using System.Collections.Generic;

namespace DesPatternSingleton
{

    public class Person
    {
        public string Name;
        public int Age;
        private int Id;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Id = IDGenerator.Instance.GibMirNeId();
            Program.personen.Add(this);
        }

        public override string ToString()
        {
            return "Name:" + Name + ", Age: " + Age + ", " + "Id: " + Id;
        }
    }

    /*
    class GlobalVariables
    {
        // public static int letzteID = 1;
        public static IDGenerator DerIdMacher = new IDGenerator();
    }
    */

    public class IDGenerator
    {
        private IDGenerator()
        {
            letzteID = 1;
        }

        private static IDGenerator _instance;

        public static IDGenerator Instance    // the Name property
        {
           get
             {
            if (_instance == null)
            _instance = new IDGenerator();
            return _instance;
            }
}


private int letzteID;
public int GibMirNeId()
{
    return letzteID++;
}
    } 

    class Program
{
    public static List<Person> personen = new List<Person>();


    static void Main(string[] args)
    {
        // Eine Stelle, an der Personen angelegt werden
        new Person("Dieter", 44     /*,Id = IDGenerator.GetInstance().GibMirNeId()*/);
        new Person("Horst", 45      /*,Id = IDGenerator.GetInstance().GibMirNeId()*/);
        new Person("Walter", 33     /*,Id = IDGenerator.GetInstance().GibMirNeId()*/);

        foreach (var person in personen)
            Console.WriteLine(person);
    }
}
}
