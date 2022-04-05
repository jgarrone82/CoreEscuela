using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entities;

namespace CoreEscuela.App
{
    public class SchoolEngine
    {
        public School School { get; set; }
        public SchoolEngine()
        {
            
        }

        public void Inicialize()
        {
            School = new School("George's Institute", 2010, SchoolType.High, "Argentina", "Córdoba", "2372 San Javier Street");

            LoadGrades();
            LoadCourses();
            LoadExams();
        }

        #region Loading Methods

        private void LoadGrades()
        {
            School.Grades = new List<Grade>{
                        new Grade() {Name = "Grade 101", HourType = HourTypes.Morning},
                        new Grade() {Name = "Grade 201", HourType = HourTypes.Morning},
                        new Grade() {Name = "Grade 301", HourType = HourTypes.Morning}
            };

            Random rnd = new Random();
            foreach (var c in School.Grades)
            {
                int randomAmount = rnd.Next(5, 20);
                c.Students = GenerateRandomStudents(randomAmount);
            }
        }

        private List<Student> GenerateRandomStudents(int randomAmount)
        {
            string[] name1 = { "Michael", "Janice", "John", "George", "Donald", "Thomas", "Nichole", "Karen" };
            string[] surname1 = { "Adams", "Smith", "Johnson", "Parker", "Trump", "Brown", "Turner" };
            string[] name2 = { "William", "Laura", "Rick", "Leonard", "Silvie", "Ellen", "Bryan", "Bruce" };

            var studentList = from n1 in name1
                              from n2 in name2
                              from a1 in surname1
                              select new Student { Name = $"{n1} {n2} {a1}" };

            return studentList.OrderBy((al) => al.UniqueId).Take(randomAmount).ToList();
        }

        private void LoadCourses()
        {
            foreach (var grade in School.Grades)
            {
                var coursesList = new List<Course>(){
                            new Course{Name="Introduction 101"},
                            new Course{Name="C# 101"} ,
                            new Course{Name="Cyber-security 101"},
                            new Course{Name="Crypto analysis 101"}                            
                };
                grade.Courses = coursesList;
            }
        }

        private void LoadExams()
        {
            
            foreach (var grade in School.Grades)
            {
                foreach (var course in grade.Courses)
                {
                    foreach (var student in grade.Students)
                    {
                        var rnd = new Random();
                        
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Exam
                            {
                                Course = course,
                                Name = $"{course.Name} Exam# {i + 1}",
                                Note = MathF.Round(10 * (float)rnd.NextDouble(), 2),
                                Student = student
                            };
                            student.Exams.Add(ev);
                        }
                    }
                }
            }
        }


        #endregion
    }
}