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
        public AlumnosInscripcionesdapter AlumnoCursoData { get; set; }

        public AlumnoInscripcionLogic()
        {
            AlumnoCursoData = new AlumnosInscripcionesdapter();

        }

        public int ContarAlumnosInscriptosACurso(Curso cur)
        {
            return this.AlumnoCursoData.ContarAlumnosInscriptosACurso(cur);
        }


        public List<AlumnoInscripcion> GetAll()
        {
            return this.AlumnoCursoData.GetAll();
        }

        public List<AlumnoInscripcion> GetAllInscripcionesPorAlumno(int id_alumno)
        {
            return this.AlumnoCursoData.GetAllInscripcionesPorAlumno(id_alumno);
        }

        public List<AlumnoInscripcion> GetAllInscripcionesPorAlumno(int id_alumno, int anio_cal)
        {
            return this.AlumnoCursoData.GetAllInscripcionesPorAlumno(id_alumno, anio_cal);
        }







        public List<AlumnoInscripcion> GetAllAlumnosPorCurso(int cur)
        {
            return this.AlumnoCursoData.GetAllAlumnosPorCurso(cur);

        }


        public AlumnoInscripcion GetOne(int id) 
        {
            return this.AlumnoCursoData.GetOne(id);
        }
        public AlumnoInscripcion GetOne(int id_alumno, int id_curso)
        {
            return this.AlumnoCursoData.GetOne(id_alumno, id_curso);
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