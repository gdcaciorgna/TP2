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
            return DocenteCursoData.GetAll();
        }

        public void Delete(int id)
        {
            this.DocenteCursoData.Delete(id);
        }

        public List<DocenteCurso> GetAllCompleto() 
          {
            List<DocenteCurso> docentesCursos = this.GetAll();
               List<DocenteCurso> docentesCursosCompleto = new List<DocenteCurso>();

                foreach (DocenteCurso doc in docentesCursos)
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

        public DocenteCurso.TiposCargo getTipoCargoString(String tipoCargoString)
        {
            DocenteCurso.TiposCargo tipo_cargo = new DocenteCurso.TiposCargo();
            if (tipoCargoString.Equals("Titular"))
            {
                tipo_cargo = DocenteCurso.TiposCargo.Titular;
            }
            
            else if (tipoCargoString.Equals("Teoria"))
            {
                tipo_cargo = DocenteCurso.TiposCargo.Teoria;
            }

            else if (tipoCargoString.Equals("Practica"))
            {
                tipo_cargo = DocenteCurso.TiposCargo.Practica;
            }

            else if (tipoCargoString.Equals("Auxiliar"))
            {
                tipo_cargo = DocenteCurso.TiposCargo.Auxiliar;
            }

            return tipo_cargo;

        }



        public List<DocenteCurso> GetAllDocentesPorCurso(int cur)
        {
            return this.DocenteCursoData.GetAllDocentesPorCurso(cur);
        }

        public List<DocenteCurso> GetAllDocentesCursos()
        {
            return this.DocenteCursoData.GetAllDocentesCursos();
        }

        public DocenteCurso GetOne(int id)
        {
            return this.DocenteCursoData.GetOne(id);
        }

        public void Insert(DocenteCurso docInsc)
        {
            this.DocenteCursoData.Insert(docInsc);
        }

        public void Save(DocenteCurso docInsc)      // punto 10
        {
            this.DocenteCursoData.Save(docInsc);
        }

     

    }
}
