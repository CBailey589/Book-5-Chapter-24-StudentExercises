using System;
using System.Collections.Generic;
using StudentExercises.Models;
using System.Linq;
using System.Text;

namespace StudentExercises.Actions
{
    class AssignAnExerciseToAStudent
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            // Collect info for new student
            List<Student> allStudents = repository.GETALLSTUDENTS();
            List<Exercise> allExercises = repository.GETALLEXERCISES();


            allStudents.ForEach(stud =>
                Console.WriteLine($"{stud.Id}: {stud.FirstName} {stud.LastName} in {stud.Cohort.Designation}"));
            Console.WriteLine();
            Console.WriteLine("Pick a student to assignan exercise to:");
            Console.WriteLine();
            Console.WriteLine("> ");
            int studentToAssignExerciseId = Int32.Parse(Console.ReadLine());
            Student studentToAssignExercise = allStudents.First(stud => stud.Id == studentToAssignExerciseId);


            allExercises.ForEach(exercise =>
                Console.WriteLine($"{exercise.Id}) TITLE: {exercise.Title}, LANGUAGE: {exercise.ExerciseLanguage}"));
            Console.WriteLine();
            Console.WriteLine($"Pick an exercise to assign to {studentToAssignExercise.FirstName}");
            Console.WriteLine();
            Console.WriteLine("> ");
            int exerciseToAssignId = Int32.Parse(Console.ReadLine());

            //Add info to DB and give confirmation
            repository.ADDSTUDENTEXERCISE(exerciseToAssignId, studentToAssignExerciseId);
            Console.WriteLine($"{studentToAssignExercise.FirstName} {studentToAssignExercise.LastName} has been assigned the exercise!");

            Program.Pause();
            return;
        }
    }
}
