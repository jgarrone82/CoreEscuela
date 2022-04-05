using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entities
{
    public class Student:BaseSchoolObj
    {
         public List<Exam> Exams { get; set; } = new List<Exam>();
    }
}