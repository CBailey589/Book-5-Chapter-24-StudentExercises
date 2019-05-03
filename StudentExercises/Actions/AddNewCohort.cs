using System;
using System.Collections.Generic;
using StudentExercises.Models;
using System.Text;

namespace StudentExercises.Actions
{
    class AddNewCohort
    {
        public static void CollectInput()
        {
            Repository repository = new Repository();

            Program.DisplayBanner();

            List<Cohort> allCohorts = repository.GETALLCOHORTS();

            // Sow all current cohorts and make sure user wants to create a new one:
            Console.WriteLine("All current NSS Cohorts:");
            Console.WriteLine();

            allCohorts.ForEach(cohort =>
                Console.WriteLine($"{cohort.Id}): {cohort.Designation}"));

            Console.WriteLine();
            Console.WriteLine("Are you sure you need to add a new cohort? (y/n)");
            string yesOrNo = Console.ReadLine();

            //if yes, collect new cohort info
            if (yesOrNo != "y")
            {
                return;
            }
            else
            {
                Console.WriteLine("Enter the new cohort's designation:");
                Console.WriteLine("> ");
                string newCohortDesignation = Console.ReadLine();

                //Add cohort to DB and give confirmation
                repository.ADDNEWCOHORTTODATABASE(newCohortDesignation);
                Console.WriteLine($"{newCohortDesignation} has been created!");

                Program.Pause();
                return;
            }
        }
    }
}
