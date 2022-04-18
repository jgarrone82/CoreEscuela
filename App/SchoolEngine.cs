using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entities;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public sealed class SchoolEngine
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

        public Dictionary<keyDictionary, IEnumerable<BaseSchoolObj> > GetObjetDict()
        {
            var dictionary = new Dictionary<keyDictionary, IEnumerable<BaseSchoolObj> >();

            dictionary.Add(keyDictionary.School, new [] {School});
            dictionary.Add(keyDictionary.Grade, School.Grades.Cast<BaseSchoolObj>());  
            
            var listCourse = new List<Course>();
            var listStudent = new List<Student>();
            var listExam = new List<Exam>();

            foreach (var cur in School.Grades)
            {
                listCourse.AddRange(cur.Courses);
                listStudent.AddRange(cur.Students);

                foreach (var alum in cur.Students)
                {
                    listExam.AddRange(alum.Exams);
                }

            }
            
            dictionary.Add(keyDictionary.Course, listCourse.Cast<BaseSchoolObj>());
            dictionary.Add(keyDictionary.Student, listStudent.Cast<BaseSchoolObj>());
            dictionary.Add(keyDictionary.Exam, listExam.Cast<BaseSchoolObj>());
                   

            return dictionary;
        }

        public void PrintDictionary(Dictionary<keyDictionary, IEnumerable<BaseSchoolObj>> dic,
                        bool printEval = false)
        {
            foreach (var objdic in dic)
            {
                Printer.WriteTitle(objdic.Key.ToString());

                foreach (var val in objdic.Value)
                {
                    switch (objdic.Key)
                    {
                        case keyDictionary.School:
                            Console.WriteLine("School: " + val);
                            break;
                        case keyDictionary.Student:
                            Console.WriteLine("Student: " + val.Name);
                            break;
                        case keyDictionary.Grade:
                            var curtmp = val as Grade;
                            if(curtmp != null)
                            {
                                int count = curtmp.Students.Count;
                                Console.WriteLine("Grade: " + val.Name + " Amount of Students: " + count);
                            }
                            break;
                        case keyDictionary.Exam:
                            if (printEval)
                                Console.WriteLine(val);
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        public IReadOnlyList<BaseSchoolObj> GetSchoolObjects(
            out int countExams,
            out int countGrades,
            out int countCourses,
            out int countStudents,
            bool getExams = true,
            bool getStudents = true,
            bool getCourses = true,
            bool getGrades = true
            )
        {
            countStudents = countCourses = countExams = 0;

            var objList = new List<BaseSchoolObj>();
            objList.Add(School);

            if (getGrades)
                objList.AddRange(School.Grades);

            countGrades = School.Grades.Count;
            foreach (var grade in School.Grades)
            {
                countCourses += grade.Courses.Count;
                countStudents += grade.Students.Count;

                if (getCourses)
                    objList.AddRange(grade.Courses);

                if (getStudents)
                    objList.AddRange(grade.Students);

                if (getExams)
                {
                    foreach (var student in grade.Students)
                    {

                        objList.AddRange(student.Exams);
                        countExams += student.Exams.Count;
                    }
                }
            }

            return objList.AsReadOnly();
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