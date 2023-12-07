using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class ReturnMainMenu
    {
        public static void PressEnter()
        {
            Console.WriteLine("Press enter for main menu!");
            while (Console.ReadLine() != string.Empty)
            {
                Console.WriteLine("Invalid input! Press enter for main menu!");
            }

            Console.Clear();
            Program.DisplayMenu();
        }
    }
}
