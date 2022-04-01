using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entities
{
    public class Exam:BaseSchoolObj
    {
        public Student Student { get; set; }
        public Course Courses { get; set; }
        public float Note { get; set; }

        public override string ToString()
        {
            //return $"{Note}, {Student.Name}, {Course.Name}";
            return $"{Note}, {Student.Name}";
        }
    }
}