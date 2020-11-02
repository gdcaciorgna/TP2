using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {

        public DocenteCursoAdapter DocenteCursoData { get; set; }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll() 
        {
            List<DocenteCurso> docentesCursos = DocenteCursoData.GetAllDocentes();
            List<DocenteCurso> docentesCursosCompleto = new List<DocenteCurso>();

            foreach(DocenteCurso doc in docentesCursos)
            {
                DocenteCurso docCurAct = new DocenteCurso();

                docCurAct = doc;

                CursoLogic curLog = new CursoLogic();
                Curso cur = new Curso();

                cur = curLog.GetOne(doc.IDCurso);
                docCurAct.Curso = cur.Descripcion;


                PersonaLogic perLog = new PersonaLogic();
                Persona docente = new Persona();

                docente = perLog.GetOne(docCurAct.IDDocente);
                docCurAct.Docente = docente.Apellido + " " + docente.Nombre;

                docentesCursosCompleto.Add(docCurAct);
            }

            return docentesCursosCompleto;



        }



        public List<DocenteCurso> GetAllDocentesPorCurso(int cur)
        {
            return this.DocenteCursoData.GetAllDocentesPorCurso(cur);
        }

    }
}
