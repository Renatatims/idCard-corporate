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
                //Employee's First Name
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                string firstName = Console.ReadLine() ?? "";
                // Breaks if user doesn't input data
                if (firstName == "")
                {
                    break;
                }
                // Console Write Line and Read Line for each value
                // Last Name
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";

                //ID - Int32 - store a string as an integer
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");

                //Photo URL
                Console.Write("Enter Photo URL:");
                string photoUrl = Console.ReadLine() ?? "";

                // Create a new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }
        // Print employees method
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                //Template spacing information 
                string template = "{0,-1}\t{1,-5}\t{2}";
                //Prints in the console - Employee ID, Full name (First and Last) and Photo Url
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
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
