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
            School = new School("George's Institute", 2010,SchoolType.High,"Argentina","Córdoba","2372 San Javier Street");

            //CargarCursos();
            //CargarAsignaturas();
            //CargarEvaluaciones();
        }
    }
}