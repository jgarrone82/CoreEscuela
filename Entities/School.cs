using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Util;

namespace CoreEscuela.Entities
{
    public class School : BaseSchoolObj, IPlace
    {
        public School(int yearOfCreation, SchoolType schoolType
                ,string country = "", string city = "", string address = "") 
        {
            this.YearOfCreation = yearOfCreation;            
            this.SchoolType = schoolType;
            this.Address = address;
            this.City = city;            
            this.Country = country;   
        }
        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public SchoolType SchoolType { get; set; }
        public List<Grade> Grades { set; get; } = new List<Grade>();
        public School(string name, int year,
                       SchoolType type,
                       string country = "", string city = "",
                       string address = "" ) : base()
        {
            (Name, YearOfCreation, SchoolType) = (name, year, type);
            Country = country;
            City = city;
            Address = address;
            //Grades = grades;
        }
        //public School(string name, int year) => (City, YearOfCreation) = (name, year);

        public override string ToString()
        {
            return $"Name: \"{Name}\"{System.Environment.NewLine}Adress: {Address}, Type: {SchoolType} {System.Environment.NewLine}City:{City}, Country: {Country}";
        }

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning School..");
            
            foreach (var grade in Grades)
            {
                grade.CleanPlace();
            }
            
            Printer.WriteTitle($"School {Name} clean");
            //Printer.Beep(1000, amount:3);
        }
    }
}