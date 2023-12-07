using System;
using System.Data;
using System.Data.SqlClient;
using School;

namespace School
{
    public class ViewClass
    {
        public static void ViewSpecificClass()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryClass = "SELECT Class FROM Students";

                string className = "Class";
                string firstName = "FirstName";
                string queryOrderChoice = "";

                SqlCommand command = new SqlCommand(queryClass, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine();
                Console.WriteLine("Viewing classes:");

                while (reader.Read())
                {
                    Console.WriteLine($"Class name: {reader[className]}");
                }

                reader.Close();

                Console.WriteLine();
                Console.Write($"Select class by writing it's name (eg. 9A): ");
                string selectedClass = Console.ReadLine();

                string querySelectedClass = "SELECT COUNT(*) FROM Students WHERE Class = @selectedClass";

                SqlCommand command2 = new SqlCommand(querySelectedClass, connection);
                command2.Parameters.AddWithValue("@SelectedClass", selectedClass);

                int count = Convert.ToInt32(command2.ExecuteScalar());

                if (count > 0)
                {
                    Console.WriteLine($"Students name in ascending or descending order (A or D)?");
                    string orderBy = Console.ReadLine();

                    if (orderBy.ToLower() == "a")
                    {
                        queryOrderChoice = "SELECT Class, FirstName FROM Students WHERE Class = @selectedClass ORDER BY FirstName ASC";
                    }

                    else if (orderBy.ToLower() == "d")
                    {
                        queryOrderChoice = "SELECT Class, FirstName FROM Students WHERE Class = @selectedClass ORDER BY FirstName DESC";
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. Try again!");
                    }

                    SqlCommand command3 = new SqlCommand(queryOrderChoice, connection);
                    command3.Parameters.AddWithValue("@selectedClass", selectedClass);

                    SqlDataReader reader2 = command3.ExecuteReader();

                    while (reader2.Read())
                    {
                        Console.WriteLine($"Class: {reader2[className]}, Name: {reader2[firstName]}");
                    }

                    reader2.Close();
                }

                else
                {
                    Console.WriteLine("Invalid input! No class found with that name.");
                }
            }
        }
    }
}
