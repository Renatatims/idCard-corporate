using System;
using System.Threading.Tasks;

namespace idCard.Corporate
{
    class Program
    {
        // Main - asynchronous
        async static Task Main(string[] args)
        {
            List<Employee> employees;

            //idCard template selection:
            Console.WriteLine("Please select an idCard template color:");

            Console.WriteLine("\t1 - Green");
            Console.WriteLine("\t2 - Purple");

            //idCard generation - manual or get data from API
            Console.WriteLine("Please select an option to generate the idCards:");

            Console.WriteLine("\t1 - Manually input employee's data");
            Console.WriteLine("\t2 - Get data from an API - 10 random idCards will be generated");

            // Switch satatement
            switch (Console.ReadLine() ?? "")
            {
                case "1":
                    // GetEmployees method call
                    employees = EmployeeFetcher.GetEmployees();

                    // Print employees method
                    Util.PrintEmployees(employees);

                    // MakeCSV - method call
                    Util.MakeCSV(employees);

                    //MakeBadges - method call with selected template
                    await Util.MakeIdCards(employees);

                    break;

                case "2":
                    //GetFromApi method call
                    employees = await EmployeeFetcher.GetFromApi();

                    // Print employees method
                    Util.PrintEmployees(employees);

                    // MakeCSV - method call
                    Util.MakeCSV(employees);

                    //MakeBadges - method call with selected template
                    await Util.MakeIdCards(employees);

                    break;
            }
        }
    }
}
