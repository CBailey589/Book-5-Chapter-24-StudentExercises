using System;
using System.Collections.Generic;
using StudentExercises.Models;

namespace StudentExercises.Actions
{
    class CreateAndAssignANewStudent
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            List<Cohort> allCohorts = repository.GETALLCOHORTS();

            // Collect info for new student
            Console.WriteLine("Enter the new student's first name:");
            Console.WriteLine("> ");
            string newStudentFirstName = Console.ReadLine();
            Console.WriteLine("Enter the new student's last name:");
            Console.WriteLine("> ");
            string newStudentLastName = Console.ReadLine();
            Console.WriteLine("Enter the new student's Slack handle:");
            Console.WriteLine("> ");
            string newStudentSlackHandle = Console.ReadLine();
            Console.WriteLine("Which cohort do you want to assign this instructor to?:");
            Console.WriteLine("> ");
            allCohorts.ForEach(cohort => Console.WriteLine($"{cohort.Id}: {cohort.Designation}"));
            int newStudentCohortId = Int32.Parse(Console.ReadLine());

            //Add student to DB and give confirmation message
            repository.ADDNEWSTUDENTTODATABASE(newStudentFirstName, newStudentLastName, newStudentSlackHandle, newStudentCohortId);
            Console.WriteLine($"{newStudentFirstName} {newStudentLastName} has been created!");

            Program.Pause();
            return;
        }
    }
}
