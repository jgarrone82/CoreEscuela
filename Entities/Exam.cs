using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entities
{
    public class Exam : BaseSchoolObj
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public float Note { get; set; }

        public Exam()
        {
            Course = new Course();
            Name = $"Name";
            Note = 0.0f;
            Student = new Student();
        }



        public override string ToString()
        {
            return $"Course: {Course.Name}, Student: {Student.Name}, Note: {Note}";
        }

    }
}