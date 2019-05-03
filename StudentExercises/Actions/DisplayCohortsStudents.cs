using System;
using System.Collections.Generic;
using StudentExercises.Models;
using System.Linq;



namespace StudentExercises.Actions
{
    class DisplayCohortsStudents
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            // Get/Print List of cohorts with question about which one to show students for
            List<Cohort> allCohorts = repository.GETALLCOHORTS();
            allCohorts.ForEach(cohort =>
                Console.WriteLine($"{cohort.Id}) {cohort.Designation}"));
            Console.WriteLine();
            Console.WriteLine("Which cohort do you want to see the students for?");
            Console.WriteLine();
            Console.WriteLine("> ");

            //Accept user input and return the list of students
            int cohortChoiceId = Int32.Parse(Console.ReadLine());
            Cohort chosenCohort = allCohorts.First(cohort => cohort.Id == cohortChoiceId);
            repository.GETALLSTUDENTSINCOHORT(chosenCohort).ForEach(student =>
                Console.WriteLine($"{student.FirstName} {student.LastName}"));

            Program.Pause();
            return;
        }
    }
}
