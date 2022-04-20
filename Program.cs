using CoreEscuela.App;
using CoreEscuela.Util;

AppDomain.CurrentDomain.ProcessExit += eventAction;
AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

var engine = new SchoolEngine();
engine.Inicialize();
Printer.WriteTitle("Welcome to the School!");
Console.WriteLine(engine.School);

engine.School.CleanPlace(); 

var objectList = engine.GetSchoolObjects(
    out int countExams,
    out int countGrades,
    out int countCourses,
    out int countStudents
    );

var objetDict = engine.GetObjetDict();

engine.PrintDictionary(objetDict);

Console.ReadLine();

void eventAction(object? sender, EventArgs e)
{
    Printer.WriteTitle("Closing");
    Printer.Beep(3000, 1000, 3);
    Printer.WriteTitle("Close");
}