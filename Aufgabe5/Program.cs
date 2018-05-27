using System;
using System.Collections.Generic;

namespace Aufgabe5
{
    class Program
    {
        static void Main(string[] args)
        {
            Participant _participant = new Participant()
            {
                name = "John Doe", 
                age =DateTime.Today.Year - 1993, 
                matrikelnr = 250638, 

            };

            Professor _professor = new Professor()
            {
                name = "Richard Roe",
                age = DateTime.Today.Year - 1966,
                roomNr = 124,
                consultationHour= "1pm - 2pm",

            };

            Lesson _lesson = new Lesson()
            {
                title = "SoftwareDesign",
                day = "Tuesday",
                time = "11am", 
                room = 207,
                professor = _professor.name,
            };

            _lesson.PrintInformation();
            _professor.GetParticipants();
            _professor.PrintLessonList();



        }

    }

    class Person
    {
        public String name = null;
        public int age = 0;
    }

    class Participant : Person 
    {
        public int matrikelnr;
        private List<String> lessons = new List<String>();
    }

    class Professor : Person
    {
        public int roomNr = 0;

        public string consultationHour = "";
        private List<Lesson> lessonsToTeach = new List<Lesson>();
        private List<Participant> nameOfParticipants = new List<Participant>();

        public void GetParticipants ()
        {
            foreach (Lesson lesson in lessonsToTeach)
            {
                System.Console.WriteLine(lesson);
                foreach(Participant participant in nameOfParticipants)
                {
                    if(!nameOfParticipants.Contains(participant))
                    System.Console.WriteLine(participant);
                        nameOfParticipants.Add(participant);

                }
            }

        }

         public void PrintLessonList()
        {
            foreach (Lesson lesson in lessonsToTeach)
            {
                System.Console.WriteLine(lesson.title +", "+ lesson.time +", "+ lesson.room);
            }

        }

    }

    class Lesson
    {
        public String title = "";
        public String day = "";
        public String time = "";
        public int room = 0;
        public String professor;
        //private List<String> participants = new List<String>();
        

        public void PrintInformation()
        {
            System.Console.WriteLine(title +", "+ day +", "+ time +", "+ room +", "+ professor);
        }

    }


}
