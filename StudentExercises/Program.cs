﻿using System;
using System.Collections.Generic;
using StudentExercises.Models;
using StudentExercises.Actions;

namespace StudentExercises
{
    class Program
    {
        public static void DisplayBanner()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
****************Nashville Software School*******************");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            while (true)
            {
                DisplayBanner();
                Console.WriteLine(@"
--- ACTIONS RELATED TO STUDENTS ---
1) Display all NSS students
2) Display a cohort's students
3) Search for students by last name
4) Create a new student and assign them to an existing cohort
5) Move a student from one cohort to another
6) Assign an exercise to a student
7) List the exercises assigned to a student

--- ACTIONS RELATED TO INSTRUCTORS ---
8) Display all NSS instructors
9) Create a new instructor and assign them to an existing cohort

--- ACTIONS RELATED TO EXERCISES ---
10) Display all NSS exercises
11) Create a new NSS exercise

--- ACTIONS RELATED TO COHORTS ---
12) Display all NSS cohorts
13) Create a new NSS cohort

99) ******* EXIT *******

Which action do you want?
>
");

                int SwitchMenuChoice = Int32.Parse(Console.ReadLine());
                switch (SwitchMenuChoice)
                {
                    case 1: // Display all NSS students
                        Console.Clear();
                        DisplayBanner();
                        List<Student> allStudents = repository.GETALLSTUDENTS();
                        allStudents.ForEach(stud =>
                            Console.WriteLine($"{stud.Id}: {stud.FirstName} {stud.LastName} in {stud.Cohort.Designation}"));
                        Pause();
                        break;

                    case 2: // Display a cohort's students
                        DisplayCohortsStudents.CollectInput();
                        break;

                    case 3: //Search for students by last name
                        SearchForStudentsByLastName.CollectInput();
                        break;

                    case 4: //Create a new student and assign them to an existing cohort
                        CreateAndAssignANewStudent.CollectInput();
                        break;

                    case 5: //Move a student from one cohort to another
                        MoveStudentToADifferentCohort.CollectInput();
                        break;

                    case 6: //Assign an exercise to a student
                        AssignAnExerciseToAStudent.CollectInput();
                        break;

                    case 7: //List the exercises assigned to a student
                        ListExercisesAssignedToStudent.CollectInput();
                        break;

                    case 8: //Display all NSS instructors
                        Console.Clear();
                        DisplayBanner();
                        List<Instructor> allInstructors = repository.GETALLINSTRUCTORS();
                        Console.WriteLine("All NSS Instructors:");
                        allInstructors.ForEach(inst =>
                            Console.WriteLine($"{inst.Id}: {inst.FirstName} {inst.LastName} in {inst.Cohort.Designation}"));
                        Pause();
                        break;

                    case 9: //Create a new instructor and assign them to an existing cohort
                        CreateAndAssignANewInstructor.CollectInput();
                        break;

                    case 10: //Display all NSS exercises
                        Console.Clear();
                        DisplayBanner();
                        List<Exercise> allExercises = repository.GETALLEXERCISES();
                        Console.WriteLine($"All NSS Exercises:");
                        allExercises.ForEach(exercise =>
                            Console.WriteLine($"{exercise.Id}) TITLE: {exercise.Title}, LANGUAGE: {exercise.ExerciseLanguage}"));
                        Pause();
                        break;

                    case 11: //Create a new NSS exercise
                        CreateANewExercise.CollectInput();
                        break;

                    case 12: //Display all NSS cohorts
                        Console.Clear();
                        DisplayBanner();
                        List<Cohort> allCohorts = repository.GETALLCOHORTS();
                        Console.WriteLine($"All NSS Cohorts:");
                        allCohorts.ForEach(cohort =>
                            Console.WriteLine($"{cohort.Id}): {cohort.Designation}"));
                        Pause();
                        break;

                    case 13: //Create a new NSS cohort
                        AddNewCohort.CollectInput();
                        break;

                    case 99: //EXIT
                        return;
                    default:
                        break;

                }
            }
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
