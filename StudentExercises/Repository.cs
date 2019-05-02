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








    }
}

