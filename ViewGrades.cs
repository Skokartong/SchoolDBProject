using System;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    public class ViewGrades
    {
        public static void ViewAllGrades()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Viewing students and their grades:");

                string queryViewGrades = @"SELECT Students.FirstName, Enrollments.Grade, Courses.CourseName, Courses.TeacherName 
                FROM Enrollments
                JOIN Students ON Enrollments.StudentID_FK = Students.StudentID
                JOIN Courses ON Enrollments.CourseID_FK = Courses.CourseID";

                string firstName = "FirstName";
                string grade = "Grade";
                string courseName = "CourseName";
                string teacherName = "TeacherName";

                SqlCommand command = new SqlCommand(queryViewGrades, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Grade: {reader[grade]}, Course name: {reader[courseName]}, Teacher: {reader[teacherName]}, Student's name: {reader[firstName]}");
                }

                reader.Close();
            }
        }
    }
}
