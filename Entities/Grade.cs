using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Util;

namespace CoreEscuela.Entities
{
    public class Grade:BaseSchoolObj, IPlace
    {
        public HourTypes HourType { get; set; }
        public List<Course> Courses{ get; set; } = new List<Course>();
        public List<Student> Students{ get; set; } = new List<Student>();
        public string Address { get; set; }

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning the grade...");
            Console.WriteLine($"Grade {Name} clean");
        }
    }
}