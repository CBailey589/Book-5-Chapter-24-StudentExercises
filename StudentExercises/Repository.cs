using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using StudentExercises.Models;

namespace StudentExercises
{
    class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }


 /************************************************************************************
 * EXERCISES:
 ************************************************************************************/

        public List<Exercise> GETALLEXERCISES()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Title, ExerciseLanguage FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> allExerciseslist = new List<Exercise>();


                    while (reader.Read())
                    {
                        // The "ordinal" is the numeric position of the column in the query results.
                        int idColumnPosition = reader.GetOrdinal("Id");

                        // We user the reader's GetXXX methods to get the value for a particular ordinal.
                        int idValue = reader.GetInt32(idColumnPosition);

                        int titleNameColumnPosition = reader.GetOrdinal("Title");
                        string exerciseTitleValue = reader.GetString(titleNameColumnPosition);

                        int languageNameColumnPosition = reader.GetOrdinal("ExerciseLanguage");
                        string exerciseLanguageValue = reader.GetString(languageNameColumnPosition);

                        // Now let's create a new department object using the data from the database.
                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Title = exerciseTitleValue,
                            ExerciseLanguage = exerciseLanguageValue
                        };

                        allExerciseslist.Add(exercise);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of departments who whomever called this method.
                    return allExerciseslist;
                }
            }
        }

        public void CREATENEWEXERCISE(string title, string language)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // More string interpolation
                    cmd.CommandText = $"INSERT INTO Exercise (Title, ExerciseLanguage) Values ('{title}', '{language}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /************************************************************************************
        * INSTRUCTORS:
        ************************************************************************************/

        public List<Instructor> GETALLINSTRUCTORS()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT i.Id, i.FirstName, i.LastName, i.SlackHandle, i.Specialty, i.CohortId, c.Designation " +
                        "FROM Instructor i " +
                        "JOIN Cohort c " +
                        "ON i.CohortId = c.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> allInstructors = new List<Instructor>();


                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int IdValue = reader.GetInt32(idColumnPosition);

                        int FirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string FirstNameValue = reader.GetString(FirstNameColumnPosition);

                        int LastNameColumnPosition = reader.GetOrdinal("LastName");
                        string LastNameValue = reader.GetString(LastNameColumnPosition);

                        int SlackHandleColumnPosition = reader.GetOrdinal("SlackHandle");
                        string SlackHandleValue = reader.GetString(SlackHandleColumnPosition);

                        int SpecialtyColumnPosition = reader.GetOrdinal("Specialty");
                        string SpecialtyValue = reader.GetString(SpecialtyColumnPosition);

                        int CohortIdColumnPosition = reader.GetOrdinal("CohortId");
                        int CohortIdValue = reader.GetInt32(CohortIdColumnPosition);

                        int CohortDesignationColumnPosition = reader.GetOrdinal("Designation");
                        string CohortDesignationValue = reader.GetString(CohortDesignationColumnPosition);


                        // Now let's create a new department object using the data from the database.
                        Instructor instructor = new Instructor
                        {
                            Id = IdValue,
                            FirstName = FirstNameValue,
                            LastName = LastNameValue,
                            SlackHandle = SlackHandleValue,
                            Specialty = SpecialtyValue,
                            CohortId = CohortIdValue,
                            Cohort = new Cohort()
                            {
                                Id = CohortIdValue,
                                Designation = CohortDesignationValue
                            }
                        };

                        allInstructors.Add(instructor);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of departments who whomever called this method.
                    return allInstructors;
                }
            }
        }

        public void ADDNEWINSTRUCTORTODATABASE(string fName, string lName, string sHandle, string specialty, int cohortId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId ) " +
                        $"Values ('{fName}', '{lName}', '{sHandle}', '{specialty}', {cohortId})";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /************************************************************************************
        * COHORTS:
        ************************************************************************************/

        public List<Cohort> GETALLCOHORTS()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Designation FROM Cohort";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> allCohortList = new List<Cohort>();


                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int DesignationColumnPosition = reader.GetOrdinal("Designation");
                        string DesignationValue = reader.GetString(DesignationColumnPosition);

                        Cohort cohort = new Cohort
                        {
                            Id = idValue,
                            Designation = DesignationValue
                        };

                        allCohortList.Add(cohort);
                    }

                    reader.Close();

                    return allCohortList;
                }
            }
        }






    }
}

