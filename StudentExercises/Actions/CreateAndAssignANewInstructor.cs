using System;
using System.Collections.Generic;
using StudentExercises.Models;
using System.Text;

namespace StudentExercises.Actions
{
    class CreateAndAssignANewInstructor
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            List<Cohort> allCohorts = repository.GETALLCOHORTS();

            // Collect new instructor info
            Console.WriteLine("Enter the new instructor's first name:");
            Console.WriteLine("> ");
            string newInstructorFirstName = Console.ReadLine();
            Console.WriteLine("Enter the new instructor's last name:");
            Console.WriteLine("> ");
            string newInstructorLastName = Console.ReadLine();
            Console.WriteLine("Enter the new instructor's Slack handle:");
            Console.WriteLine("> ");
            string newInstructorsSlackHandle = Console.ReadLine();
            Console.WriteLine("What is the new instructor's specialty?:");
            Console.WriteLine("> ");
            string newInstructorsSpecialty = Console.ReadLine();
            Console.WriteLine("Which cohort do you want to assign this instructor to?:");
            Console.WriteLine("> ");
            allCohorts.ForEach(cohort => Console.WriteLine($"{cohort.Id}: {cohort.Designation}"));
            int newInstructorCohortId = Int32.Parse(Console.ReadLine());

            // Send new instructor to DB and give confirmation
            repository.ADDNEWINSTRUCTORTODATABASE(newInstructorFirstName, newInstructorLastName, newInstructorsSlackHandle,
                newInstructorsSpecialty, newInstructorCohortId);
            Console.WriteLine($"{newInstructorFirstName} {newInstructorLastName} has been created!");

            Program.Pause();
            return;
        }
    }
}
