using System;

namespace idCard.Corporate
{
    class Program
    {
        // Method - Get Employees
        static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                string input = Console.ReadLine() ?? "";
                // Breaks if user doesn't input data
                if (input == "")
                {
                    break;
                }
                // Create a new Employee instance
                Employee currentEmployee = new Employee(input, "lastName");
                employees.Add(currentEmployee);
            }
            return employees;
        }
        // Print employees method
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                //Prints in the console - Employee ID, Full name (First and Last) and Photo Url
                Console.WriteLine(employees[i].GetFullName());
            }
        }
        // Main
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}
