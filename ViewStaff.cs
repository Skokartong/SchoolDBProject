using System;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    public class ViewStaff
    {
        public static void ViewAllStaff()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("View all staff or choose staff from a category (S or C)?");
                string reply = Console.ReadLine();

                if (reply.ToLower() == "s")
                {
                    string query1 = "SELECT StaffName, Role, Wage FROM StaffMembers";
                    string staffName = "StaffName";
                    string role = "Role";
                    string wage = "Wage";

                    string query2 = "SELECT TeacherName, CourseName FROM Courses";
                    string teacherName = "TeacherName";
                    string courseName = "CourseName";

                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine();

                            while (reader.Read())
                            {
                                Console.WriteLine($"Staff name: {reader[staffName]}, Role: {reader[role]}, Wage: {reader[wage]}");
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Teacher's name: {reader[teacherName]}, Course: {reader[courseName]}");
                            }

                            reader.Close();
                        }
                    }
                }

                else if (reply.ToLower() == "c")
                {
                    Console.WriteLine("Category teacher, headmaster, janitor, teacher assistant or vice headmaster?");
                    Console.Write("Enter teacher, headmaster, janitor, teacher assistant or vice headmaster please: ");
                    string choosenCategory = Console.ReadLine();

                    if (choosenCategory.ToLower() == "teacher")
                    {
                        string query3 = "SELECT TeacherName, CourseName FROM Courses";
                        string teacherName = "TeacherName";
                        string courseName = "CourseName";

                        using (SqlCommand command = new SqlCommand(query3, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.WriteLine();

                                while (reader.Read())
                                {
                                    Console.WriteLine($"Teacher's name: {reader[teacherName]}, Course: {reader[courseName]}");
                                }
                                reader.Close();
                            }
                        }
                    }

                    else if (choosenCategory.ToLower() == "janitor" || choosenCategory.ToLower() == "vice headmaster" || choosenCategory.ToLower() == "headmaster" || choosenCategory.ToLower() == "teacher assistant")
                    {
                        string query4 = "SELECT StaffName, Role, Wage FROM StaffMembers WHERE Role = @choosenCategory";
                        string staffName = "StaffName";
                        string role = "Role";
                        string wage = "Wage";

                        using (SqlCommand command = new SqlCommand(query4, connection))
                        {
                            command.Parameters.AddWithValue("@choosenCategory", choosenCategory);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.WriteLine();

                                while (reader.Read())
                                {
                                    Console.WriteLine($"Staff's name: {reader[staffName]}, Role: {reader[role]}, Wage: {reader[wage]}");
                                }

                                reader.Close();
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid choice! Try again.");
                    }
                }  
                
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
        }
    }
}
