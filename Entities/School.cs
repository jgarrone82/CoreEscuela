using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entities
{
    public class School : BaseSchoolObj
    {
        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public SchoolType SchoolType { get; set; }
        //public List<Grade> grades { set; get; }
        public School(string country, string city, string address)
        {
            this.Country = country;
            this.City = city;
            this.Address = address;
        }

        public School(string name, int year,
                       SchoolType type,
                       string country = "", string city = "",
                       string address = "") : base()
        {
            (Name, YearOfCreation, SchoolType) = (name, year, type);
            Country = country;
            City = city;
            Address = address;
        }
        //public School(string name, int year) => (City, YearOfCreation) = (name, year);

        public override string ToString()
        {
            return $"Name: \"{Name}\"{System.Environment.NewLine}Adress: {Address}, Type: {SchoolType} {System.Environment.NewLine}City:{City}, Country: {Country}";
        }

    }
}