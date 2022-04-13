using CoreEscuela.App;
using CoreEscuela.Entities;
using CoreEscuela.Util;


//var school = new School("George's Institute", 2010,SchoolType.High,"Argentina","Córdoba","2372 San Javier Street");

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

Console.ReadLine();