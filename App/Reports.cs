using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entities;

namespace CoreEscuela.App
{
    public class Reports
    {

        Dictionary<keyDictionary, IEnumerable<BaseSchoolObj>> _dictionary;

        public Reports(Dictionary<keyDictionary, IEnumerable<BaseSchoolObj>> dicSchoolObj)
        {
            if (dicSchoolObj == null)
            {
                throw new ArgumentNullException(nameof(dicSchoolObj));
            }

            _dictionary = dicSchoolObj;
        }

        public IEnumerable<Exam> getExamsList()
        {
            if (_dictionary.TryGetValue(keyDictionary.Exam,
                                       out IEnumerable<BaseSchoolObj> list))
            {
                return list.Cast<Exam>();
            }
            else
            {
                return new List<Exam>();
            }
        }

        public IEnumerable<string> GetCoursesList()
        {
            return GetCoursesList(
                    out var dummy);
        }

        public IEnumerable<string> GetCoursesList(
            out IEnumerable<Exam> examsList)
        {
            examsList = getExamsList();

            return (from Exam ex in examsList
                    select ex.Course.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Exam>> GetDicExamXCourse()
        {
            var ansDict = new Dictionary<string, IEnumerable<Exam>>();

            var courseList = GetCoursesList(out var examList);

            foreach (var course in courseList)
            {
                var examsCourse = from exam in examList
                                where exam.Course.Name == course
                                select exam;

                ansDict.Add(course, examsCourse);
            }

            return ansDict;
        }

        public Dictionary<string, IEnumerable<object>> GetAvgStudXCourse()
        {
            var ansDict = new Dictionary<string, IEnumerable<object>>();
            var DicExamXCourse = GetDicExamXCourse();

            foreach (var courseWithExam in DicExamXCourse)
            {
                var studentsAverage = from eval in courseWithExam.Value
                            group eval by new{
                                 eval.Student.UniqueId,
                                 eval.Student.Name}
                            into groupExamsStudent
                            select new AverageStudent
                            { 
                                idStudent = groupExamsStudent.Key.UniqueId,
                                StudentName = groupExamsStudent.Key.Name,
                                average = groupExamsStudent.Average(exam => exam.Note)
                            };
                 
                 ansDict.Add(courseWithExam.Key, studentsAverage);           
            }

            return ansDict;
        }
    }
}