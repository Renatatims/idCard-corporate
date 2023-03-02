using System;

namespace idCard.Corporate
{
    class Program
    {
        //Method - Get Employees
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
        // Create - Print employees method
        static void Main(string[] args)
        {
            List<string> employees = GetEmployees();
        }
    }
}
