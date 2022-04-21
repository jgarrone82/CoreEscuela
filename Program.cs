using CoreEscuela.App;
using CoreEscuela.Util;

AppDomain.CurrentDomain.ProcessExit += eventAction;
AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

var engine = new SchoolEngine();
engine.Inicialize();
Printer.WriteTitle("Welcome to the School!");
Console.WriteLine(engine.School);

#region test methods
/* engine.School.CleanPlace(); 

var objectList = engine.GetSchoolObjects(
    out int countExams,
    out int countGrades,
    out int countCourses,
    out int countStudents
    );

var objetDict = engine.GetObjetDict();

engine.PrintDictionary(objetDict);

Console.ReadLine(); */

#endregion

var report = new Reports(engine.GetObjetDict());
var examsList = report.getExamsList();
var coursesList = report.GetCoursesList();
var listExamsXCourse = report.GetDicExamXCourse();
var listAverageXCourse = report.GetAvgStudXCourse();

Console.ReadLine();

void eventAction(object? sender, EventArgs e)
{
    Printer.WriteTitle("Closing");
    Printer.Beep(3000, 1000, 3);
    Printer.WriteTitle("Close");
}