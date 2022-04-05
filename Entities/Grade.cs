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
        public List<Course> Courses{ get; set; }
        public List<Student> Students{ get; set; }
                
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Name} Limpio");
        }
    }
}