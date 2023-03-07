// Import Packages
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
//Import SkiaSharp
using SkiaSharp;
//Import Tasks
using System.Threading.Tasks;

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
        // MakeCSV - static method - generate CSV file with all the employees data
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

        // MakeIdCards - generate the cards template with the employee data
        async public static Task MakeIdCards(List<Employee> employees, int templateSelection)
        {
            // Card - Layout variables - pixel values
            int CARD_WIDTH = 670;
            int CARD_HEIGHT = 1045;

            //Employee Photo layout
            int PHOTO_LEFT_X = 185;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 485;
            int PHOTO_BOTTOM_Y = 515;

            //Company Name
            int COMPANY_NAME_Y = 150;

            //Employee Name
            int EMPLOYEE_NAME_Y = 610;

            //ID number
            int EMPLOYEE_ID_Y = 740;

            // Template file path
            string templateFilePath;

            // User's choice - id-template file path:
            switch (templateSelection)
            {
                case 1: // template1 - Green
                    templateFilePath = "./assets/card_templates/id-template1.png";
                    break;

                case 2: // template2 - Purple
                    templateFilePath = "./assets/card_templates/id-template2.png";
                    break;

                case 3: // template3 - Red
                    templateFilePath = "./assets/card_templates/id-template3.png";
                    break;

                case 4: // template4 - Blue
                    templateFilePath = "./assets/card_templates/id-template4.png";
                    break;
                
                case 5: // template5 - Yellow
                    templateFilePath = "./assets/card_templates/id-template5.png";
                    break;
                
                case 6: // template6 - Gray
                    templateFilePath = "./assets/card_templates/id-template6.png";
                    break;
                    
                default:
                    throw new ArgumentException("Invalid template selection");
            }


            // using - instance of HttpClient is disposed after code in the block has run
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    // Get Photo Url for each employee - then converting the Stream into a SKImage
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));

                    // SKImage template background
                    SKImage template = SKImage.FromEncodedData(File.OpenRead(templateFilePath));

                    // Card - width and height
                    SKBitmap card = new SKBitmap(CARD_WIDTH, CARD_HEIGHT);

                    // SKCanvas object - wrapper around the card bitmap - allows direct graphical modifications to the card
                    SKCanvas canvas = new SKCanvas(card);

                    // SKRectangular - allocates a postion and size on the card
                    canvas.DrawImage(template, new SKRect(0, 0, CARD_WIDTH, CARD_HEIGHT));

                    // Insert employee photo
                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                    //SKPaint object setup - properties
                    SKPaint paint = new SKPaint();
                    paint.TextSize = 42.0f;
                    paint.IsAntialias = true;
                    paint.Color = SKColors.White;
                    paint.IsStroke = false;
                    paint.TextAlign = SKTextAlign.Center;
                    paint.Typeface = SKTypeface.FromFamilyName("Verdana");

                    // Company name
                    canvas.DrawText(employees[i].GetCompanyName(), CARD_WIDTH / 2f, COMPANY_NAME_Y, paint);

                    //Employee Name Properties
                    paint.Color = SKColors.Black;

                    //Employee Name Draw Text
                    canvas.DrawText(employees[i].GetFullName(), CARD_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);

                    //ID Properties
                    paint.Typeface = SKTypeface.FromFamilyName("Tahoma");

                    //ID Draw Text
                    canvas.DrawText(employees[i].GetId().ToString(), CARD_WIDTH / 2f, EMPLOYEE_ID_Y, paint);

                    // Final Image
                    SKImage finalImage = SKImage.FromBitmap(card);
                    SKData data = finalImage.Encode();

                    // Save image to data directory on a png file
                    string idCard = "data/{0}_badge.png";
                    data.SaveTo(File.OpenWrite(string.Format(idCard, employees[i].GetId())));
                }
            }
        }
    }
}