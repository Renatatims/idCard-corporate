using System;

namespace idCard.Corporate
{
    class Program
    {
        // Method - Get Employees
        static List<string> GetEmployees()
        {
            List<string> employees = new List<string>();
            while (true)
            {
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                string input = Console.ReadLine() ?? "";
                // Breaks if user doesn't input data
                if (input == "")
                {
                    break;
                }
                employees.Add(input);
            }
            return employees;
        }
        // Print employees method
        static void PrintEmployees(List<string> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                //Prints in the console - Employee ID, Full name (First and Last) and Photo Url
                Console.WriteLine(employees[i]);
            }
        }
        // Main
        static void Main(string[] args)
        {
            List<string> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}
