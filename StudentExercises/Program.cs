using System;
using System.Collections.Generic;
using System.Linq;
using StudentExercises.Models;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            // *******************************************************************
            //Query the database for all the Exercises:
            //********************************************************************
            List<Exercise> allExercises = repository.GETALLEXERCISES();
            Console.WriteLine($"All NSS Exercises:");
            allExercises.ForEach(exercise => 
                Console.WriteLine($"{exercise.Id}) TITLE: {exercise.Title}, LANGUAGE: {exercise.ExerciseLanguage}"));

            Pause();

            // *******************************************************************
            //Find all the exercises in the database where the language is JavaScript.
            //********************************************************************
            List<Exercise> JSExercises = allExercises.Where(exercise => exercise.ExerciseLanguage == "JavaScript").ToList();
            Console.WriteLine($"All NSS JavaScript Exercises:");
            JSExercises.ForEach(exercise =>
                Console.WriteLine($"{exercise.Id}) TITLE: {exercise.Title}, LANGUAGE: {exercise.ExerciseLanguage}"));

            Pause();

            // *******************************************************************
            //Insert a new exercise into the database.
            //********************************************************************
            Console.WriteLine("Add a new exercise");
            Console.WriteLine("Enter a title for a new exercise:");
            Console.WriteLine("> ");
            string newExerciseTitle = Console.ReadLine();
            Console.WriteLine("Enter what language the new exercise is:");
            Console.WriteLine("> ");
            string newExerciseLanguage = Console.ReadLine();

            //repository.CREATENEWEXERCISE(newExerciseTitle, newExerciseLanguage);

            // *******************************************************************
            //Find all instructors in the database. Include each instructor's cohort.
            //********************************************************************
            List<Instructor> allInstructors = repository.GETALLINSTRUCTORS();
            Console.WriteLine($"All NSS Instructors:");
            allInstructors.ForEach(instructor =>
                Console.WriteLine($"ID:{instructor.Id}) Name: {instructor.FirstName} {instructor.LastName}, Cohort: {instructor.Cohort.Designation}"));

            Pause();

            // *******************************************************************
            //Insert a new instructor into the database. Assign the instructor to an existing cohort.
            //********************************************************************
            List<Cohort> allCohorts = repository.GETALLCOHORTS();

            Console.WriteLine("Hire a new instructor");
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

            //repository.ADDNEWINSTRUCTORTODATABASE(newInstructorFirstName, newInstructorLastName, newInstructorsSlackHandle,
            //    newInstructorsSpecialty, newInstructorCohortId);

            Pause();

            // *******************************************************************
            //Assign an existing exercise to an existing student.
            //********************************************************************
            








        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
