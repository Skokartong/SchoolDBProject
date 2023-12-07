using System;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    public class MeanValueGrades
    {
        public static void GetMeanValue()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryMeanValue = $@"SELECT Courses.CourseName, 
                AVG(CAST(Enrollments.Grade AS float)) AS MeanValueGrade, 
                MAX(CAST(Enrollments.Grade AS float)) AS MaxValueGrade, 
                MIN(CAST(Enrollments.Grade AS float)) AS MinValueGrade
                FROM Enrollments
                JOIN Courses ON Enrollments.CourseID_FK = Courses.CourseID
                GROUP BY Courses.CourseName";

                SqlCommand command = new SqlCommand(queryMeanValue, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine($"Course: {reader["CourseName"]}");
                    Console.WriteLine($"Average grade: {reader["MeanValueGrade"]}");
                    Console.WriteLine($"Highest grade student: {reader["MaxValueGrade"]}");
                    Console.WriteLine($"Lowest grade student: {reader["MinValueGrade"]}");
                    Console.WriteLine();
                }

                reader.Close();
            }
        }
    }
}
