using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;


namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        public AlumnosCursoAdapter AlumnoCursoData { get; set; }

        public AlumnoInscripcionLogic()
        {
            AlumnoCursoData = new AlumnosCursoAdapter();

        }


        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            List<AlumnoInscripcion> alumnosInscripcionesActualizado = new List<AlumnoInscripcion>();
            
            alumnosInscripciones = this.AlumnoCursoData.GetAllAlumnosIncripciones();



            foreach(AlumnoInscripcion aluIns in alumnosInscripciones) 
            {
                AlumnoInscripcion alumnoInscripcionActualizado = new AlumnoInscripcion();

                alumnoInscripcionActualizado = aluIns;

                CursoLogic curLog = new CursoLogic();
                Curso cur = new Curso();

                cur = curLog.GetOne(aluIns.IDCurso);
                alumnoInscripcionActualizado.DescCurso = cur.Descripcion;


                PersonaLogic perLog = new PersonaLogic();
                Persona alumno = new Persona();

                alumno = perLog.GetOne(aluIns.IDAlumno);
                alumnoInscripcionActualizado.Alumno = alumno.Apellido + " " + alumno.Nombre + " - " + alumno.Legajo;

                alumnosInscripcionesActualizado.Add(alumnoInscripcionActualizado);

            }

            return alumnosInscripcionesActualizado;
            


        }



        public List<AlumnoInscripcion> GetAllAlumnosPorCurso(int cur)
        {
            return this.AlumnoCursoData.GetAllAlumnosPorCurso(cur);

        }

        public AlumnoInscripcion GetOne(int id) 
        {
            return this.AlumnoCursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            this.AlumnoCursoData.Delete(id);
        }

        public void Update(AlumnoInscripcion aluInsc) 
        {
            this.AlumnoCursoData.Update(aluInsc);
        }

        public void Insert(AlumnoInscripcion aluInsc)
        {
            this.AlumnoCursoData.Insert(aluInsc);
        }


        public void Save(AlumnoInscripcion aluInsc)      // punto 10
        {
            this.AlumnoCursoData.Save(aluInsc);
        }











    }
}