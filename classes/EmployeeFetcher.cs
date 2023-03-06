using System;
using System.Collections.Generic;

namespace idCard.Corporate
{
    class EmployeeFetcher
    {
        // Method - Get Employees
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Please enter the company name: ");
            string companyName = Console.ReadLine() ?? "";
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
                Employee currentEmployee = new Employee(companyName, firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            return employees;
        }
        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Please enter the company name: ");
            string companyName = Console.ReadLine() ?? "";

            using (HttpClient client = new HttpClient())
            {
                //GetStringAsync method - return all information from the below URL as a string
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                Console.Write(response);
            }
            return employees;
        }
    }

}
