using Project_1.ProblemDomain;
using Project_1.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
/*
 * Version: June 27th 2024
 * Authors: Karie Israeli, Justin Jabrica, Mat Dixon
 * Program Description: This program allows a user to search through a list of appliances and perform a few actions.
 *                      A user can search for and checkout an appliance, A user can find an appliance by a brand,
 *                      display an appliance by type and specific feature, produce a random set of appliances 
 *                      and save the appiance list to a text file.
 */
namespace Project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Setting a variable to use a flag for menu looping
            bool menuPrint = false;

            // Initializing two lists to store appliances
            List<string> newList = new List<string>();
            List<Appliance> applianceList = new List<Appliance>();

            // Reading the data from the text file and splitting the information into an array.
            string[] data = Resources.appliances.Split('\n');

            foreach (string line in data)
            {
                string[] applianceData = line.Split(';');

                // Switch case that takes the first index of the data in the appliaceData array and compares it to the first character in that index
                switch ((applianceData[0][0]))
                {
                    // Sort the appliances into the right class based on the first value of its item number and switch case defined earlier
                    case '1':
                        applianceList.Add(new Refrigerator(
                            long.Parse(applianceData[0]),
                            applianceData[1],
                            int.Parse(applianceData[2]),
                            double.Parse(applianceData[3]),
                            applianceData[4],
                            double.Parse(applianceData[5]),
                            applianceData[6],
                            applianceData[7],
                            applianceData[8]
                         ));
                        break;

                    case '2':
                        applianceList.Add(new Vacuums(
                            long.Parse(applianceData[0]),
                            applianceData[1],
                            int.Parse(applianceData[2]),
                            double.Parse(applianceData[3]),
                            applianceData[4],
                            double.Parse(applianceData[5]),
                            applianceData[6],
                            applianceData[7]
                            ));
                        break;

                    case '3':
                        applianceList.Add(new Microwaves(
                            long.Parse(applianceData[0]),
                            applianceData[1],
                            int.Parse(applianceData[2]),
                            double.Parse(applianceData[3]),
                            applianceData[4],
                            double.Parse(applianceData[5]),
                            applianceData[6],
                            applianceData[7]
                            ));
                        break;

                    case '4':
                        applianceList.Add(new Dishwashers(
                            long.Parse(applianceData[0]),
                            applianceData[1],
                            int.Parse(applianceData[2]),
                            double.Parse(applianceData[3]),
                            applianceData[4],
                            double.Parse(applianceData[5]),
                            applianceData[6],
                            applianceData[7]
                            ));
                        break;
                }
            }

            // Using the flag earlier to loop the following code 
            while (!menuPrint) { 
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How may we assist you?");
            Console.WriteLine("1 - Check out appliance");
            Console.WriteLine("2 - Find appliances by brand");
            Console.WriteLine("3 - Display appliance by type");
            Console.WriteLine("4 - Produce random appliance list");
            Console.WriteLine("5 - Save and exit");
            Console.WriteLine("Enter option");
            string inputRead = Console.ReadLine();          
                
                // Switch case to match the inputs to the correct functionality 
                switch (inputRead)
                {
                    case "1":
                        Console.WriteLine("Enter the item number of an appliance:");
                        string input = Console.ReadLine();
                        int count = 0;

                        
                        foreach (Appliance appliance in applianceList)
                        {               
                            // While looping through the appliance list if the input is in the item number add it to the new list
                            count += 1;
                            if (input == appliance.ItemNum.ToString())
                            {
                                // if statment so if the item has already been added to the list it won't be added again
                                if (!newList.Contains(appliance.ItemNum.ToString()))
                                {
                                    newList.Add(appliance.ItemNum.ToString());
                                    Console.WriteLine($"Appliance {appliance.ItemNum} has been checked out.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Item {appliance.ItemNum} is not available to be checked out.");
                                    break;
                                }                        
                            }
                            // Increment the count while looping through the list. If the count reaches the end and the input is not in the list print an error
                            else if (count == applianceList.Count() && input != appliance.ItemNum.ToString())
                            {
                                Console.WriteLine("No appliances found with that item number.");
                            }
                        }
                        // If every item is checked out print a message 
                        if (newList.Count == 25)
                            {
                                Console.WriteLine("No more appliances to check out");
                            }
                        break;                       
                        
                    case "2":
                        Console.WriteLine("Enter brand to search for:");
                        string input2 = Console.ReadLine();
                        Console.WriteLine("Matching Appliances:");

                        foreach (Appliance appliance in applianceList)

                            // Loop through the appliance list and perform a case insensitve search of the string to find the brand inputted
                            if (input2.Equals(appliance.Brand, StringComparison.OrdinalIgnoreCase))
                            {
                                
                                Console.WriteLine(appliance.ToString());
                            }
                        break;

                    case "3":
                        Console.WriteLine("Appliance Types");
                        Console.WriteLine("1 - Refrigerators");
                        Console.WriteLine("2 - Vacuums");
                        Console.WriteLine("3 - Microwaves");
                        Console.WriteLine("4 - Dishwasers");
                        Console.WriteLine("Enter type of appliance:");
                        string input3 = Console.ReadLine();

                        if (input3 == "1")
                        {
                            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                            input3 = Console.ReadLine();
                            Console.WriteLine("Matching Refrigerators:");

                            // Check if the object being referenced is in the Refrigerator class then evaluate the input 
                            foreach (Refrigerator refrigerator in applianceList.OfType<Refrigerator>())
                            {
                                if (input3 == refrigerator.DoorNum)
                                {
                                    Console.WriteLine(refrigerator.ToString());
                                }
                            }
                        }
                        else if (input3 == "2")
                        {
                            Console.WriteLine("Enter battery voltage value. 18v (low) or 24v (high)");
                            input3 = Console.ReadLine();
                            Console.WriteLine("Matching Vacuums:");


                            // Check if the object being referenced is in the Vacuum class then evaluate the input
                            foreach (Vacuums vacuum in applianceList.OfType<Vacuums>())
                            {
                                if (input3 == vacuum.BatteryVoltage)
                                {
                                    Console.WriteLine(vacuum.ToString());
                                }
                            }
                        }
                        else if (input3 == "3")
                        {
                            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                            input3 = Console.ReadLine();
                            Console.WriteLine("Matching Microwaves:");

                            // Check if the object being referenced is in the Microwave class then evaluate the input
                            foreach (Microwaves microwaves in applianceList.OfType<Microwaves>())
                            {
                                if (input3 == microwaves.RoomType)
                                {
                                    Console.WriteLine(microwaves.ToString());
                                }
                            }
                        }
                        else if (input3 == "4")
                        {
                            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate):");
                            input3 = Console.ReadLine();
                            Console.WriteLine("Matching Dishwashers:");

                            // Check if the object being referenced is in the Dishwasher class then evaluate the input
                            foreach (Dishwashers dishwashers in applianceList.OfType<Dishwashers>())
                            {
                                if (input3 == dishwashers.SoundRating)
                                {
                                    Console.WriteLine(dishwashers.ToString());
                                }
                            }
                        }
                        break;

                    case "4":

                        // Using the random class create a new random object to use
                        Console.WriteLine("Enter number of appliances");
                        Random rnd = new Random();
                        string input4 = Console.ReadLine();

                        // Iterates over the appliance list and uses the rnd.Next function in conjuction with Take to get "input4" elements from the list of appliances
                        IEnumerable<Appliance> rand = applianceList.OrderBy(x => rnd.Next()).Take(int.Parse(input4));

                        // Print the random elements taken form the list of appliances
                        foreach (Appliance appliance in rand)
                        {
                            Console.WriteLine(appliance.ToString());
                        }
                        break;

                    case "5":

                        // Reprint the appliance list to a text file and format it as it was oringally given 
                        using (StreamWriter temp = new StreamWriter("results.txt"))
                        {
                            foreach (Appliance appliance in applianceList)
                            {
                                temp.WriteLine(appliance.formatForFile());
                            }
                        }
                        // Exits the application when this case is matched
                        Environment.Exit(0);
                        break;

                        // Print an error message for invalid input
                    default:
                        Console.WriteLine("Please choose a valid option");                        
                        break;
                }
            }
        }
    }
}

    
