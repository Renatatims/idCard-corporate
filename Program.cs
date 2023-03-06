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
            employees = EmployeeFetcher.GetEmployees();
            
            // Print employees method
            Util.PrintEmployees(employees);

            // MakeCSV - method call
            Util.MakeCSV(employees);

            //MakeBadges - method call
            await Util.MakeIdCards(employees);
        }
    }
}
