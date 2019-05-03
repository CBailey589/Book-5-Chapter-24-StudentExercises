using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Actions
{
    class CreateANewExercise
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            // Collect info for new exercise
            Console.WriteLine("Enter a title for a new exercise:");
            Console.WriteLine();
            Console.WriteLine("> ");
            string newExerciseTitle = Console.ReadLine();
            Console.WriteLine("Enter what language the new exercise is:");
            Console.WriteLine();
            Console.WriteLine("> ");
            string newExerciseLanguage = Console.ReadLine();

            //Send new exercise to DB and give confirmation
            repository.CREATENEWEXERCISE(newExerciseTitle, newExerciseLanguage);
            Console.WriteLine($"{newExerciseTitle} has been created!");

            Program.Pause();
            return;
        }
    }
}
