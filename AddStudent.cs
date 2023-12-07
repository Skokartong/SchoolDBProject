using System;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace School
{
    public class AddStudent
    {
        public static void AddNewStudent()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    Console.Write("Student's first name please: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Student's last name please: ");
                    string lastName = Console.ReadLine();

                    Console.Write("What class is student in? ");
                    string studentClass = Console.ReadLine();

                    Console.Write("What course does the student take? ");
                    string courseName = Console.ReadLine();

                    Console.Write("What's the name of the teacher? ");
                    string teacherName = Console.ReadLine();

                    string queryStudents = "INSERT INTO Students(FirstName, LastName, Class) VALUES(@firstName, @lastName, @studentClass)";
                    string queryCourses = "INSERT INTO Courses(CourseName, TeacherName) VALUES(@courseName, @teacherName)";
                    string queryEnrollment = "INSERT INTO Enrollments(StudentID_FK, CourseID_FK) VALUES((SELECT StudentID FROM Students WHERE FirstName = @firstName AND LastName = @lastName), (SELECT CourseID FROM Courses WHERE CourseName = @courseName AND TeacherName = @teacherName))";

                    SqlCommand command1 = new SqlCommand(queryStudents, connection, transaction);
                    SqlCommand command2 = new SqlCommand(queryCourses, connection, transaction);
                    SqlCommand command3 = new SqlCommand(queryEnrollment, connection, transaction);

                    command1.Parameters.AddWithValue("@firstName", firstName);
                    command1.Parameters.AddWithValue("@lastName", lastName);
                    command1.Parameters.AddWithValue("@studentClass", studentClass);

                    command2.Parameters.AddWithValue("@courseName", courseName);
                    command2.Parameters.AddWithValue("@teacherName", teacherName);

                    command3.Parameters.AddWithValue("@firstName", firstName);
                    command3.Parameters.AddWithValue("@lastName", lastName);
                    command3.Parameters.AddWithValue("@courseName", courseName);
                    command3.Parameters.AddWithValue("@teacherName", teacherName);

                    int rowsAffectedStudent = command1.ExecuteNonQuery();
                    int rowsAffectedCourse = command2.ExecuteNonQuery();

                    if (rowsAffectedStudent > 0 && rowsAffectedCourse > 0)
                    {
                        int rowsAffectedEnrollment = command3.ExecuteNonQuery();

                        if (rowsAffectedEnrollment > 0)
                        {
                            Console.WriteLine("Student linked to course successfully.");
                            transaction.Commit();
                        }
                        else
                        {
                            Console.WriteLine("Failed to link student to course.");
                            transaction.Rollback();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Failed to insert student or course records.");
                        transaction.Rollback();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    transaction.Rollback();
                }
            }
        }
    }
}
