using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Actions
{
    class SearchForStudentsByLastName
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            // Collect string for students last name
            Console.WriteLine();
            Console.WriteLine("What last name do you want to search for?");
            Console.WriteLine();
            Console.WriteLine("> ");
            string nameToSearchFor = Console.ReadLine();

            //Search DB for that name and return list of students
            Console.WriteLine();
            repository.GETSTUDENTBYLASTNAME(nameToSearchFor).ForEach(student =>
                Console.WriteLine($"{student.FirstName} {student.LastName} in {student.Cohort.Designation}"));

            Program.Pause();
            return;
        }


    }
}
