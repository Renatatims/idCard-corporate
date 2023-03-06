using System;
using System.Collections.Generic;

//Newtonsoft import
using Newtonsoft.Json.Linq;

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

        //GetFromApi Method
        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Please enter the company name: ");
            string companyName = Console.ReadLine() ?? "";

            using (HttpClient client = new HttpClient())
            {
                //GetStringAsync method - return all information from the below URL as a string
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                //Console.Write(response);

                //Parse response
                JObject json = JObject.Parse(response);

                foreach (JToken token in json.SelectToken("results")!)
                {
                    // Parse JSON data
                    Employee emp = new Employee
                    (
                      companyName,
                      token.SelectToken("name.first")!.ToString(),
                      token.SelectToken("name.last")!.ToString(),
                      Int32.Parse(token.SelectToken("id.value")!.ToString().Replace("-", "")),
                      token.SelectToken("picture.large")!.ToString()
                    );
                    employees.Add(emp);
                }

            }
            return employees;
        }
    }

}
