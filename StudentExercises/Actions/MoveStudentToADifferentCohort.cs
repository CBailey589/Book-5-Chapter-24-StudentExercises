using System;
using System.Collections.Generic;
using StudentExercises.Models;
using System.Linq;
using System.Text;

namespace StudentExercises.Actions
{
    class MoveStudentToADifferentCohort
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            // Print a list of all students for the user to choose from
            List<Student> allStudents = repository.GETALLSTUDENTS();
            allStudents.ForEach(stud =>
                Console.WriteLine($"{stud.Id}: {stud.FirstName} {stud.LastName} in {stud.Cohort.Designation}"));
            Console.WriteLine();
            Console.WriteLine("Which student do you want to move to a different cohort");
            Console.WriteLine();
            Console.WriteLine("> ");
            int chosenStudentId = Int32.Parse(Console.ReadLine());
            Student chosenStudent = allStudents.First(student => student.Id == chosenStudentId);

            //Print a list of cohorts that the student is not in
            List<Cohort> CohortsStudentIsntIn = repository.GETALLCOHORTS().Where(cohort => cohort.Id != chosenStudent.CohortId).ToList();
            CohortsStudentIsntIn.ForEach(cohort => Console.WriteLine($"{cohort.Id}: {cohort.Designation}"));
            Console.WriteLine();
            Console.WriteLine("Which cohort do you want to move the student to?");
            Console.WriteLine();
            Console.WriteLine("> ");
            int chosenCohortId = Int32.Parse(Console.ReadLine());

            //Move student in DB and give confirmation
            repository.MOVESTUDENTTODIFFERENTCOHORT(chosenStudentId, chosenCohortId);
            Console.WriteLine($"{chosenStudent.FirstName} {chosenStudent.LastName} has been moved!");

            Program.Pause();
            return;
        }
    }
}
