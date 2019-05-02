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

            repository.CREATENEWEXERCISE(newExerciseTitle, newExerciseLanguage);




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
