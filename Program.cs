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

            /* GetEmployees method call
            employees = EmployeeFetcher.GetEmployees();*/

            //GetFromApi method call
            employees = await EmployeeFetcher.GetFromApi();

            // Print employees method
            Util.PrintEmployees(employees);

            // MakeCSV - method call
            Util.MakeCSV(employees);

            //MakeBadges - method call
            await Util.MakeIdCards(employees);
        }
    }
}
