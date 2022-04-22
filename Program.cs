using CoreEscuela.App;
using CoreEscuela.Entities;
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
var listBestStudents = report.GetBestAvgStudXCourse(5);

Printer.WriteTitle("Testing for taking an exam by console");
var newEval = new Exam();
string name, noteString;

Console.WriteLine("Enter the name of the exam");
Printer.PressENTER();
name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    Printer.WriteTitle("The value can't be empty");
    Console.WriteLine("Leaving the program");
}
else
{
    newEval.Name = name.ToLower();
    Console.WriteLine("The exam name has been entered correctly");
}


Console.WriteLine("Enter the exam note");
Printer.PressENTER();
noteString = Console.ReadLine();


try
{
    newEval.Note = float.Parse(noteString);
    if (newEval.Note < 0 || newEval.Note > 10)
    {
        throw new ArgumentOutOfRangeException("The number must be between 0 and 10");
    }
    Console.WriteLine("The exam note has been entered correctly");
    return;
}
catch (ArgumentOutOfRangeException arge)
{
    Printer.WriteTitle(arge.Message);
    Console.WriteLine("Leaving the program");
}
finally
{
    Printer.WriteTitle("FINALLY");
    Printer.Beep(2500, 500, 3);

}

void eventAction(object? sender, EventArgs e)
{
    Printer.WriteTitle("Closing");
    Printer.Beep(3000, 1000, 3);
    Printer.WriteTitle("Close");
}