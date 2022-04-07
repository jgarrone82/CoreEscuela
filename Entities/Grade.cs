using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Util;

namespace CoreEscuela.Entities
{
    public class Grade:BaseSchoolObj
    {
        public HourTypes HourType { get; set; }
        public List<Course> Courses{ get; set; } = new List<Course>();
        public List<Student> Students{ get; set; } = new List<Student>();
                
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Name} Limpio");
        }
    }
}