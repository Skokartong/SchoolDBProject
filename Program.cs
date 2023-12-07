using System;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to school! Choose option 1-8 please!");
            Console.WriteLine("1) View all students 2) View students from specific class");
            Console.WriteLine("3) Add new staff 4) View all staff");
            Console.WriteLine("5) Get all grades from current month");
            Console.WriteLine("6) View mean value grades, 7) Add new students ");
            Console.WriteLine("8) Exit");

            string input = Console.ReadLine();
            int reply;

            bool isValidInput = int.TryParse(input, out reply);

            if (isValidInput)
            {
                switch (reply)
                {
                    case 1:
                        ViewStudents.ShowAllStudents();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 2:
                        ViewClass.ViewSpecificClass();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 3:
                        AddStaff.AddNewStaff();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 4:
                        ViewStaff.ViewAllStaff();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 5:
                        ViewGrades.ViewAllGrades();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 6:
                        MeanValueGrades.GetMeanValue();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 7:
                        AddStudent.AddNewStudent();
                        ReturnMainMenu.PressEnter();
                        break;

                    case 8:
                        Console.WriteLine("Bye");
                        break;

                    default:
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid input, try again!");
                ReturnMainMenu.PressEnter();
            }
        }
    }
}

