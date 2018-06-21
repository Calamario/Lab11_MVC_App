using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Time_PotY.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// Method to make a List of TimePerson
        /// </summary>
        /// <param name="begYear"> An int to start </param>
        /// <param name="endYear"> An int to end </param>
        /// <returns> A List of Time Person</returns>
        public List<TimePerson> GetPeople(int begYear, int endYear)
        {
            //Makes a new list of TimePerson called people
            List<TimePerson> people = new List<TimePerson>();
            //Path to look at the current directory
            string path = Environment.CurrentDirectory;
            //Adds on to the path, to direct to the csv file
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // reads the csv file and stores each line as an element of an array
            string[] myFile = File.ReadAllLines(newPath);

            //For loop to illterate the myFile array
            for (int i = 1; i < myFile.Length; i++)
            {
                //Split each element on the comma into an array
                string[] fields = myFile[i].Split(',');
                //Using the newly created array, use that info to create a new TimePerson and add it to the List 
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }
            //LINQ + Lambda expressions to make the query to filter the List
            List<TimePerson> listofPeople = 
                people.Where(p => (p.Year >= begYear) && (p.Year <= endYear))
                       .ToList();
            //return the list
            return listofPeople;
        }
    }

}
