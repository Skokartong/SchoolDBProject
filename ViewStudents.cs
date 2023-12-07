using System;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    public class ViewStudents
    {
        public static void ShowAllStudents()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("Sort after first or lastname? Enter F or L please: ");
                string sortName = Console.ReadLine();

                string query = "";
                string columnName1 = "";
                string columnName2 = "";
                string columnName3 = "";

                if (sortName.ToLower() == "f")
                {
                    Console.Write("In ascending or descending order? Enter A or D please: ");
                    string orderBy = Console.ReadLine();
                    
                    query = "SELECT FirstName, LastName, Class FROM Students ORDER BY FirstName";
                    columnName1 = "FirstName";
                    columnName2 = "LastName";
                    columnName3 = "Class";

                    if (orderBy.ToLower() == "a")
                    {
                        query += " ASC";
                    }

                    else if (orderBy.ToLower() == "d")
                    {
                        query += " DESC";
                    }

                    else
                    {
                        Console.WriteLine("Invalid input! Not good.");
                        ReturnMainMenu.PressEnter();
                    }
                }

                else if (sortName.ToLower() == "l")
                {
                    Console.Write("In ascending or descending order? Enter A or D please: ");
                    string orderBy = Console.ReadLine();

                    query = "SELECT LastName, FirstName, Class FROM Students ORDER BY LastName";
                    columnName1 = "LastName";
                    columnName2 = "FirstName";
                    columnName3 = "Class";

                    if (orderBy.ToLower() == "a")
                    {
                        query += " ASC";
                    }

                    else if (orderBy.ToLower() == "d")
                    {
                        query += " DESC";
                    }

                    else
                    {
                        Console.WriteLine("Invalid input! Try again mate.");
                        ReturnMainMenu.PressEnter();
                    }
                }

                else
                {
                    Console.WriteLine("Wrong input!");
                    ReturnMainMenu.PressEnter();
                }

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[columnName1]}, {reader[columnName2]}, {reader[columnName3]}");
                }

                reader.Close();
            }
        }
    }
}
