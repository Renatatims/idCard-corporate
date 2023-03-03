// Import Packages
using System;
using System.IO;
using System.Collections.Generic;

namespace idCard.Corporate
{
    class Util
    {
         // PrintEmployees - static method
        public static void PrintEmployees(List<Employee> employees)
        {
             for (int i = 0; i < employees.Count; i++)
            {
                //Template spacing information 
                string template = "{0,-1}\t{1,-5}\t{2}";
                //Prints in the console - Employee ID, Full name (First and Last) and Photo Url
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }
        //MakeCSV - static method - generate CSV file with all the employees data
        public static void MakeCSV(List<Employee> employees)
        {
            // Check to see if folder exists
            if (!Directory.Exists("data"))
            {
                // If not, create data directory
                Directory.CreateDirectory("data");
                //Create a CSV file - using - once it runs the SteamWriter is removed
                using (StreamWriter file = new StreamWriter("data/employees.csv"))
                {
                    file.WriteLine("ID,Name,PhotoUrl");
                    // Loop over employees
                    for (int i = 0; i < employees.Count; i++)
                    {
                        // Write each employee's data to the file - Id, Full Name and Photo Url
                        string template = "{0},{1},{2}";
                        file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                    }
                }
            }
        }
    }
}