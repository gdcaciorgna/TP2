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
            return DocenteCursoData.GetAllDocentes();
        }



        public List<DocenteCurso> GetAllDocentesPorCurso(int cur)
        {
            return this.DocenteCursoData.GetAllDocentesPorCurso(cur);
        }

    }
}
