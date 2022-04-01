using CoreEscuela.App;
using CoreEscuela.Entities;
using CoreEscuela.Util;

var engine = new SchoolEngine();
engine.Inicialize();

//var school = new School("George's Institute", 2010,SchoolType.High,"Argentina","Córdoba","2372 San Javier Street");


Printer.WriteTitle("Welcome to the School!");
Console.WriteLine(engine.School);
