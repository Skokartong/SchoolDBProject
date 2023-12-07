using System;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    public class AddStaff
    {
        public static void AddNewStaff()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Add new teacher or other staff (T or S)?");
                string reply = Console.ReadLine();

                if (reply.ToLower() == "t")
                {
                    Console.WriteLine("What's the teacher's name?");
                    string teacherName = Console.ReadLine();

                    Console.WriteLine("What's the name of the course he or she teaches?");
                    string courseName = Console.ReadLine();

                    string query = "INSERT INTO Courses (CourseName,TeacherName) VALUES (@courseName, @teacherName)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@CourseName", courseName);
                    command.Parameters.AddWithValue("@TeacherName", teacherName);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record inserted successfully.");
                        ReturnMainMenu.PressEnter();
                    }

                    else
                    {
                        Console.WriteLine("Failed to insert record.");
                    }
                }

                else if (reply.ToLower() == "s")
                {
                    Console.WriteLine("What's the staff member's name?");
                    string staffName = Console.ReadLine();

                    Console.WriteLine("What role does the staff member have?");
                    string role = Console.ReadLine();

                    Console.WriteLine("How much does he or she earn?");
                    string wage = Console.ReadLine();

                    string query = "INSERT INTO StaffMembers (StaffName, Role, Wage) VALUES (@staffName, @role, @wage)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@StaffName", staffName);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@Wage", wage);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record inserted successfully.");
                    }

                    else
                    {
                        Console.WriteLine("Failed to insert record.");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input! Try again.");
                }
            }
        }
    }
}
