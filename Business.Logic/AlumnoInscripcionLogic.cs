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
            return this.AlumnoCursoData.GetAllAlumnosIncripciones();
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