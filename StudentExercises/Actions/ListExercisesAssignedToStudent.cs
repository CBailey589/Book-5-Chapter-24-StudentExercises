using System;
using System.Collections.Generic;
using StudentExercises.Models;
using System.Linq;
using System.Text;

namespace StudentExercises.Actions
{
    class ListExercisesAssignedToStudent
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            // Select a student to show exercises for
            List<Student> allStudents = repository.GETALLSTUDENTS();
            allStudents.ForEach(stud =>
                Console.WriteLine($"{stud.Id}: {stud.FirstName} {stud.LastName} in {stud.Cohort.Designation}"));
            Console.WriteLine();
            Console.WriteLine("Which student do you want to look at the assigned exercises for:");
            Console.WriteLine();
            Console.WriteLine("> ");
            int chosenStudentId = Int32.Parse(Console.ReadLine());
            Student chosenStudent = allStudents.First(stud => stud.Id == chosenStudentId);

            //querry DB and show exercises for that student
            Console.WriteLine($"These are the exercises assigned to {chosenStudent.FirstName}");
            Console.WriteLine();

            repository.SHOWEXERCISESFORSTUDENT(chosenStudent).ForEach(ex =>
                Console.WriteLine($"{ex.Id}: Title: {ex.Title} Language: {ex.ExerciseLanguage}"));

            Program.Pause();
            return;
        }
    }
}
