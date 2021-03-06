﻿using System;
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

        public void ADDNEWCOHORTTODATABASE(string designation)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Cohort (Designation) " +
                        $"Values ('{designation}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /************************************************************************************
        * SUDENTS:
        ************************************************************************************/

        public List<Student> GETALLSTUDENTS()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT s.Id, s.FirstName, s.LastName, s.SlackHandle, s.CohortId, c.Designation " +
                        "FROM Student s " +
                        "JOIN Cohort c " +
                        "ON s.CohortId = c.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> allStudents = new List<Student>();


                    while (reader.Read())
                    {
                        int IdValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string FirstNameValue = reader.GetString(reader.GetOrdinal("FirstName"));
                        string LastNameValue = reader.GetString(reader.GetOrdinal("LastName"));
                        string SlackHandleValue = reader.GetString(reader.GetOrdinal("SlackHandle"));
                        int CohortIdValue = reader.GetInt32(reader.GetOrdinal("CohortId"));
                        string CohortDesignationValue = reader.GetString(reader.GetOrdinal("Designation"));


                        Student student = new Student
                        {
                            Id = IdValue,
                            FirstName = FirstNameValue,
                            LastName = LastNameValue,
                            SlackHandle = SlackHandleValue,
                            CohortId = CohortIdValue,
                            Cohort = new Cohort()
                            {
                                Id = CohortIdValue,
                                Designation = CohortDesignationValue
                            }
                        };

                        allStudents.Add(student);
                    }

                    reader.Close();
                    return allStudents;
                }
            }
        }

        public List<Student> GETALLSTUDENTSINCOHORT(Cohort cohort)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT s.Id, s.FirstName, s.LastName, s.SlackHandle, s.CohortId, c.Designation " +
                        "FROM Student s " +
                        "JOIN Cohort c " +
                        "ON s.CohortId = c.Id " +
                        "WHERE c.Id = @cohortId";
                    cmd.Parameters.Add(new SqlParameter("@cohortId", cohort.Id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> allStudents = new List<Student>();


                    while (reader.Read())
                    {
                        int IdValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string FirstNameValue = reader.GetString(reader.GetOrdinal("FirstName"));
                        string LastNameValue = reader.GetString(reader.GetOrdinal("LastName"));
                        string SlackHandleValue = reader.GetString(reader.GetOrdinal("SlackHandle"));
                        int CohortIdValue = reader.GetInt32(reader.GetOrdinal("CohortId"));
                        string CohortDesignationValue = reader.GetString(reader.GetOrdinal("Designation"));


                        Student student = new Student
                        {
                            Id = IdValue,
                            FirstName = FirstNameValue,
                            LastName = LastNameValue,
                            SlackHandle = SlackHandleValue,
                            CohortId = CohortIdValue,
                            Cohort = new Cohort()
                            {
                                Id = CohortIdValue,
                                Designation = CohortDesignationValue
                            }
                        };

                        allStudents.Add(student);
                    }

                    reader.Close();
                    return allStudents;
                }
            }
        }

        public List<Student> GETSTUDENTBYLASTNAME(string nameToSearchFor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT s.Id, s.FirstName, s.LastName, s.SlackHandle, s.CohortId, c.Designation " +
                        "FROM Student s " +
                        "JOIN Cohort c " +
                        "ON s.CohortId = c.Id " +
                        "WHERE s.LastName LIKE @nameToSearchFor";
                    cmd.Parameters.Add(new SqlParameter("@nameToSearchFor", nameToSearchFor));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> allStudents = new List<Student>();


                    while (reader.Read())
                    {
                        int IdValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string FirstNameValue = reader.GetString(reader.GetOrdinal("FirstName"));
                        string LastNameValue = reader.GetString(reader.GetOrdinal("LastName"));
                        string SlackHandleValue = reader.GetString(reader.GetOrdinal("SlackHandle"));
                        int CohortIdValue = reader.GetInt32(reader.GetOrdinal("CohortId"));
                        string CohortDesignationValue = reader.GetString(reader.GetOrdinal("Designation"));


                        Student student = new Student
                        {
                            Id = IdValue,
                            FirstName = FirstNameValue,
                            LastName = LastNameValue,
                            SlackHandle = SlackHandleValue,
                            CohortId = CohortIdValue,
                            Cohort = new Cohort()
                            {
                                Id = CohortIdValue,
                                Designation = CohortDesignationValue
                            }
                        };

                        allStudents.Add(student);
                    }

                    reader.Close();
                    return allStudents;
                }
            }
        }

        public void ADDNEWSTUDENTTODATABASE(string fName, string lName, string sHandle, int cohortId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId ) " +
                        $"Values ('{fName}', '{lName}', '{sHandle}', {cohortId})";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MOVESTUDENTTODIFFERENTCOHORT(int studentId, int cohortId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE Student " +
                        $"SET CohortId = @cohortId " +
                        $"WHERE Id = @studentId";
                    cmd.Parameters.Add(new SqlParameter("@cohortId", cohortId));
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentId));
                    cmd.ExecuteNonQuery();
                }
            }
        }



        /************************************************************************************
        * RELATIONAL TABLE FUNCTIONS:
        ************************************************************************************/

        public void ADDSTUDENTEXERCISE(int exerciseId, int studentId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO StudentExercises (ExerciseId, StudentId) " +
                        $"Values ({exerciseId}, {studentId})";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Exercise> SHOWEXERCISESFORSTUDENT(Student student)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT e.Id, e.Title, e.ExerciseLanguage " +
                        $"FROM Student s " +
                        $"JOIN StudentExercises x " +
                        $"ON s.Id = x.StudentId " +
                        $"JOIN Exercise e " +
                        $"ON x.ExerciseId = e.Id " +
                        $"WHERE s.Id = @studentId";
                    cmd.Parameters.Add(new SqlParameter("@studentId", student.Id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> studentsExercises = new List<Exercise>();


                    while (reader.Read())
                    {
                        int IdValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string TitleValue = reader.GetString(reader.GetOrdinal("Title"));
                        string LanguageValue = reader.GetString(reader.GetOrdinal("ExerciseLanguage"));



                        Exercise exercise = new Exercise
                        {
                            Id = IdValue,
                            Title = TitleValue,
                            ExerciseLanguage = LanguageValue
                        };

                        studentsExercises.Add(exercise);
                    }

                    reader.Close();
                    return studentsExercises;
                }
            }
        }






    }
}

